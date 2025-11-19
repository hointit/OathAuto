// Decompiled with JetBrains decompiler
// Type: SmartBot.frmProfileManager
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using EXControls;
using GAuto_Auto_None.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace SmartBot;

public class frmProfileManager : Form
{
  private bool updateLVFlag;
  private EXListView exlvAllProfiles;
  private long moveStamp;
  private int CurrentSelectIndex = -1;
  private IContainer components;
  private TextBox tboxUsername;
  private ComboBox cboNPH;
  private Button btnThemProfile;
  private Button btnEditProfile;
  private Label label2;
  private Label label9;
  private Label lblAgreement;
  private Label lblAgreementTitle;
  private Label label4;
  private TextBox tboxPassword;
  private CheckBox cboxAgreement;
  private Label label5;
  private Label label6;
  private ComboBox cboServer;
  private Button btnDelProfile;
  private ComboBox cboHopKiem;
  private System.Windows.Forms.Timer timer1;
  private ColumnHeader columnHeader2;
  private ColumnHeader columnHeader1;
  private ColumnHeader columnHeader3;
  private ColumnHeader columnHeader4;
  private ColumnHeader columnHeader5;
  private Label label1;
  private TextBox tboxName;
  private ListViewEx lvAllProfiles;
  private Button btnMoveUp;
  private Button btnMoveDown;
  private ColumnHeader columnHeader6;
  private ColumnHeader columnHeader7;
  private ColumnHeader columnHeader8;
  private ColumnHeader columnHeader9;
  private ColumnHeader columnHeader10;
  private Label label3;
  private TextBox tboxGameFile;
  private Button btnBrowseVNG;
  private DataGridView dataGridView1;
  private DataGridViewImageColumn dataGridViewImageColumn1;
  private ContextMenuStrip GLoginContextMenu;
  private ToolStripMenuItem mởGameTấtCảCácProfileNàyToolStripMenuItem;
  private ToolStripMenuItem gửiMãCaptchaChoCácProfileNàyToolStripMenuItem;
  private DataGridViewTextBoxColumn colUsername;
  private DataGridViewTextBoxColumn colNPH;
  private DataGridViewTextBoxColumn colServer;
  private DataGridViewTextBoxColumn colHopKiem;
  private DataGridViewTextBoxColumn colTenNV;
  private DataGridViewImageColumn colCaptcha;
  private DataGridViewButtonColumn NewCaptcha;
  private DataGridViewTextBoxColumn colCaptcha2;
  private DataGridViewCheckBoxColumn colLoginCbox;
  private DataGridViewButtonColumn colButtonLogin;

  public frmProfileManager() => this.InitializeComponent();

  private void frmProfileManager_Load(object sender, EventArgs e)
  {
  }

  private void btnGetCurrentPos_Click(object sender, EventArgs e) => this.RepopulateProfile();

