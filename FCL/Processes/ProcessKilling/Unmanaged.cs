using System;
using System.Runtime.InteropServices;

namespace Killing
{
   /// <summary>
   ///    "�������������" ������
   /// </summary>
   public static class Unmanaged
   {
      /// <summary>
      ///    �������������� ���������� �������� Win32-�������� TerminateProcess
      /// </summary>
      /// <param name="hProcess">���������� ��������</param>
      /// <param name="uExitCode">��� ����������</param>
      /// <returns>true, ���� ������ ����������, false-� ��������� ������</returns>
      [DllImport("kernel32.dll", SetLastError = true)]
      [return: MarshalAs(UnmanagedType.Bool)]
      public static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);
   }
}