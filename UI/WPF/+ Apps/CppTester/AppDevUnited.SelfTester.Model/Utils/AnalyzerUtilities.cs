using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppDevUnited.SelfTester.Model.Poco;

namespace AppDevUnited.SelfTester.Model.Utils
{
   /// <summary>
   ///    ������� �����������
   /// </summary>
   /// <remarks>���� ����� �������� ������ ���������� �� �����������, ���� ����������� ��������� � �����������</remarks>
   public static class AnalyzerUtilities
   {
      #region ���������� ������ �������� ������� � Visual Studio

      /// <summary>
      ///    ��������� ������ ���������� ����� � ������ ����� ��� ������ ��������
      /// </summary>
      /// <param name="suitableSolutions">����� �������, ���������� ��� ���������� ��������</param>
      /// <param name="selectedRunFolder">���� � ����� � ������</param>
      /// <returns>����� ���������� ����� � ������ ����� ��� ������ ��������</returns>
      private static IEnumerable<string> GetLogsToReplace(
         IEnumerable<Tuple<StartupConfigurationMode, SolutionInfoViewModel>> suitableSolutions, string selectedRunFolder)
      {
         var etalonFolderPath = ApplicationConfigReader.Instance.EtalonLogFolder + Path.DirectorySeparatorChar;
         var blbsrvEtalonFolderPath = ApplicationConfigReader.Instance.BldSrvEtalonsFolder +
                                      Path.DirectorySeparatorChar;

         var logsToReplace = new HashSet<string>();
         var slnTuples =
            suitableSolutions as Tuple<StartupConfigurationMode, SolutionInfoViewModel>[] ??
            suitableSolutions.ToArray();

         foreach (var suitableSln in slnTuples)
         {
            var testingSession = Path.Combine(selectedRunFolder, suitableSln.Item1.ToString());
            var sessionPlogs = Directory.GetFiles(testingSession,
               string.Format("*{0}", CoreExtensions.EtalonLogExt),
               SearchOption.TopDirectoryOnly);
            var sessionPathPlogs = sessionPlogs.Select(Path.GetFileName).ToArray();

            var allPlogs = new HashSet<string>();
            var diffExistPlogs = new HashSet<string>();
            foreach (var sessionPlog in sessionPathPlogs)
            {
               const string pvsDiffDetectStr = "plog_Diffs.plog";
               if (sessionPlog.EndsWith(pvsDiffDetectStr, true, CultureInfo.CurrentCulture))
               {
                  var foundPos = sessionPlog.IndexOf(pvsDiffDetectStr, StringComparison.CurrentCultureIgnoreCase);
                  var plogFile = string.Format("{0}plog", sessionPlog.Substring(0, foundPos));
                  diffExistPlogs.Add(Path.Combine(testingSession, plogFile));
               }
               else
               {
                  var addedItem = Path.Combine(testingSession, sessionPlog);
                  allPlogs.Add(addedItem);
                  // diff-���� �� ����������, �� ���������� ���� ���� ���
                  if (!File.Exists(etalonFolderPath + sessionPlog) || !File.Exists(blbsrvEtalonFolderPath + sessionPlog))
                  {
                     diffExistPlogs.Add(addedItem);
                  }
               }
            }

            allPlogs.IntersectWith(diffExistPlogs);
            logsToReplace.UnionWith(allPlogs);
         }

         FilterLogs(logsToReplace, slnTuples.Select(tuple => tuple.Item2));

         return logsToReplace;
      }

      private static Process OpenAnalysisReportUntilWndValid(SolutionInfoViewModel currentSolution,
         StartupConfigurationMode startupConfigurationMode, string selectedRunFolder, bool minimizeWindow)
      {
         Process devenvProc;
         if (!Prepare(currentSolution, startupConfigurationMode, selectedRunFolder, out devenvProc))
            return null;

         IntPtr wndHandle;
         do
         {
            wndHandle = devenvProc.MainWindowHandle;
         } while (wndHandle == IntPtr.Zero);

         Unmanaged.ShowWindow(wndHandle,
            minimizeWindow ? Unmanaged.ShowOptions.Minimize : Unmanaged.ShowOptions.Show);

         return devenvProc;
      }

