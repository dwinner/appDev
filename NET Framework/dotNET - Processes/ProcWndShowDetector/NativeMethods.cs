using System;
using System.Runtime.InteropServices;

namespace ProcWndShowDetector
{
   /// <summary>
   ///     "������" ������
   /// </summary>
   internal static class NativeMethods
   {
      /// <summary>
      ///     ����������, �������� �� ���� �������
      /// </summary>
      /// <param name="hWnd">�������� �������� �����������</param>
      /// <returns>true, ���� ���� ������, false - � ��������� ������</returns>
      [DllImport("user32.dll")]
      [return: MarshalAs(UnmanagedType.Bool)]
      internal static extern bool IsWindowVisible(IntPtr hWnd);
   }
}