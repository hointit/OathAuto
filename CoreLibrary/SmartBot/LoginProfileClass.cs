// Decompiled with JetBrains decompiler
// Type: SmartBot.LoginProfileClass
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Security;

#nullable disable
namespace SmartBot;

public class LoginProfileClass : INotifyPropertyChanged
{
  private AutoAccount _refAccount;
  private Image _imgCaptcha;
  private bool _AIEnabled;
  public long clickCaptchaStamp;
  private string _username = "";
  public SecureString Password = new SecureString();
  private string _charName = "";
  private string _captchaCode = "";
  private string _nph = "";
  private string _server = "";
  private string _minorServer = "";
  public int ProcessID;
  public string GameHash = "";
  private string _gamePath = "";
  public bool IsHandled;
  public bool IsAssigned;
  public bool NeedHandle;
  private bool _gameStart;
  public string JustOpen = "Enter";
  public bool InvalidPassword;
  public long stampOpenGame;
  public int flagAI = -1;
  public int retries;
  public long retriesStamp;

  public event PropertyChangedEventHandler PropertyChanged;

  private void RefreshItem()
  {
    if (frmGLogin.instance == null || !frmGLogin.instance.Visible)
      return;
    frmGLogin.instance.listGLogin.RefreshObject((object) this);
  }

  private void NotifyPropertyChanged(string info)
  {
    if (frmMain.frmMainInstance != null && frmMain.frmMainInstance.InvokeRequired)
      frmMain.frmMainInstance.richLog.Invoke((Delegate) (() => this.RefreshItem()));
    else
      this.RefreshItem();
  }

  public LoginProfileClass()
  {
    this.PropertyChanged += new PropertyChangedEventHandler(this.LoginProfileClass_PropertyChanged);
  }

  private void LoginProfileClass_PropertyChanged(object sender, PropertyChangedEventArgs e)
  {
  }

  public AutoAccount RefAutoAccount
  {
    get => this._refAccount;
    set
    {
      if (this._refAccount == value)
        return;
      this._refAccount = value;
      if (value != null)
        return;
      this.imgCaptcha = (Image) null;
      this.GameStarted = false;
      this.flagAI = 0;
      this.NeedHandle = false;
      this.retries = 0;
      this.retriesStamp = 0L;
      this.stampOpenGame = 0L;
    }
  }

  public Image imgCaptcha
  {
    get => this._imgCaptcha;
    set
    {
      if (this._imgCaptcha == value)
        return;
      this._imgCaptcha = value;
      this.NotifyPropertyChanged(nameof (imgCaptcha));
    }
  }

  public bool AIEnabled
  {
    get => this._AIEnabled;
    set
    {
      if (this._AIEnabled == value)
        return;
      this._AIEnabled = value;
      this.NotifyPropertyChanged(nameof (AIEnabled));
    }
  }

  public string Username
  {
    get => this._username;
    set
    {
      if (!(this._username != value))
        return;
      this._username = value;
      this.NotifyPropertyChanged(nameof (Username));
    }
  }

  public string CharName
  {
    get => this._charName;
    set
    {
      if (!(this._charName != value))
        return;
      this._charName = value;
      this.NotifyPropertyChanged(nameof (CharName));
    }
  }

  public string captchaCode
  {
    get => this._captchaCode;
    set
    {
      if (!(this._captchaCode != value) || !(value != "Code..."))
        return;
      this._captchaCode = value;
      this.NotifyPropertyChanged(nameof (captchaCode));
    }
  }

  public string NPH
  {
    get => this._nph;
    set
    {
      if (!(this._nph != value))
        return;
      this._nph = value;
      this.NotifyPropertyChanged(nameof (NPH));
    }
  }

  public string Server
  {
    get => this._server;
    set
    {
      if (!(this._server != value))
        return;
      this._server = value;
      this.NotifyPropertyChanged(nameof (Server));
    }
  }

  public string MinorServer
  {
    get => this._minorServer;
    set
    {
      if (!(this._minorServer != value))
        return;
      this._minorServer = value;
      this.NotifyPropertyChanged(nameof (MinorServer));
    }
  }

  public string GamePath
  {
    get => this._gamePath;
    set
    {
      if (!(this._gamePath != value))
        return;
      this._gamePath = value;
      this.NotifyPropertyChanged(nameof (GamePath));
    }
  }

  public string NPHShortName
  {
    get
    {
      if (this.NPH != "")
      {
        if (this.NPH == "Vinagame")
          return "VNG";
        if (this.NPH == "Tình Kiếm")
          return "TK";
        if (this.NPH == "Song Kiếm")
          return "SK";
        if (this.NPH == "Server khác" || this.NPH == "Others")
          return "OT";
        if (this.NPH == "D.Oath")
          return "DO2";
        if (this.NPH == "69Dragon")
          return "TL69";
        if (this.NPH == "CIBMal")
          return "CM";
        if (this.NPH == "Changyou")
          return "CY";
      }
      return "";
    }
  }

  public bool GameStarted
  {
    get => this._gameStart;
    set
    {
      if (this._gameStart == value)
        return;
      this._gameStart = value;
      this.NotifyPropertyChanged(nameof (GameStarted));
    }
  }
}