      /// <summary>
      ///    ��������� diff-���� ���� � ������� PVS-Studio
      /// </summary>
      /// <param name="currentSolution">�������</param>
      /// <param name="startupConfigurationMode">������������ �������</param>
      /// <param name="selectedRunFolder">���������� ��������� �������</param>
      private static void OpenAnalysisReportUntilWndValid(SolutionInfoViewModel currentSolution,
         StartupConfigurationMode startupConfigurationMode, string selectedRunFolder)
      {
         Process devenvProc;
         if (!Prepare(currentSolution, startupConfigurationMode, selectedRunFolder, out devenvProc))
            return;

         // ��������� �����, ���� �� �������� ����
         var vsIsInVisibleState = false;
         do
         {
            var vsWndHandle = devenvProc.MainWindowHandle;
            if (vsWndHandle == IntPtr.Zero)
            {
               continue;
            }

            vsIsInVisibleState = Unmanaged.IsWindowVisible(vsWndHandle);
         } while (!vsIsInVisibleState);
      }

      private static bool Prepare(SolutionInfoViewModel currentSolution,
         StartupConfigurationMode startupConfigurationMode,
         string selectedRunFolder, out Process devenvProc)
      {
         var absSlnFile = currentSolution.TestSolutionInfo.AbsSolutionFileName;
         var vsPath = InstallationInfo.RetrieveVisualStudioPath(startupConfigurationMode);
         var selfTesterRootPath = ApplicationConfigReader.SelfTesterRootPath;
         var srcEtalonFolder = ApplicationConfigReader.Instance.SrcEtalonFolder;

         PrepareSolution(absSlnFile, vsPath, selfTesterRootPath, srcEtalonFolder);
         var selectedDiffLog = string.Format("{0}{1}{2}{1}{3}{4}_Diffs.plog", selectedRunFolder,
            Path.DirectorySeparatorChar, startupConfigurationMode, Path.GetFileNameWithoutExtension(absSlnFile),
            CoreExtensions.EtalonLogExt);

         if (!File.Exists(selectedDiffLog))
         {
            devenvProc = null;
            return false;
         }

         var vsStartInfo = new ProcessStartInfo
         {
            FileName = string.Format("{0}{1}devenv.exe", vsPath, Path.DirectorySeparatorChar),
            Arguments =
               string.Format("\"{0}\" /command \"PVSStudio.OpenAnalysisReport {1}\"", absSlnFile, selectedDiffLog)
         };
         devenvProc = Process.Start(vsStartInfo);
         if (devenvProc == null)
            return false;

         devenvProc.WaitForInputIdle();
         return true;
      }

      #endregion

      #region ������ ����������� ������ �������� ������� � Visual Studio

      /// <summary>
      ///    ��������� ������ ���������� ����� � ������ ����� ��� ������ �������� � ������������� ������
      /// </summary>
      /// <param name="suitableSolutions">����� �������, ���������� ��� ���������� ��������</param>
      /// <param name="selectedRunFolder">���� � ����� � ������</param>
      /// <returns>������ � ����������� ������� ���������� ����� � ������ ����� ��� ������ ��������</returns>
      public static Task<string[]> GetLogsToReplaceAsync(
         IEnumerable<Tuple<StartupConfigurationMode, SolutionInfoViewModel>> suitableSolutions, string selectedRunFolder)
      {
         return Task.Run(() => GetLogsToReplace(suitableSolutions, selectedRunFolder).ToArray());
      }

