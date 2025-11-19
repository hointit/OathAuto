// Decompiled with JetBrains decompiler
// Type: CS2PHPCryptography.SecurePHPConnection
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System.ComponentModel;
using System.Security.Cryptography;

#nullable disable
namespace CS2PHPCryptography;

public class SecurePHPConnection
{
  private string address;
  private bool connected;
  private bool inUse;
  private string asyncResponse;
  private BackgroundWorker background;
  private BackgroundWorker sender;
  private HttpControl http;
  private RSAtoPHPCryptography rsa;
  private AEStoPHPCryptography aes;

  public event SecurePHPConnection.ConnectionEstablishedHandler OnConnectionEstablished;

  public event SecurePHPConnection.ResponseReceivedHandler OnResponseReceived;

  public string PHPScriptLocation => this.address;

  public bool SecureConnectionEstablished => this.connected;

  public bool OKToSendMessage => this.connected && !this.inUse;

  public SecurePHPConnection()
  {
    this.connected = false;
    this.inUse = false;
    this.http = new HttpControl();
    this.rsa = new RSAtoPHPCryptography();
    this.aes = new AEStoPHPCryptography();
    this.background = new BackgroundWorker();
    this.background.DoWork += new DoWorkEventHandler(this.background_DoWork);
    this.background.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.background_RunWorkerCompleted);
    this.sender = new BackgroundWorker();
    this.sender.DoWork += new DoWorkEventHandler(this.sender_DoWork);
    this.sender.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.sender_RunWorkerCompleted);
  }

  public void SetRemotePhpScriptLocation(string phpScriptLocation)
  {
    this.address = phpScriptLocation;
    this.connected = false;
    this.inUse = false;
  }

  private void background_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
  {
    if (!this.connected)
      throw new CryptographicException("There was an error communicating with the PHP script while establishing a secure connection.");
    if (this.OnConnectionEstablished == null)
      return;
    this.OnConnectionEstablished((object) this, new OnConnectionEstablishedEventArgs());
  }

  private void background_DoWork(object sender, DoWorkEventArgs e)
  {
    this.rsa.LoadCertificateFromString(this.http.Post(this.address, "getkey=y"));
    this.aes.GenerateRandomKeys();
    this.connected = this.aes.Decrypt(this.http.Post(this.address, $"key={Utility.ToUrlSafeBase64(this.rsa.Encrypt(this.aes.EncryptionKey))}&iv={Utility.ToUrlSafeBase64(this.rsa.Encrypt(this.aes.EncryptionIV))}")) == "AES OK";
  }

  public void EstablishSecureConnectionAsync()
  {
    if (this.background.IsBusy)
      return;
    this.background.RunWorkerAsync();
  }

  public string SendMessageSecure(string message)
  {
    return this.connected ? this.aes.Decrypt(this.http.Post(this.address, "data=" + this.aes.Encrypt(message))) : "NOT CONNECTED";
  }

  public void CloseConnection()
  {
    this.SendMessageSecureAsync("CLOSE CONNECTION");
    this.connected = false;
  }

  public void SendMessageSecureAsync(string message)
  {
    if (!this.connected || this.inUse)
      return;
    this.sender.RunWorkerAsync((object) message);
  }

  private void sender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
  {
    this.inUse = false;
    if (this.OnResponseReceived == null)
      return;
    this.OnResponseReceived((object) this, new ResponseReceivedEventArgs(this.asyncResponse));
  }

  private void sender_DoWork(object sender, DoWorkEventArgs e)
  {
    this.inUse = true;
    this.asyncResponse = this.SendMessageSecure((string) e.Argument);
  }

  public delegate void ConnectionEstablishedHandler(
    object sender,
    OnConnectionEstablishedEventArgs e);

  public delegate void ResponseReceivedHandler(object sender, ResponseReceivedEventArgs e);
}