  private void cboNPH_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void cboxAgreement_CheckedChanged(object sender, EventArgs e)
  {
    CheckBox checkBox = sender as CheckBox;
    if (!checkBox.Focused)
      return;
    frmLogin.GAuto.Settings.cboxAgreement = checkBox.Checked;
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if (frmLogin.GlobalTimer.ElapsedMilliseconds - frmLogin.GLoginUpdateStamp >= 5000L || frmLogin.GLoginUpdateStamp == 0L)
    {
      frmLogin.GLoginUpdateStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
      bool flag = true;
      try
      {
        if (frmLogin.GAuto.Settings.ListLoginProfile.Count > 0)
        {
          if (frmLogin.GAuto.AllAutoAccounts.Count > 0)
          {
            for (int index1 = 0; index1 < frmLogin.GAuto.Settings.ListLoginProfile.Count; ++index1)
            {
              if (frmLogin.GAuto.Settings.ListLoginProfile[index1].RefAutoAccount == null && (frmLogin.GAuto.Settings.ListLoginProfile[index1].ProcessID != 0 && !flag || flag))
              {
                for (int index2 = frmLogin.GAuto.AllAutoAccounts.Count - 1; index2 >= 0; --index2)
                {
                  if (frmLogin.GAuto.AllAutoAccounts[index2].MyFlag.IsInGame && string.Compare(frmLogin.GAuto.AllAutoAccounts[index2].Myself.Username, frmLogin.GAuto.Settings.ListLoginProfile[index1].Username, true) == 0 && (frmLogin.GAuto.Settings.ListLoginProfile[index1].NPHShortName == "VNG" && frmLogin.GAuto.AllAutoAccounts[index2].Target.VersionNum <= 2 || frmLogin.GAuto.Settings.ListLoginProfile[index1].NPHShortName == "TK" && frmLogin.GAuto.AllAutoAccounts[index2].Target.VersionNum == 3 || (frmLogin.GAuto.Settings.ListLoginProfile[index1].NPHShortName == "OT" || frmLogin.GAuto.Settings.ListLoginProfile[index1].NPHShortName == "Server khác") && frmLogin.GAuto.AllAutoAccounts[index2].Target.VersionNum > 3) && (frmLogin.GAuto.AllAutoAccounts[index2].Target.ProcessID == frmLogin.GAuto.Settings.ListLoginProfile[index1].ProcessID && !flag || flag))
                  {
                    frmLogin.GAuto.Settings.ListLoginProfile[index1].RefAutoAccount = frmLogin.GAuto.AllAutoAccounts[index2];
                    frmLogin.GAuto.AllAutoAccounts[index2].AutoProfile = frmLogin.GAuto.Settings.ListLoginProfile[index1];
                    frmLogin.GAuto.AllAutoAccounts[index2].Target.GLoginAttached = true;
                  }
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
    }
    if (!this.cboxAgreement.Focused)
      this.cboxAgreement.Checked = frmLogin.GAuto.Settings.cboxAgreement;
    if (frmLogin.GAuto.Settings.cboxAgreement)
    {
      this.lblAgreement.ForeColor = Color.RosyBrown;
      this.lblAgreementTitle.ForeColor = Color.RosyBrown;
      this.cboxAgreement.ForeColor = Color.Gainsboro;
      this.cboxAgreement.Enabled = false;
    }
    if (this.dataGridView1.Rows.Count < frmLogin.GAuto.Settings.ListLoginProfile.Count)
    {
      foreach (LoginProfileClass loginProfileClass in (List<LoginProfileClass>) frmLogin.GAuto.Settings.ListLoginProfile)
      {
        try
        {
          bool flag = true;
          foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
          {
            if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == loginProfileClass.Username && row.Cells[1].Value != null && row.Cells[1].Value.ToString() == loginProfileClass.NPHShortName)
            {
              flag = false;
              break;
            }
          }
          if (this.dataGridView1.Rows.Count == 0)
            flag = true;
          if (flag)
          {
            this.dataGridView1.Rows.Add();
            DataGridViewRow row = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1];
            row.Cells[0].Value = (object) loginProfileClass.Username;
            row.Cells[1].Value = (object) loginProfileClass.NPHShortName;
            row.Cells[2].Value = (object) loginProfileClass.Server;
            row.Cells[3].Value = (object) loginProfileClass.MinorServer;
            row.Cells[4].Value = (object) loginProfileClass.CharName;
          }
        }
        catch (Exception ex)
        {
        }
      }
    }
    else if (this.dataGridView1.Rows.Count > frmLogin.GAuto.Settings.ListLoginProfile.Count)
    {
      try
      {
        for (int index = this.dataGridView1.Rows.Count - 1; index >= 0; --index)
        {
          bool flag = true;
          DataGridViewRow row = this.dataGridView1.Rows[index];
          foreach (LoginProfileClass loginProfileClass in (List<LoginProfileClass>) frmLogin.GAuto.Settings.ListLoginProfile)
          {
            if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == loginProfileClass.Username && row.Cells[1].Value != null)
            {
              if (row.Cells[1].Value.ToString() == loginProfileClass.NPHShortName)
                break;
            }
            if (flag)
              this.dataGridView1.Rows.RemoveAt(index);
          }
        }
      }
      catch (Exception ex)
      {
      }
    }
    if (this.dataGridView1.Rows.Count != frmLogin.GAuto.Settings.ListLoginProfile.Count)
      return;
    try
    {
      for (int index = this.dataGridView1.Rows.Count - 1; index >= 0; --index)
      {
        DataGridViewRow row = this.dataGridView1.Rows[index];
        if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() != frmLogin.GAuto.Settings.ListLoginProfile[index].Username)
          row.Cells[0].Value = (object) frmLogin.GAuto.Settings.ListLoginProfile[index].Username;
        if (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != frmLogin.GAuto.Settings.ListLoginProfile[index].NPHShortName)
          row.Cells[1].Value = (object) frmLogin.GAuto.Settings.ListLoginProfile[index].NPHShortName;
        if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() != frmLogin.GAuto.Settings.ListLoginProfile[index].Server)
          row.Cells[2].Value = (object) frmLogin.GAuto.Settings.ListLoginProfile[index].Server;
        if (row.Cells[3].Value != null && row.Cells[3].Value.ToString() != frmLogin.GAuto.Settings.ListLoginProfile[index].MinorServer)
          row.Cells[3].Value = (object) frmLogin.GAuto.Settings.ListLoginProfile[index].MinorServer;
        if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() != frmLogin.GAuto.Settings.ListLoginProfile[index].CharName)
          row.Cells[4].Value = (object) frmLogin.GAuto.Settings.ListLoginProfile[index].CharName;
        if (frmLogin.GAuto.Settings.ListLoginProfile[index].RefAutoAccount != null)
        {
          AutoAccount refAutoAccount = frmLogin.GAuto.Settings.ListLoginProfile[index].RefAutoAccount;
          lock (refAutoAccount.MyFlag.CaptchaLock)
          {
            if (refAutoAccount.MyFlag.CaptchaNumStamp != 0L)
            {
              if (frmLogin.GlobalTimer.ElapsedMilliseconds - refAutoAccount.MyFlag.CaptchaNumStamp <= 10000L)
              {
                if (frmLogin.GlobalTimer.ElapsedMilliseconds - refAutoAccount.MyFlag.CaptchaNumStamp >= 10L)
                {
                  if (refAutoAccount.MyFlag.CaptchaNumRefresh)
                  {
                    string picData = GA.CaptchaPacketProc(refAutoAccount.MyFlag.CaptchaNum);
                    PictureBox picBox = new PictureBox();
                    GA.PlotCaptchaNum(picData, picBox);
                    row.Cells[5].Value = (object) picBox.Image;
                    refAutoAccount.MyFlag.CaptchaNumRefresh = false;
                    refAutoAccount.MyFlag.CaptchaNumStamp = 0L;
                    row.Cells[7].Value = (object) frmMain.langGLoginNhapMa;
                  }
                }
              }
            }
          }
          if (refAutoAccount.MyFlag.IsInGame)
          {
            row.Cells[8].Value = (object) true;
            if (row.Cells[7].Value == null || row.Cells[7].Value != null && row.Cells[7].Value.ToString() != frmMain.langGLoginNhapMa)
              (row.Cells[5] as DataGridViewImageCell).Value = (object) Resources.captchaplace;
            row.Cells[7].Value = (object) frmMain.langGLoginNhapMa;
          }
          else
            row.Cells[8].Value = (object) false;
        }
        else
        {
          if (row.Cells[8].Value != null && (bool) row.Cells[8].Value || row.Cells[8].Value == null)
            row.Cells[8].Value = (object) false;
          if (row.Cells[7].Value != null && row.Cells[7].Value.ToString() != "")
            row.Cells[7].Value = (object) "";
          DataGridViewImageCell cell = row.Cells[5] as DataGridViewImageCell;
          Color pixel = ((Bitmap) cell.Value).GetPixel(10, 10);
          if (pixel.B != (byte) 201 && pixel.G != (byte) 198)
            cell.Value = (object) Resources.captchaplace;
        }
      }
    }
    catch (Exception ex)
    {
      GA.WriteUserLog(frmMain.langErrorGLogin1);
    }
  }

  private void frmProfileManager_Shown(object sender, EventArgs e)
  {
    this.timer1.Enabled = true;
    if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
      return;
    if (frmLogin.GAuto.Settings.CompilingLanguage == "EN")
    {
      this.cboNPH.Items[0] = (object) "D.Oath";
      this.cboNPH.Items[1] = (object) "69Dragon";
      this.cboNPH.Items[2] = (object) "Others";
    }
    else
    {
      if (!(frmLogin.GAuto.Settings.CompilingLanguage == "CN"))
        return;
      this.cboNPH.Items[0] = (object) "CIBMal";
      this.cboNPH.Items[1] = (object) "Changyou";
      this.cboNPH.Items[2] = (object) "Others";
    }
  }