      /*private static async Task<Process> OpenReportAsync(string runFolder,
         Tuple<StartupConfigurationMode, SolutionInfoViewModel> sln, bool minimizeWindow)
      {
         var currentSolution = sln.Item2;
         var currentConfMode = sln.Item1;
         if (currentSolution == null || currentConfMode == StartupConfigurationMode.All)
         {
            return null;
         }

         var slnStatus = currentConfMode.GetStatusValue(currentSolution);
         return slnStatus == AnalysisStatus.DiffFinished || slnStatus == AnalysisStatus.Opening
            ? await
               OpenAnalysisReportUntilWndValidAsync(currentSolution, currentConfMode, runFolder, minimizeWindow)
                  .ConfigureAwait(true)
            : null;
      }*/

      /// <summary>
      ///    �������� ������� �� ������� � ������������� ������
      /// </summary>
      /// <param name="solutions">����� �������</param>
      /// <param name="runFolder">���������� � ��������</param>
      /// <param name="minimizeWindow">true, ���� ����� �������� ���� � ��������� ����, false - � ��������� ������</param>
      /// <param name="doneAction">�������� �� ����������</param>
      /// <returns>������ �����������</returns>
      public static async Task OpenAnalysisReportsAsync(
         IEnumerable<Tuple<StartupConfigurationMode, SolutionInfoViewModel>> solutions, string runFolder,
         bool minimizeWindow, Action doneAction = null)
      {
         if (solutions == null)
            return;

         var imdSolutions = solutions.ToList();
         imdSolutions.ForEach(sln => sln.Item2.SetStatusValue(sln.Item1, AnalysisStatus.Opening));

         await
            Task.Run(
               () =>
               {
                  try
                  {
                     #region ����������� ������������ ������� �� ��������

                     /*
                     async sln =>
                     {
                        var startMode = sln.Item1;
                        const AnalysisStatus opened = AnalysisStatus.Opened;
                        const AnalysisStatus diffed = AnalysisStatus.DiffFinished;
                        var vsProc = await OpenReportAsync(runFolder, sln, minimizeWindow).ConfigureAwait(true);
                        if (vsProc == null)
                           return;

                        vsProc.EnableRaisingEvents = true;
                        vsProc.Exited += (sender, args) => sln.Item2.SetStatusValue(startMode, diffed);
                        sln.Item2.SetStatusValue(startMode, opened);
                     }
                     */

                     #endregion

                     Parallel.ForEach(imdSolutions, sln =>
                     {
                        var startMode = sln.Item1;
                        const AnalysisStatus opened = AnalysisStatus.Opened;
                        const AnalysisStatus diffed = AnalysisStatus.DiffFinished;
                        Process vsProc = OpenReport(runFolder, sln, minimizeWindow);
                        if (vsProc == null)
                           return;

                        vsProc.EnableRaisingEvents = true;
                        vsProc.Exited += (sender, args) => sln.Item2.SetStatusValue(startMode, diffed);
                        sln.Item2.SetStatusValue(startMode, opened);
                     });
                  }
                  finally
                  {
                     if (doneAction != null)
                     {
                        doneAction();
                     }
                  }
               }).ConfigureAwait(true);
      }

      private static Process OpenReport(string runFolder, Tuple<StartupConfigurationMode, SolutionInfoViewModel> sln, bool minimizeWindow)
      {
         var currentSolution = sln.Item2;
         var currentConfMode = sln.Item1;
         if (currentSolution == null || currentConfMode == StartupConfigurationMode.All)
            return null;

         var slnStatus = currentConfMode.GetStatusValue(currentSolution);
         return slnStatus == AnalysisStatus.DiffFinished || slnStatus == AnalysisStatus.Opening
            ? OpenAnalysisReportUntilWndValid(currentSolution, currentConfMode, runFolder, minimizeWindow)
            : null;
      }

      /// <summary>
      ///    ��������� diff-���� ���� � ������� PVS-Studio � ������������� ������
      /// </summary>
      /// <param name="currentSolution">�������</param>
      /// <param name="startupConfigurationMode">������������ �������</param>
      /// <param name="selectedRunFolder">���������� ��������� �������</param>
      /// <returns>(Void)-������ �����������</returns>
      public static Task OpenAnalysisReportUntilWndValidAsync(SolutionInfoViewModel currentSolution,
         StartupConfigurationMode startupConfigurationMode, string selectedRunFolder)
      {
         return Task.Run(() => OpenAnalysisReportUntilWndValid(currentSolution, startupConfigurationMode, selectedRunFolder));
      }

