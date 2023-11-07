using System;
using System.IO;

public partial class Default : System.Web.UI.Page
{
   public Default()
   {
      // ���� ������������� � �������� Load � Unload. �� ������� �� �������� AutoEventWireup
      Load += Page_Load;
      Unload += Page_Unload;
      Error += _Default_Error;
   }

   void _Default_Error(object sender, EventArgs e)
   {
      Response.Clear();
      Response.Write("I am sorry...I can't find a required file.<br>");
      Response.Write(string.Format("The error was: <b>{0}</b>",
          Server.GetLastError().Message));
      Server.ClearError();
   }

   protected void Page_Load(object sender, EventArgs e)
   {
      Response.Write("Load event fired!");
   }

   protected void Page_Unload(object sender, EventArgs e)
   {
      // ������ ������ ��������� ������ � ����� HTTP, ������� ����� ������ � ��������� ����      
      // File.WriteAllText(Request.Path, "Page unloading");      
   }

   protected void btnPostback_Click(object sender, EventArgs e)
   {
      // ����� ������ �� ����������; ��� �����, ����� ���������� �������� �������� ��������
   }

   protected void btnTriggerError_Click(object sender, EventArgs e)
   {
      File.ReadAllText(@"C:\IDontExist.txt");
   }
}