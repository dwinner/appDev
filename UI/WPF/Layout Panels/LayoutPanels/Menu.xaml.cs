using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace LayoutPanels
{
   public partial class Window1
   {
      public Window1()
      {
         InitializeComponent();
      }

      private void ButtonClick(object sender, RoutedEventArgs e)
      {
         var cmd = (Button)e.OriginalSource; // �������� ������� ������� ������
         Type type = GetType();  // ������� ��������� ����, ��������� ������� �������
         Assembly assembly = type.Assembly;
         var win = (Window)assembly.CreateInstance(string.Format("{0}.{1}", type.Namespace, cmd.Content));

         if (win != null)
            win.ShowDialog(); // �������� ����
      }
   }
}