      #endregion

      #region ��������������� ��������� ������ ���������� ��� �������� ����� � plog-������

      /// <summary>
      ///    �������� diff-���� �� ����� plog-�
      /// </summary>
      /// <param name="plogFilePath">���� � plog-�����</param>
      /// <returns>diff-���� �� ����� plog-�, ��� ������ ������, ���� �� �� ������</returns>
      public static string GetDiffFile(this string plogFilePath)
      {
         if (!File.Exists(plogFilePath))
            return string.Empty;

         var plogFileName = Path.GetFileNameWithoutExtension(plogFilePath);
         var diffFilePath = string.Format("{0}{1}{2}{3}_Diffs{3}", Path.GetDirectoryName(plogFilePath),
            Path.DirectorySeparatorChar, plogFileName, CoreExtensions.EtalonLogExt);

         return File.Exists(diffFilePath) ? diffFilePath : string.Empty;
      }

      /// <summary>
      ///    �������� ������ ���� � ���� ���������� devenv'�
      /// </summary>
      /// <param name="logFileName">���� � plog-����� ��� ������ �������</param>
      /// <returns>������ ���� � ���� ���������� devenv'�</returns>
      public static string GetDevenvActivityLog(this string logFileName)
      {
         const string activitySuffix = ".Activity.xml";
         return string.Format("{0}{1}{2}{3}", Path.GetDirectoryName(logFileName), Path.DirectorySeparatorChar,
            Path.GetFileNameWithoutExtension(logFileName), activitySuffix);
      }

      #endregion

      #region ��������� ��������� ������

      /// <summary>
      ///    �������������� ��������� ������ ����� ������� robocopy
      /// </summary>
      /// <param name="slnFileName">��� �������</param>
      /// <param name="selfTesterRootPath">�������� ������� ������������</param>
      /// <param name="srcEtalon">���� �������</param>
      /// <returns>������ (bool = ���������� ��������, string = ���������� ����� �������� robocopy)</returns>
      public static Tuple<bool, string> IndividualRestore(string slnFileName, string selfTesterRootPath,
         string srcEtalon)
      {
         var pathDirs = slnFileName.Split(Path.DirectorySeparatorChar);
         var projectFolder = string.Empty;
         var etalonProjectFolder = string.Empty;

         for (var i = 0; i < pathDirs.Length; i++)
         {
            if (pathDirs[i].Equals("src", StringComparison.CurrentCultureIgnoreCase))
            {
               var separator = Path.DirectorySeparatorChar.ToString(CultureInfo.InvariantCulture);
               projectFolder = string.Join(separator, pathDirs, 0, i + 2);
               pathDirs[i] = srcEtalon;
               etalonProjectFolder = string.Join(separator, pathDirs, 0, i + 2);
               break;
            }
         }

         if (!string.IsNullOrEmpty(projectFolder))
         {
            var cmdPath = string.Format("{0}{1}cmd.exe", Environment.SystemDirectory, Path.DirectorySeparatorChar);
            var robocopyCmd = new Process
            {
               StartInfo =
               {
                  FileName = cmdPath,
                  WorkingDirectory = selfTesterRootPath,
                  Arguments =
                     string.Format(
                        "/c del /S /Q /F \"{0}\\*.vcxproj*\" & ROBOCOPY \"{1}\" \"{0}\" *.sln *.vcproj *.vcxproj *.props *.vsprops *.cbproj *.groupproj /s /IS",
                        projectFolder, etalonProjectFolder),
                  WindowStyle = ProcessWindowStyle.Hidden
               }
            };
            robocopyCmd.Start();
            robocopyCmd.WaitForExit();

            var exitCode = (RobocopyExitCode)robocopyCmd.ExitCode;
            var meanings =
               exitCode.GetEnumValues<RobocopyExitCode>()
                  .Where(robocopyExitCode => exitCode.HasFlag(robocopyExitCode))
                  .Select(robocopyExitCode => robocopyExitCode.GetRobocopyExitCodeMeaning())
                  .ToList()
                  .Aggregate(string.Format("Possible robocopy exit code meanings: {0}", Environment.NewLine),
                     (current, possibleMeaning) =>
                        string.Format("{0}{1}", current, ("- " + possibleMeaning + Environment.NewLine)));
            // var robocopyError = exitCode.HasFlag(RobocopyExitCode.CopyErrors) || exitCode.HasFlag(RobocopyExitCode.SeriousError);
            return Tuple.Create(exitCode.CompareTo(RobocopyExitCodeExtensions.FailureThreshold) <= 0, meanings);
         }

         return Tuple.Create(false, string.Format("Project folder {0} is empty", projectFolder));
      }

