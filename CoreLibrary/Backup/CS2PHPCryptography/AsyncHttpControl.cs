// Decompiled with JetBrains decompiler
// Type: CS2PHPCryptography.AsyncHttpControl
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.ComponentModel;

#nullable disable
namespace CS2PHPCryptography;

public class AsyncHttpControl
{
  private BackgroundWorker background;
  private string response;
  private bool busy;
  private HttpAsyncInfo request;
  private bool error;
  private HttpControl http;

  public bool IsBusy => this.busy;

  public event AsyncHttpControl.ResponseCallback OnHttpResponse;

  public AsyncHttpControl()
  {
    this.http = new HttpControl();
    this.background = new BackgroundWorker();
    this.background.DoWork += new DoWorkEventHandler(this.background_DoWork);
    this.background.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.background_RunWorkerCompleted);
    this.busy = false;
    this.error = false;
  }

  public bool Get(string url, ProxySettings settings)
  {
    if (this.busy)
      return false;
    this.busy = true;
    this.request = new HttpAsyncInfo();
    this.request.url = url;
    this.request.settings = settings;
    this.background.RunWorkerAsync((object) RequestOption.Get);
    return true;
  }

  public bool Get(string url)
  {
    ProxySettings settings = new ProxySettings()
    {
      UseProxy = false
    };
    return this.Get(url, settings);
  }

  public bool Post(string url, PostPackageBuilder postVars, ProxySettings settings)
  {
    return this.Post(url, postVars.PostDataString, settings);
  }

  public bool Post(string url, PostPackageBuilder postVars)
  {
    ProxySettings settings = new ProxySettings()
    {
      UseProxy = false
    };
    return this.Post(url, postVars.PostDataString, settings);
  }

  public bool Post(string url, string data)
  {
    ProxySettings settings = new ProxySettings()
    {
      UseProxy = false
    };
    return this.Post(url, data, settings);
  }

  public bool Post(string url, string data, ProxySettings settings)
  {
    if (this.busy)
      return false;
    this.busy = true;
    this.request = new HttpAsyncInfo();
    this.request.url = url;
    this.request.settings = settings;
    this.request.data = data;
    this.background.RunWorkerAsync((object) RequestOption.Post);
    return true;
  }

  private void background_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
  {
    if (this.OnHttpResponse == null)
      return;
    this.OnHttpResponse((object) this, new OnHttpResponseEventArgs(this.response, this.error));
    this.busy = false;
  }

  private void background_DoWork(object sender, DoWorkEventArgs e)
  {
    try
    {
      this.error = false;
      switch ((RequestOption) e.Argument)
      {
        case RequestOption.Post:
          this.response = this.http.Post(this.request.url, this.request.data, this.request.settings);
          break;
        case RequestOption.Get:
          this.response = this.http.Get(this.request.url, this.request.settings);
          break;
      }
    }
    catch (Exception ex)
    {
      this.error = true;
      this.response = "Error getting HTTP request: " + ex.Message;
    }
  }

  public delegate void ResponseCallback(object sender, OnHttpResponseEventArgs e);
}