  private void btnThemProfile_Click(object sender, EventArgs e)
  {
    if (this.tboxUsername.Text != "" && this.tboxPassword.Text != "" && frmLogin.GAuto.Settings.cboxAgreement && this.tboxGameFile.Text != null)
    {
      bool flag1 = false;
      if (this.cboNPH.Text == "Vinagame" && this.cboServer.Text != "")
        flag1 = true;
      if ((this.cboNPH.Text == "Tình Kiếm" || this.cboNPH.Text == "69Dragon") && this.cboServer.Text != "")
        flag1 = true;
      if (this.cboNPH.Text == "D.Oath" && this.cboServer.Text != "")
        flag1 = true;
      if (this.cboNPH.Text == "CIBMal" && this.cboServer.Text != "")
        flag1 = true;
      if (this.cboNPH.Text == "Changyou" && this.cboServer.Text != "")
        flag1 = true;
      if ((this.cboNPH.Text == "Server khác" || this.cboNPH.Text == "Others") && this.cboServer.Text != "")
        flag1 = true;
      if (flag1)
      {
        LoginProfileClass loginProfileClass1 = new LoginProfileClass();
        loginProfileClass1.Username = this.tboxUsername.Text;
        loginProfileClass1.Password = GA.ConvertToSecureString(this.tboxPassword.Text);
        loginProfileClass1.Server = this.cboServer.Text;
        loginProfileClass1.NPH = this.cboNPH.Text;
        loginProfileClass1.MinorServer = this.cboHopKiem.Text;
        loginProfileClass1.CharName = this.tboxName.Text;
        loginProfileClass1.GamePath = this.tboxGameFile.Text;
        bool flag2 = false;
        if (frmLogin.GAuto.Settings.ListLoginProfile.Count > 0)
        {
          for (int index = 0; index < frmLogin.GAuto.Settings.ListLoginProfile.Count; ++index)
          {
            LoginProfileClass loginProfileClass2 = frmLogin.GAuto.Settings.ListLoginProfile[index];
            if (loginProfileClass2.Username == loginProfileClass1.Username && loginProfileClass2.NPH == loginProfileClass1.NPH)
            {
              flag2 = true;
              loginProfileClass2.Password = loginProfileClass1.Password;
              loginProfileClass2.Server = loginProfileClass1.Server;
              loginProfileClass2.NPH = loginProfileClass1.NPH;
              loginProfileClass2.MinorServer = loginProfileClass1.MinorServer;
              loginProfileClass2.CharName = loginProfileClass1.CharName;
              loginProfileClass2.GamePath = loginProfileClass1.GamePath;
              frmLogin.frmLoginInstance.ListLoginProfile_OnAdd((object) frmLogin.GAuto.Settings.ListLoginProfile, (EventArgs) null);
              break;
            }
          }
        }
        if (!flag2)
          frmLogin.GAuto.Settings.ListLoginProfile.Add(loginProfileClass1);
      }
      this.updateLVFlag = true;
    }
    if (frmLogin.GAuto.Settings.cboxAgreement)
      return;
    if (frmLogin.GAuto.Settings.CompilingLanguage == "VN")
    {
      int num1 = (int) MessageBox.Show("Để sử dụng tính năng này, bạn phải đồng ý với Điều khoản sử dụng", "Điều khoản sử dụng", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    else
    {
      if (!(frmLogin.GAuto.Settings.CompilingLanguage == "EN"))
        return;
      int num2 = (int) MessageBox.Show("To use this feature, you must read and agree the terms of use.", "Terms of use", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void btnDelProfile_Click(object sender, EventArgs e)
  {
    if (this.dataGridView1.SelectedRows.Count <= 0)
      return;
    for (int index1 = this.dataGridView1.SelectedRows.Count - 1; index1 >= 0; --index1)
    {
      for (int index2 = frmLogin.GAuto.Settings.ListLoginProfile.Count - 1; index2 >= 0; --index2)
      {
        if (this.dataGridView1.SelectedRows[0].Cells[0].Value != null && frmLogin.GAuto.Settings.ListLoginProfile[index2].Username == this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString() && this.dataGridView1.SelectedRows[0].Cells[1].Value != null && frmLogin.GAuto.Settings.ListLoginProfile[index2].NPHShortName == this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString())
        {
          frmLogin.GAuto.Settings.ListLoginProfile.RemoveAt(index2);
          break;
        }
      }
    }
    this.updateLVFlag = true;
    frmLogin.frmLoginInstance.ListLoginProfile_OnAdd((object) frmLogin.GAuto.Settings.ListLoginProfile, (EventArgs) null);
  }

  private void btnMoveUp_Click(object sender, EventArgs e)
  {
    bool flag = false;
    if (this.moveStamp == 0L)
      flag = true;
    else if (frmLogin.GlobalTimer.ElapsedMilliseconds - this.moveStamp > 120L)
      flag = true;
    if (this.dataGridView1.SelectedRows.Count != 1 || !flag)
      return;
    LoginProfileClass tempProfile = (LoginProfileClass) null;
    int myIndex = -1;
    this.GetMyProfileIndex(out tempProfile, out myIndex);
    if (tempProfile == null || myIndex == -1 || myIndex <= 0)
      return;
    frmLogin.GAuto.Settings.ListLoginProfile.RemoveAt(myIndex);
    frmLogin.GAuto.Settings.ListLoginProfile.Insert(myIndex - 1, tempProfile);
    this.dataGridView1.Rows[myIndex - 1].Selected = true;
    this.dataGridView1.Rows[myIndex].Selected = false;
    this.dataGridView1.Select();
    this.dataGridView1.Invalidate();
    this.updateLVFlag = true;
    frmLogin.frmLoginInstance.ListLoginProfile_OnAdd((object) frmLogin.GAuto.Settings.ListLoginProfile, (EventArgs) null);
    this.moveStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
  }

  private int GetMyProfileIndexFromGrid(int gridIndex)
  {
    if (this.dataGridView1.Rows.Count <= 0)
      return -1;
    try
    {
      for (int index = frmLogin.GAuto.Settings.ListLoginProfile.Count - 1; index >= 0; --index)
      {
        if (this.dataGridView1.Rows[gridIndex].Cells[0].Value != null && frmLogin.GAuto.Settings.ListLoginProfile[index].Username == this.dataGridView1.Rows[gridIndex].Cells[0].Value.ToString() && this.dataGridView1.Rows[gridIndex].Cells[1].Value != null && frmLogin.GAuto.Settings.ListLoginProfile[index].NPHShortName == this.dataGridView1.Rows[gridIndex].Cells[1].Value.ToString())
          return index;
      }
    }
    catch (Exception ex)
    {
    }
    return -1;
  }

  private void GetMyProfileIndex(out LoginProfileClass tempProfile, out int myIndex)
  {
    tempProfile = (LoginProfileClass) null;
    myIndex = -1;
    if (this.dataGridView1.SelectedRows.Count <= 0)
      return;
    for (int index = frmLogin.GAuto.Settings.ListLoginProfile.Count - 1; index >= 0; --index)
    {
      if (this.dataGridView1.SelectedRows[0].Cells[0].Value != null && frmLogin.GAuto.Settings.ListLoginProfile[index].Username == this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString() && this.dataGridView1.SelectedRows[0].Cells[1].Value != null && frmLogin.GAuto.Settings.ListLoginProfile[index].NPHShortName == this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString())
      {
        tempProfile = frmLogin.GAuto.Settings.ListLoginProfile[index];
        myIndex = index;
        break;
      }
    }
  }

  private void btnMoveDown_Click(object sender, EventArgs e)
  {
    bool flag = false;
    if (this.moveStamp == 0L)
      flag = true;
    else if (frmLogin.GlobalTimer.ElapsedMilliseconds - this.moveStamp > 120L)
      flag = true;
    if (this.dataGridView1.SelectedRows.Count != 1 || !flag)
      return;
    LoginProfileClass tempProfile = (LoginProfileClass) null;
    int myIndex = -1;
    this.GetMyProfileIndex(out tempProfile, out myIndex);
    if (tempProfile == null || myIndex == -1 || myIndex >= frmLogin.GAuto.Settings.ListLoginProfile.Count - 1)
      return;
    frmLogin.GAuto.Settings.ListLoginProfile.RemoveAt(myIndex);
    frmLogin.GAuto.Settings.ListLoginProfile.Insert(myIndex + 1, tempProfile);
    this.dataGridView1.Rows[myIndex + 1].Selected = true;
    this.dataGridView1.Rows[myIndex].Selected = false;
    this.dataGridView1.Select();
    this.updateLVFlag = true;
    frmLogin.frmLoginInstance.ListLoginProfile_OnAdd((object) frmLogin.GAuto.Settings.ListLoginProfile, (EventArgs) null);
    this.dataGridView1.Invalidate();
    this.moveStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
  }

  private void lvAllProfiles_MouseDoubleClick(object sender, MouseEventArgs e)
  {
    this.RepopulateProfile();
  }

  private void RepopulateProfile()
  {
    if (this.dataGridView1.SelectedRows.Count <= 0)
      return;
    LoginProfileClass tempProfile = (LoginProfileClass) null;
    int myIndex = -1;
    this.GetMyProfileIndex(out tempProfile, out myIndex);
    if (tempProfile == null || myIndex == -1)
      return;
    this.tboxUsername.Text = tempProfile.Username;
    this.tboxPassword.Text = GA.SecureStringToString(tempProfile.Password);
    this.tboxName.Text = tempProfile.CharName;
    this.cboNPH.Text = tempProfile.NPH;
    this.cboServer.Text = tempProfile.Server;
    this.cboHopKiem.Text = tempProfile.MinorServer;
    this.tboxGameFile.Text = tempProfile.GamePath;
  }

  private void btnBrowseVNG_Click(object sender, EventArgs e)
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.Filter = "TLBB Game.exe | Game.exe";
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return;
    this.tboxGameFile.Text = openFileDialog.FileName;
  }

  private void cboServer_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void cboServer_DropDown(object sender, EventArgs e)
  {
    bool flag = true;
    switch (frmLogin.CompilingLanguage)
    {
      case "VN":
        if (frmLogin.TKServers.Count == 0 || frmLogin.VNGServers.Count == 0 || frmLogin.TKMinorServers.Count == 0)
        {
          flag = false;
          break;
        }
        break;
      case "EN":
        if (frmLogin.TKServers.Count == 0 || frmLogin.TKMinorServers.Count == 0 || frmLogin.TLUSServers.Count == 0)
        {
          flag = false;
          break;
        }
        break;
    }
    if (!(this.cboNPH.Text == "Tình Kiếm") && !(this.cboNPH.Text == "69Dragon"))
    {
      if (this.cboNPH.Text == "Vinagame")
      {
        if (!flag)
          return;
        this.cboServer.BeginUpdate();
        this.cboServer.Items.Clear();
        this.cboServer.Items.AddRange((object[]) frmLogin.VNGServers.ToArray());
        this.cboServer.EndUpdate();
        this.cboHopKiem.Text = "";
      }
      else if (this.cboNPH.Text == "D.Oath")
      {
        if (!flag)
          return;
        this.cboServer.BeginUpdate();
        this.cboServer.Items.Clear();
        this.cboServer.Items.AddRange((object[]) frmLogin.TLUSServers.ToArray());
        this.cboServer.EndUpdate();
        this.cboHopKiem.Text = "";
      }
      else
      {
        if (!(this.cboNPH.Text == "Server khác") && !(this.cboNPH.Text == "Others"))
          return;
        this.cboServer.BeginUpdate();
        this.cboServer.Items.Clear();
        this.cboServer.Items.AddRange((object[]) new List<string>()
        {
          "1",
          "2",
          "3",
          "4",
          "5"
        }.ToArray());
        this.cboServer.EndUpdate();
      }
    }
    else if (flag)
    {
      this.cboServer.BeginUpdate();
      this.cboServer.Items.Clear();
      this.cboServer.Items.AddRange((object[]) frmLogin.TKServers.ToArray());
      this.cboServer.EndUpdate();
    }
    else
      frmMain.GetGLoginServers();
  }

  private void cboHopKiem_SelectedIndexChanged(object sender, EventArgs e)
  {
  }

  private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
  {
  }

  private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
  {
    if (e.ColumnIndex < 0 || e.RowIndex < 0)
      return;
    this.RepopulateProfile();
  }

  private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
  {
    if (e.ColumnIndex < 0 || e.RowIndex < 0)
      return;
    this.RepopulateProfile();
  }

  private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
  {
    if (!(((DataGridView) sender).Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0)
      return;
    if (e.ColumnIndex == 9)
    {
      frmLogin.EnumProcessStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
      this.StartGLoginProfile(e.RowIndex);
    }
    if (e.ColumnIndex != 6)
      return;
    int rowIndex = e.RowIndex;
    if (rowIndex < 0 || rowIndex >= frmLogin.GAuto.Settings.ListLoginProfile.Count)
      return;
    LoginProfileClass loginProfileClass = frmLogin.GAuto.Settings.ListLoginProfile[rowIndex];
    if (loginProfileClass.RefAutoAccount == null || loginProfileClass.RefAutoAccount.MyFlag.IsInGame)
      return;
    loginProfileClass.RefAutoAccount.CallInterfaceClick(20);
  }

  private void StartGLoginProfile(int index)
  {
    if (index < 0 || index >= frmLogin.GAuto.Settings.ListLoginProfile.Count)
      return;
    LoginProfileClass profile = frmLogin.GAuto.Settings.ListLoginProfile[index];
    if (!profile.IsHandled)
    {
      if (!profile.NeedHandle)
      {
        try
        {
          if ((profile.NPH == "Tình Kiếm" || profile.NPH == "69Dragon") && frmLogin.TKServers.Count > 0 || profile.NPH == "Server khác" || profile.NPH == "Others" || profile.NPH == "Vinagame" && frmLogin.VNGServers.Count > 0 || profile.NPH == "D.Oath" && frmLogin.TLUSServers.Count > 0 || profile.NPH == "CIBMal" && frmLogin.CIBMalServers.Count > 0 || profile.NPH == "Changyou" && frmLogin.ChangyouServers.Count > 0)
          {
            profile.NeedHandle = true;
            frmGLogin.StartNewGameForProfile(profile);
            return;
          }
          int num = (int) MessageBox.Show(frmMain.langGLoginEmpty, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          return;
        }
        catch (Exception ex)
        {
          return;
        }
      }
    }
    if (this.dataGridView1.Rows[index].Cells[7].Value == null)
      return;
    string str = this.dataGridView1.Rows[index].Cells[7].Value.ToString();
    if (!(str != "") || !(str != "Nhập mã") || !GA.IsDigitsOnly(str))
      return;
    GA.SendMyString(profile.RefAutoAccount.Target.MainWindowHandle, str);
    GA.SendMyKey(profile.RefAutoAccount.Target.MainWindowHandle, 13);
    Thread.Sleep(100);
    profile.RefAutoAccount.CallInterfaceClick(29);
    this.dataGridView1.Rows[index].Cells[7].Value = (object) "";
  }

  private void cboHopKiem_DropDown(object sender, EventArgs e)
  {
    if (this.cboNPH.Text == "Tình Kiếm" || this.cboNPH.Text == "69Dragon")
    {
      this.cboHopKiem.BeginUpdate();
      this.cboHopKiem.Items.Clear();
      this.cboHopKiem.Items.AddRange((object[]) frmLogin.TKMinorServers.ToArray());
      this.cboHopKiem.EndUpdate();
    }
    else
      this.cboHopKiem.Items.Clear();
  }

  private void mởGameTấtCảCácProfileNàyToolStripMenuItem_Click(object sender, EventArgs e)
  {
    this.OpenGame_Captcha();
  }

  private void OpenGame_Captcha(int myRow = -1)
  {
    if (this.dataGridView1.SelectedRows.Count <= 0)
      return;
    frmLogin.EnumProcessStamp = frmLogin.GlobalTimer.ElapsedMilliseconds;
    for (int index1 = 0; index1 < this.dataGridView1.SelectedRows.Count; ++index1)
    {
      int realIndex = -1;
      if (myRow != -1)
        realIndex = myRow;
      if (this.dataGridView1.Rows.Count > 0 && myRow == -1)
      {
        for (int index2 = 0; index2 < this.dataGridView1.Rows.Count; ++index2)
        {
          if (this.dataGridView1.SelectedRows[index1].Cells[0].ToString() == this.dataGridView1.Rows[index2].Cells[0].ToString() && this.dataGridView1.SelectedRows[index1].Cells[1].ToString() == this.dataGridView1.Rows[index2].Cells[1].ToString() && this.dataGridView1.SelectedRows[index1].Cells[4].ToString() == this.dataGridView1.Rows[index2].Cells[4].ToString())
          {
            realIndex = index2;
            break;
          }
        }
      }
      if (realIndex >= 0)
      {
        lock (frmLogin.GLoginLock)
          new Thread((ThreadStart) (() => this.StartGLoginProfile(realIndex))).Start();
      }
    }
  }

  private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
  {
    if (e.Button != MouseButtons.Right)
      return;
    this.GLoginContextMenu.Show((Control) this.dataGridView1, e.Location);
  }

  private void GLoginContextMenu_Opening(object sender, CancelEventArgs e)
  {
    if (this.dataGridView1.SelectedRows.Count <= 0)
      return;
    try
    {
      bool flag = true;
      for (int index1 = 0; index1 < this.dataGridView1.SelectedRows.Count; ++index1)
      {
        int gridIndex = -1;
        if (this.dataGridView1.Rows.Count > 0)
        {
          for (int index2 = 0; index2 < this.dataGridView1.Rows.Count; ++index2)
          {
            if (this.dataGridView1.SelectedRows[index1] == this.dataGridView1.Rows[index2])
            {
              gridIndex = index2;
              break;
            }
          }
        }
        int profileIndexFromGrid = this.GetMyProfileIndexFromGrid(gridIndex);
        if (profileIndexFromGrid > 0 && !frmLogin.GAuto.Settings.ListLoginProfile[profileIndexFromGrid].IsHandled && !frmLogin.GAuto.Settings.ListLoginProfile[profileIndexFromGrid].NeedHandle)
        {
          flag = false;
          break;
        }
      }
      if (!flag)
        this.GLoginContextMenu.Items[1].Enabled = false;
      else
        this.GLoginContextMenu.Items[1].Enabled = true;
    }
    catch (Exception ex)
    {
    }
  }

  private void gửiMãCaptchaChoCácProfileNàyToolStripMenuItem_Click(object sender, EventArgs e)
  {
    this.OpenGame_Captcha();
  }

  private int GetRealIndexFromSelection()
  {
    int indexFromSelection = -1;
    if (this.dataGridView1.Rows.Count > 0 && this.dataGridView1.SelectedRows.Count == 1)
    {
      for (int index = 0; index < this.dataGridView1.Rows.Count; ++index)
      {
        if (this.dataGridView1.SelectedRows[0].Cells[0].ToString() == this.dataGridView1.Rows[index].Cells[0].ToString() && this.dataGridView1.SelectedRows[0].Cells[1].ToString() == this.dataGridView1.Rows[index].Cells[1].ToString() && this.dataGridView1.SelectedRows[0].Cells[4].ToString() == this.dataGridView1.Rows[index].Cells[4].ToString())
        {
          indexFromSelection = index;
          break;
        }
      }
    }
    return indexFromSelection;
  }

  private void dataGridView1_SelectionChanged(object sender, EventArgs e)
  {
    if (this.dataGridView1.SelectedRows.Count > 1)
    {
      this.CurrentSelectIndex = -1;
    }
    else
    {
      int indexFromSelection = this.GetRealIndexFromSelection();
      if (indexFromSelection != -1 && indexFromSelection == this.CurrentSelectIndex + 1 && this.CurrentSelectIndex != -1)
      {
        string str = "";
        if (this.dataGridView1.Rows[this.CurrentSelectIndex].Cells[7].Value != null)
          str = this.dataGridView1.Rows[this.CurrentSelectIndex].Cells[7].Value.ToString();
        bool flag = GA.IsDigitsOnly(str);
        if (str.Length == 4 && flag)
          this.OpenGame_Captcha(this.CurrentSelectIndex);
      }
      this.CurrentSelectIndex = indexFromSelection;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.components = (IContainer) new System.ComponentModel.Container();
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmProfileManager));
    this.tboxUsername = new TextBox();
    this.cboNPH = new ComboBox();
    this.btnThemProfile = new Button();
    this.btnEditProfile = new Button();
    this.label2 = new Label();
    this.label9 = new Label();
    this.lblAgreement = new Label();
    this.lblAgreementTitle = new Label();
    this.label4 = new Label();
    this.tboxPassword = new TextBox();
    this.cboxAgreement = new CheckBox();
    this.label5 = new Label();
    this.label6 = new Label();
    this.cboServer = new ComboBox();
    this.btnDelProfile = new Button();
    this.cboHopKiem = new ComboBox();
    this.timer1 = new System.Windows.Forms.Timer(this.components);
    this.label1 = new Label();
    this.tboxName = new TextBox();
    this.columnHeader1 = new ColumnHeader();
    this.columnHeader2 = new ColumnHeader();
    this.columnHeader3 = new ColumnHeader();
    this.columnHeader4 = new ColumnHeader();
    this.columnHeader5 = new ColumnHeader();
    this.label3 = new Label();
    this.tboxGameFile = new TextBox();
    this.btnBrowseVNG = new Button();
    this.dataGridView1 = new DataGridView();
    this.colUsername = new DataGridViewTextBoxColumn();
    this.colNPH = new DataGridViewTextBoxColumn();
    this.colServer = new DataGridViewTextBoxColumn();
    this.colHopKiem = new DataGridViewTextBoxColumn();
    this.colTenNV = new DataGridViewTextBoxColumn();
    this.colCaptcha = new DataGridViewImageColumn();
    this.NewCaptcha = new DataGridViewButtonColumn();
    this.colCaptcha2 = new DataGridViewTextBoxColumn();
    this.colLoginCbox = new DataGridViewCheckBoxColumn();
    this.colButtonLogin = new DataGridViewButtonColumn();
    this.dataGridViewImageColumn1 = new DataGridViewImageColumn();
    this.btnMoveDown = new Button();
    this.btnMoveUp = new Button();
    this.GLoginContextMenu = new ContextMenuStrip(this.components);
    this.mởGameTấtCảCácProfileNàyToolStripMenuItem = new ToolStripMenuItem();
    this.gửiMãCaptchaChoCácProfileNàyToolStripMenuItem = new ToolStripMenuItem();
    this.lvAllProfiles = new ListViewEx();
    this.columnHeader6 = new ColumnHeader();
    this.columnHeader7 = new ColumnHeader();
    this.columnHeader8 = new ColumnHeader();
    this.columnHeader9 = new ColumnHeader();
    this.columnHeader10 = new ColumnHeader();
    ((ISupportInitialize) this.dataGridView1).BeginInit();
    this.GLoginContextMenu.SuspendLayout();
    this.SuspendLayout();
    this.tboxUsername.BackColor = Color.FromArgb(206, 233, 253);
    this.tboxUsername.ForeColor = Color.Maroon;
    componentResourceManager.ApplyResources((object) this.tboxUsername, "tboxUsername");
    this.tboxUsername.Name = "tboxUsername";
    this.cboNPH.BackColor = Color.FromArgb(206, 233, 253);
    this.cboNPH.DropDownWidth = 186;
    componentResourceManager.ApplyResources((object) this.cboNPH, "cboNPH");
    this.cboNPH.FormattingEnabled = true;
    this.cboNPH.Items.AddRange(new object[3]
    {
      (object) componentResourceManager.GetString("cboNPH.Items"),
      (object) componentResourceManager.GetString("cboNPH.Items1"),
      (object) componentResourceManager.GetString("cboNPH.Items2")
    });
    this.cboNPH.Name = "cboNPH";
    this.cboNPH.SelectedIndexChanged += new EventHandler(this.cboNPH_SelectedIndexChanged);
    this.btnThemProfile.BackColor = Color.FromArgb(210, 249, 213);
    this.btnThemProfile.ForeColor = Color.DarkGreen;
    componentResourceManager.ApplyResources((object) this.btnThemProfile, "btnThemProfile");
    this.btnThemProfile.Name = "btnThemProfile";
    this.btnThemProfile.UseVisualStyleBackColor = false;
    this.btnThemProfile.Click += new EventHandler(this.btnThemProfile_Click);
    componentResourceManager.ApplyResources((object) this.btnEditProfile, "btnEditProfile");
    this.btnEditProfile.BackColor = Color.FromArgb(247, 207, 142);
    this.btnEditProfile.ForeColor = Color.Black;
    this.btnEditProfile.Name = "btnEditProfile";
    this.btnEditProfile.UseVisualStyleBackColor = false;
    this.btnEditProfile.Click += new EventHandler(this.btnGetCurrentPos_Click);
    componentResourceManager.ApplyResources((object) this.label2, "label2");
    this.label2.Name = "label2";
    componentResourceManager.ApplyResources((object) this.label9, "label9");
    this.label9.Name = "label9";
    componentResourceManager.ApplyResources((object) this.lblAgreement, "lblAgreement");
    this.lblAgreement.ForeColor = Color.DarkRed;
    this.lblAgreement.Name = "lblAgreement";
    componentResourceManager.ApplyResources((object) this.lblAgreementTitle, "lblAgreementTitle");
    this.lblAgreementTitle.ForeColor = Color.Red;
    this.lblAgreementTitle.Name = "lblAgreementTitle";
    componentResourceManager.ApplyResources((object) this.label4, "label4");
    this.label4.Name = "label4";
    this.tboxPassword.BackColor = Color.FromArgb(206, 233, 253);
    this.tboxPassword.ForeColor = Color.Maroon;
    componentResourceManager.ApplyResources((object) this.tboxPassword, "tboxPassword");
    this.tboxPassword.Name = "tboxPassword";
    componentResourceManager.ApplyResources((object) this.cboxAgreement, "cboxAgreement");
    this.cboxAgreement.BackColor = Color.Transparent;
    this.cboxAgreement.ForeColor = Color.Black;
    this.cboxAgreement.Name = "cboxAgreement";
    this.cboxAgreement.UseVisualStyleBackColor = false;
    this.cboxAgreement.CheckedChanged += new EventHandler(this.cboxAgreement_CheckedChanged);
    componentResourceManager.ApplyResources((object) this.label5, "label5");
    this.label5.Name = "label5";
    componentResourceManager.ApplyResources((object) this.label6, "label6");
    this.label6.Name = "label6";
    this.cboServer.BackColor = Color.FromArgb(206, 233, 253);
    this.cboServer.DropDownWidth = 186;
    componentResourceManager.ApplyResources((object) this.cboServer, "cboServer");
    this.cboServer.FormattingEnabled = true;
    this.cboServer.Name = "cboServer";
    this.cboServer.DropDown += new EventHandler(this.cboServer_DropDown);
    this.cboServer.SelectedIndexChanged += new EventHandler(this.cboServer_SelectedIndexChanged);
    componentResourceManager.ApplyResources((object) this.btnDelProfile, "btnDelProfile");
    this.btnDelProfile.BackColor = Color.FromArgb(247, 207, 142);
    this.btnDelProfile.ForeColor = Color.Black;
    this.btnDelProfile.Name = "btnDelProfile";
    this.btnDelProfile.UseVisualStyleBackColor = false;
    this.btnDelProfile.Click += new EventHandler(this.btnDelProfile_Click);
    this.cboHopKiem.BackColor = Color.FromArgb(206, 233, 253);
    this.cboHopKiem.DropDownWidth = 186;
    componentResourceManager.ApplyResources((object) this.cboHopKiem, "cboHopKiem");
    this.cboHopKiem.FormattingEnabled = true;
    this.cboHopKiem.Name = "cboHopKiem";
    this.cboHopKiem.DropDown += new EventHandler(this.cboHopKiem_DropDown);
    this.cboHopKiem.SelectedIndexChanged += new EventHandler(this.cboHopKiem_SelectedIndexChanged);
    this.timer1.Interval = 400;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    componentResourceManager.ApplyResources((object) this.label1, "label1");
    this.label1.Name = "label1";
    this.tboxName.BackColor = Color.FromArgb(206, 233, 253);
    this.tboxName.ForeColor = Color.Maroon;
    componentResourceManager.ApplyResources((object) this.tboxName, "tboxName");
    this.tboxName.Name = "tboxName";
    componentResourceManager.ApplyResources((object) this.columnHeader1, "columnHeader1");
    componentResourceManager.ApplyResources((object) this.columnHeader2, "columnHeader2");
    componentResourceManager.ApplyResources((object) this.columnHeader3, "columnHeader3");
    componentResourceManager.ApplyResources((object) this.columnHeader4, "columnHeader4");
    componentResourceManager.ApplyResources((object) this.columnHeader5, "columnHeader5");
    componentResourceManager.ApplyResources((object) this.label3, "label3");
    this.label3.Name = "label3";
    this.tboxGameFile.BackColor = Color.FromArgb(206, 233, 253);
    this.tboxGameFile.ForeColor = Color.Maroon;
    componentResourceManager.ApplyResources((object) this.tboxGameFile, "tboxGameFile");
    this.tboxGameFile.Name = "tboxGameFile";
    componentResourceManager.ApplyResources((object) this.btnBrowseVNG, "btnBrowseVNG");
    this.btnBrowseVNG.Name = "btnBrowseVNG";
    this.btnBrowseVNG.UseVisualStyleBackColor = true;
    this.btnBrowseVNG.Click += new EventHandler(this.btnBrowseVNG_Click);
    this.dataGridView1.AllowUserToAddRows = false;
    this.dataGridView1.AllowUserToResizeRows = false;
    componentResourceManager.ApplyResources((object) this.dataGridView1, "dataGridView1");
    this.dataGridView1.BackgroundColor = Color.WhiteSmoke;
    this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
    this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.colUsername, (DataGridViewColumn) this.colNPH, (DataGridViewColumn) this.colServer, (DataGridViewColumn) this.colHopKiem, (DataGridViewColumn) this.colTenNV, (DataGridViewColumn) this.colCaptcha, (DataGridViewColumn) this.NewCaptcha, (DataGridViewColumn) this.colCaptcha2, (DataGridViewColumn) this.colLoginCbox, (DataGridViewColumn) this.colButtonLogin);
    this.dataGridView1.GridColor = SystemColors.ControlLight;
    this.dataGridView1.Name = "dataGridView1";
    this.dataGridView1.RowHeadersVisible = false;
    this.dataGridView1.RowTemplate.Height = 36;
    this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
    this.dataGridView1.CellContentDoubleClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
    this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
    this.dataGridView1.SelectionChanged += new EventHandler(this.dataGridView1_SelectionChanged);
    this.dataGridView1.MouseClick += new MouseEventHandler(this.dataGridView1_MouseClick);
    this.dataGridView1.MouseDoubleClick += new MouseEventHandler(this.dataGridView1_MouseDoubleClick);
    componentResourceManager.ApplyResources((object) this.colUsername, "colUsername");
    this.colUsername.Name = "colUsername";
    this.colUsername.ReadOnly = true;
    componentResourceManager.ApplyResources((object) this.colNPH, "colNPH");
    this.colNPH.Name = "colNPH";
    this.colNPH.ReadOnly = true;
    componentResourceManager.ApplyResources((object) this.colServer, "colServer");
    this.colServer.Name = "colServer";
    this.colServer.ReadOnly = true;
    componentResourceManager.ApplyResources((object) this.colHopKiem, "colHopKiem");
    this.colHopKiem.Name = "colHopKiem";
    this.colHopKiem.ReadOnly = true;
    componentResourceManager.ApplyResources((object) this.colTenNV, "colTenNV");
    this.colTenNV.Name = "colTenNV";
    this.colTenNV.ReadOnly = true;
    componentResourceManager.ApplyResources((object) this.colCaptcha, "colCaptcha");
    this.colCaptcha.Image = (Image) Resources.captchaplace;
    this.colCaptcha.Name = "colCaptcha";
    this.colCaptcha.ReadOnly = true;
    componentResourceManager.ApplyResources((object) this.NewCaptcha, "NewCaptcha");
    this.NewCaptcha.Name = "NewCaptcha";
    this.NewCaptcha.Text = "Mã mới";
    this.NewCaptcha.UseColumnTextForButtonValue = true;
    componentResourceManager.ApplyResources((object) this.colCaptcha2, "colCaptcha2");
    this.colCaptcha2.Name = "colCaptcha2";
    componentResourceManager.ApplyResources((object) this.colLoginCbox, "colLoginCbox");
    this.colLoginCbox.Name = "colLoginCbox";
    componentResourceManager.ApplyResources((object) this.colButtonLogin, "colButtonLogin");
    this.colButtonLogin.Name = "colButtonLogin";
    this.colButtonLogin.Text = "Mở/Vào Game";
    this.colButtonLogin.UseColumnTextForButtonValue = true;
    componentResourceManager.ApplyResources((object) this.dataGridViewImageColumn1, "dataGridViewImageColumn1");
    this.dataGridViewImageColumn1.Image = (Image) Resources.captchaplace;
    this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
    this.dataGridViewImageColumn1.ReadOnly = true;
    componentResourceManager.ApplyResources((object) this.btnMoveDown, "btnMoveDown");
    this.btnMoveDown.BackColor = Color.Transparent;
    this.btnMoveDown.ForeColor = SystemColors.ButtonFace;
    this.btnMoveDown.Image = (Image) Resources.download;
    this.btnMoveDown.Name = "btnMoveDown";
    this.btnMoveDown.UseVisualStyleBackColor = false;
    this.btnMoveDown.Click += new EventHandler(this.btnMoveDown_Click);
    componentResourceManager.ApplyResources((object) this.btnMoveUp, "btnMoveUp");
    this.btnMoveUp.BackColor = Color.Transparent;
    this.btnMoveUp.ForeColor = SystemColors.ButtonFace;
    this.btnMoveUp.Image = (Image) Resources.uparrow;
    this.btnMoveUp.Name = "btnMoveUp";
    this.btnMoveUp.UseVisualStyleBackColor = false;
    this.btnMoveUp.Click += new EventHandler(this.btnMoveUp_Click);
    this.GLoginContextMenu.Items.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.mởGameTấtCảCácProfileNàyToolStripMenuItem,
      (ToolStripItem) this.gửiMãCaptchaChoCácProfileNàyToolStripMenuItem
    });
    this.GLoginContextMenu.Name = "GLoginContextMenu";
    componentResourceManager.ApplyResources((object) this.GLoginContextMenu, "GLoginContextMenu");
    this.GLoginContextMenu.Opening += new CancelEventHandler(this.GLoginContextMenu_Opening);
    this.mởGameTấtCảCácProfileNàyToolStripMenuItem.Name = "mởGameTấtCảCácProfileNàyToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.mởGameTấtCảCácProfileNàyToolStripMenuItem, "mởGameTấtCảCácProfileNàyToolStripMenuItem");
    this.mởGameTấtCảCácProfileNàyToolStripMenuItem.Click += new EventHandler(this.mởGameTấtCảCácProfileNàyToolStripMenuItem_Click);
    this.gửiMãCaptchaChoCácProfileNàyToolStripMenuItem.Name = "gửiMãCaptchaChoCácProfileNàyToolStripMenuItem";
    componentResourceManager.ApplyResources((object) this.gửiMãCaptchaChoCácProfileNàyToolStripMenuItem, "gửiMãCaptchaChoCácProfileNàyToolStripMenuItem");
    this.gửiMãCaptchaChoCácProfileNàyToolStripMenuItem.Click += new EventHandler(this.gửiMãCaptchaChoCácProfileNàyToolStripMenuItem_Click);
    componentResourceManager.ApplyResources((object) this.lvAllProfiles, "lvAllProfiles");
    this.lvAllProfiles.Columns.AddRange(new ColumnHeader[5]
    {
      this.columnHeader6,
      this.columnHeader7,
      this.columnHeader8,
      this.columnHeader9,
      this.columnHeader10
    });
    this.lvAllProfiles.FullRowSelect = true;
    this.lvAllProfiles.GridLines = true;
    this.lvAllProfiles.HideSelection = false;
    this.lvAllProfiles.LineAfter = -1;
    this.lvAllProfiles.LineBefore = -1;
    this.lvAllProfiles.Name = "lvAllProfiles";
    this.lvAllProfiles.UseCompatibleStateImageBehavior = false;
    this.lvAllProfiles.View = View.Details;
    this.lvAllProfiles.MouseDoubleClick += new MouseEventHandler(this.lvAllProfiles_MouseDoubleClick);
    componentResourceManager.ApplyResources((object) this.columnHeader6, "columnHeader6");
    componentResourceManager.ApplyResources((object) this.columnHeader7, "columnHeader7");
    componentResourceManager.ApplyResources((object) this.columnHeader8, "columnHeader8");
    componentResourceManager.ApplyResources((object) this.columnHeader9, "columnHeader9");
    componentResourceManager.ApplyResources((object) this.columnHeader10, "columnHeader10");
    componentResourceManager.ApplyResources((object) this, "$this");
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackColor = Color.WhiteSmoke;
    this.Controls.Add((Control) this.dataGridView1);
    this.Controls.Add((Control) this.btnBrowseVNG);
    this.Controls.Add((Control) this.tboxGameFile);
    this.Controls.Add((Control) this.label3);
    this.Controls.Add((Control) this.lvAllProfiles);
    this.Controls.Add((Control) this.btnMoveDown);
    this.Controls.Add((Control) this.btnMoveUp);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.tboxName);
    this.Controls.Add((Control) this.cboHopKiem);
    this.Controls.Add((Control) this.btnDelProfile);
    this.Controls.Add((Control) this.cboServer);
    this.Controls.Add((Control) this.label6);
    this.Controls.Add((Control) this.label5);
    this.Controls.Add((Control) this.cboxAgreement);
    this.Controls.Add((Control) this.label4);
    this.Controls.Add((Control) this.tboxPassword);
    this.Controls.Add((Control) this.lblAgreementTitle);
    this.Controls.Add((Control) this.lblAgreement);
    this.Controls.Add((Control) this.label9);
    this.Controls.Add((Control) this.tboxUsername);
    this.Controls.Add((Control) this.cboNPH);
    this.Controls.Add((Control) this.btnThemProfile);
    this.Controls.Add((Control) this.btnEditProfile);
    this.Controls.Add((Control) this.label2);
    this.FormBorderStyle = FormBorderStyle.FixedDialog;
    this.HelpButton = true;
    this.Name = nameof (frmProfileManager);
    this.Load += new EventHandler(this.frmProfileManager_Load);
    this.Shown += new EventHandler(this.frmProfileManager_Shown);
    ((ISupportInitialize) this.dataGridView1).EndInit();
    this.GLoginContextMenu.ResumeLayout(false);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
