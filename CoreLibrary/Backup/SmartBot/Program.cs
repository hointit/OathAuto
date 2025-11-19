// Decompiled with JetBrains decompiler
// Type: SmartBot.Program
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

internal static class Program
{
  private static Mutex appMutex = new Mutex(true, "40dcf751-e9cb-4819-b060-52715f3a494c");

  [STAThread]
  private static void Main(string[] args)
  {
    try
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new frmLogin());
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.ToString());
    }
  }

  private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
  {
    int num = (int) MessageBox.Show($"Có lỗi, vui lòng chụp hình và gửi GAuto.\n{e.ExceptionObject.ToString()}");
    Thread.CurrentThread.IsBackground = true;
    Thread.CurrentThread.Name = "Dead thread";
    Thread.Sleep(TimeSpan.FromSeconds(1.0));
    GA.ExitAndCleanup();
  }
}
