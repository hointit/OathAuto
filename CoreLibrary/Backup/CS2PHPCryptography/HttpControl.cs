// Decompiled with JetBrains decompiler
// Type: CS2PHPCryptography.HttpControl
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.IO;
using System.Net;
using System.Text;

#nullable disable
namespace CS2PHPCryptography;

public class HttpControl
{
  private CookieContainer cookies;

  public HttpControl() => this.cookies = new CookieContainer();

  public string Get(string url, ProxySettings settings)
  {
    HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
    if (settings.UseProxy)
    {
      IWebProxy proxy = httpWebRequest.Proxy;
      httpWebRequest.Proxy = (IWebProxy) new WebProxy()
      {
        Address = new Uri(settings.ProxyAddress),
        Credentials = (ICredentials) new NetworkCredential(settings.ProxyUsername, settings.ProxyPassword)
      };
    }
    httpWebRequest.Method = "GET";
    httpWebRequest.CookieContainer = this.cookies;
    WebResponse response = httpWebRequest.GetResponse();
    StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
    string end = streamReader.ReadToEnd();
    streamReader.Close();
    response.Close();
    return end;
  }

  public string Get(string url)
  {
    ProxySettings settings = new ProxySettings()
    {
      UseProxy = false
    };
    return this.Get(url, settings);
  }

  public string Post(string url, PostPackageBuilder postVars, ProxySettings settings)
  {
    return this.Post(url, postVars.PostDataString, settings);
  }

  public string Post(string url, PostPackageBuilder postVars)
  {
    ProxySettings settings = new ProxySettings()
    {
      UseProxy = false
    };
    return this.Post(url, postVars.PostDataString, settings);
  }

  public string Post(string url, string data)
  {
    ProxySettings settings = new ProxySettings()
    {
      UseProxy = false
    };
    return this.Post(url, data, settings);
  }

  public string Post(string url, string data, ProxySettings settings)
  {
    try
    {
      byte[] bytes = Encoding.ASCII.GetBytes(data);
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
      if (settings.UseProxy)
      {
        IWebProxy proxy = httpWebRequest.Proxy;
        httpWebRequest.Proxy = (IWebProxy) new WebProxy()
        {
          Address = new Uri(settings.ProxyAddress),
          Credentials = (ICredentials) new NetworkCredential(settings.ProxyUsername, settings.ProxyPassword)
        };
      }
      httpWebRequest.Method = "POST";
      httpWebRequest.ContentType = "application/x-www-form-urlencoded";
      httpWebRequest.ContentLength = (long) bytes.Length;
      httpWebRequest.CookieContainer = this.cookies;
      Stream requestStream = httpWebRequest.GetRequestStream();
      requestStream.Write(bytes, 0, bytes.Length);
      requestStream.Close();
      return new StreamReader(httpWebRequest.GetResponse().GetResponseStream()).ReadToEnd();
    }
    catch (Exception ex)
    {
      return "ERROR: " + ex.Message;
    }
  }
}