      /// <summary>
      ///    ���������� ����������� �� ����� ����� ��������� �������
      /// </summary>
      /// <param name="launchPartyFolderName">��� ����� ��������� �������</param>
      /// <param name="machineName">��� ������, �� ������� ������������ ������</param>
      /// <param name="testingDateTime">���� � ����� �������</param>
      public static void ExtractLaunchPartyComponents(string launchPartyFolderName, out string machineName,
         out DateTime testingDateTime)
      {
         if (string.IsNullOrWhiteSpace(launchPartyFolderName))
            throw new FailDirPatternComponentsException("dirPattern is null or empty",
               new ArgumentException("dirPattern"));

         var components = launchPartyFolderName.Split('@');
         if (components.Length != 2)
            throw new FailDirPatternComponentsException(
               string.Format("{0} does not contains all needed components", launchPartyFolderName),
               new ArgumentException("dirPattern"));

         machineName = components[0];
         if (string.IsNullOrEmpty(components[1]) ||
             !DateTime.TryParse(components[1].Replace('_', ':').Replace('#', 'T'), out testingDateTime))
            throw new FailDirPatternComponentsException(string.Format("Fail datetime {0}", components[1]),
               new ArgumentException("testingDateTime"));
      }

      /// <summary>
      ///    ���-�� ���������� ����� �� �����
      /// </summary>
      /// <returns>���-�� ���������� ����� �� �����</returns>
      /// <remarks>��� �������� ����������� ����� (� ��)</remarks>
      public static decimal GetCurrentFreeSpace()
      {
         var pathRoot = Path.GetPathRoot(AppDomain.CurrentDomain.BaseDirectory);
         var installedDrive = DriveInfo.GetDrives().First(info => info.Name == pathRoot);
         return installedDrive.AvailableFreeSpace / ((decimal)0x40000000);
      }

      /// <summary>
      ///    ������� �������� �� ���������� PC
      /// </summary>
      public static void ShutdownPc()
      {
         Process.Start("shutdown", "/s /t 0");
      }

      #endregion

      #region ��������� ��������� ������

      /// <summary>
      ///    ���������� VS-������� � �������
      /// </summary>
      /// <param name="solutionFileName">���� VS-�������</param>
      /// <param name="visualStudioPath">���� � devenv.exe</param>
      /// <param name="selfTesterRootPath">�������� ������� �������</param>
      /// <param name="srcEtalonFolder">��� ���������� � ���������� �����������</param>
      private static void PrepareSolution(string solutionFileName, string visualStudioPath, string selfTesterRootPath,
         string srcEtalonFolder)
      {
         IndividualRestore(solutionFileName, selfTesterRootPath, srcEtalonFolder);
         var devenvProcess = new Process
         {
            StartInfo =
            {
               FileName = string.Format("{0}{1}devenv.exe", visualStudioPath, Path.DirectorySeparatorChar),
               Arguments = string.Format("/Upgrade \"{0}\"", solutionFileName)
            }
         };
         devenvProcess.Start();
         devenvProcess.WaitForExit();
      }

