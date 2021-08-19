using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.IO;

namespace NonCompiledXaml
{
   public class Window1 : Window
   {
      private Button _clickmeButton;

      public Window1(string xamlFile)
      {
         InitializeComponent(xamlFile);
      }

      private void InitializeComponent(string xamlFile)
      {
         // ���������������� �����
         Width = Height = 285;
         Left = Top = 100;
         Title = "Dynamically Loaded XAML";

         // �������� ������� XAML �� �������� �����
         DependencyObject rootElement;
         using (var stream = new FileStream(xamlFile, FileMode.Open))
         {
            rootElement = (DependencyObject)XamlReader.Load(stream);
         }

         // �������� �������� � ��� ����
         Content = rootElement;

         // ����� ������� ���������� � ��������������� ������
         var frameworkElement = (FrameworkElement)rootElement;
         _clickmeButton = (Button)frameworkElement.FindName("ClickMeButton");

         // ������������ ���������� �������
         if (_clickmeButton != null)
         {
            _clickmeButton.Click += (sender, e) =>
            {
               _clickmeButton.Content = "Thank you.";
            };
         }
      }
   }
}



