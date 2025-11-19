// Decompiled with JetBrains decompiler
// Type: CS2PHPCryptography.RSAtoPHPCryptography
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

#nullable disable
namespace CS2PHPCryptography;

public class RSAtoPHPCryptography
{
  private X509Certificate2 cert;
  private bool initialized;

  public RSAtoPHPCryptography(string certificateLocation)
  {
    this.LoadCertificateFromFile(certificateLocation);
  }

  public RSAtoPHPCryptography() => this.initialized = false;

  public void LoadCertificateFromFile(string certificateLocation)
  {
    try
    {
      this.cert = this.GetCertificateFromFile(certificateLocation);
      this.initialized = true;
    }
    catch (Exception ex)
    {
      this.initialized = false;
      throw new CryptographicException("There was an error reading the certificate.", ex);
    }
    if (this.cert.HasPrivateKey)
      throw new CryptographicException("Use a certificate that does not contain a private key for security purposes.");
  }

  public void LoadCertificateFromString(string certificateText)
  {
    try
    {
      this.cert = this.GetCertificate(certificateText);
      this.initialized = true;
    }
    catch (Exception ex)
    {
      this.initialized = false;
      throw new CryptographicException("There was an error reading the certificate.", ex);
    }
    if (this.cert.HasPrivateKey)
      throw new CryptographicException("Use a certificate that does not contain a private key for security purposes.");
  }

  private X509Certificate2 GetCertificate(string key)
  {
    try
    {
      if (key.Contains("-----"))
        key = key.Split(new string[1]{ "-----" }, StringSplitOptions.RemoveEmptyEntries)[1];
      key.Replace("\n", "");
      return new X509Certificate2(Convert.FromBase64String(key));
    }
    catch (Exception ex)
    {
      throw new FormatException("The certificate key was not in the expected format.", ex);
    }
  }

  private X509Certificate2 GetCertificateFromFile(string file)
  {
    return this.GetCertificate(File.ReadAllText(file));
  }

  public byte[] Encrypt(byte[] message)
  {
    if (this.initialized)
      return ((RSACryptoServiceProvider) this.cert.PublicKey.Key).Encrypt(message, false);
    throw new Exception("The RSA engine has not been initialized with a certificate yet.");
  }

  public string Encrypt(string message)
  {
    if (this.initialized)
      return Utility.ToUrlSafeBase64(this.Encrypt(Encoding.ASCII.GetBytes(message)));
    throw new Exception("The RSA engine has not been initialized with a certificate yet.");
  }
}