      private static void FilterLogs(ISet<string> logsToReplace, IEnumerable<SolutionInfoViewModel> solutions)
      {
         var solutionLogSet = new HashSet<string>();
         foreach (var solutionLog in
            solutions.Select(
               solution =>
                  Path.GetFileNameWithoutExtension(solution.SolutionFileName) +
                  CoreExtensions.EtalonLogExt))
         {
            solutionLogSet.Add(solutionLog);
         }

         var logsToRemove = new HashSet<string>();
         foreach (var replaceLog in from replaceLog in logsToReplace
                                    let logFileName = Path.GetFileName(replaceLog)
                                    where !solutionLogSet.Contains(logFileName)
                                    select replaceLog)
         {
            logsToRemove.Add(replaceLog);
         }

         logsToReplace.ExceptWith(logsToRemove);
      }

      public static Task<Tuple<StartupConfigurationMode, SolutionInfoViewModel>[]> FilterSolutionsAsync(
         IEnumerable<Tuple<StartupConfigurationMode, SolutionInfoViewModel>> selectedSolutions,
         AnalysisStatus filterStatus)
      {
         return Task.Run(() => FilterSolutions(selectedSolutions, filterStatus));
      }

      private static Tuple<StartupConfigurationMode, SolutionInfoViewModel>[] FilterSolutions(
         IEnumerable<Tuple<StartupConfigurationMode, SolutionInfoViewModel>> selectedSolutions,
         AnalysisStatus filterStatus)
      {
         var filtered = new List<Tuple<StartupConfigurationMode, SolutionInfoViewModel>>();

         foreach (var solution in selectedSolutions)
         {
            var configMode = solution.Item1;
            var vm = solution.Item2;

            switch (configMode)
            {
               case StartupConfigurationMode.PvsVs2010:
                  if (vm.LaunchStatusOnPvsVs2010 == filterStatus)
                  {
                     filtered.Add(solution);
                  }
                  break;

               case StartupConfigurationMode.PvsVs2012:
                  if (vm.LaunchStatusOnPvsVs2012 == filterStatus)
                  {
                     filtered.Add(solution);
                  }
                  break;

               case StartupConfigurationMode.PvsVs2013:
                  if (vm.LaunchStatusOnPvsVs2013 == filterStatus)
                  {
                     filtered.Add(solution);
                  }
                  break;

               case StartupConfigurationMode.PvsVs2015:
                  if (vm.LaunchStatusOnPvsVs2015 == filterStatus)
                  {
                     filtered.Add(solution);
                  }
                  break;
            }
         }

         return filtered.ToArray();
      }

      #endregion

      /// <summary>
      ///    ������ � ���������� ������������� ������ ������
      /// </summary>
      /// <param name="snapshotFile">���� ��� ����������</param>
      /// <remarks>����������� ������� - png ����</remarks>
      /// <exception cref="Win32Exception">��������� ��������</exception>
      public static void GetScreenSnapshot(string snapshotFile)
      {
         if (File.Exists(snapshotFile))
            return;

         using (
            var screenCaptureBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
               Screen.PrimaryScreen.Bounds.Height))
         using (var gContext = Graphics.FromImage(screenCaptureBitmap))
         {
            gContext.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0,
               screenCaptureBitmap.Size, CopyPixelOperation.SourceCopy);
            screenCaptureBitmap.Save(snapshotFile, ImageFormat.Png);
         }
      }

      public static bool IsFileLocked(this FileInfo file)
      {
         FileStream stream = null;

         try
         {
            stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
         }
         catch (IOException)
         {
            return true;
         }
         finally
         {
            if (stream != null)
               stream.Close();
         }

         return false;
      }

      public static bool WaitForFileReleased(string aFileName, DateTime start, TimeSpan deltaQuota)
      {
         var fileInfo = new FileInfo(aFileName);
         while (fileInfo.IsFileLocked())
         {
            var delta = DateTime.Now.Subtract(start).Duration();
            if (delta > deltaQuota)
            {
               return false;
            }

            Thread.Sleep(TimeSpan.FromSeconds(5));
         }

         return true;
      }
   }
}