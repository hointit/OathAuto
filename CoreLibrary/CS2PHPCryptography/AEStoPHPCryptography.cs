// Decompiled with JetBrains decompiler
// Type: CS2PHPCryptography.AEStoPHPCryptography
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.IO;
using System.Security.Cryptography;

#nullable disable
namespace CS2PHPCryptography;

public class AEStoPHPCryptography
{
  private byte[] Key;
  private byte[] IV;

  public string EncryptionKeyString => Convert.ToBase64String(this.Key);

  public string EncryptionIVString => Convert.ToBase64String(this.IV);

  public byte[] EncryptionKey => this.Key;

  public byte[] EncryptionIV => this.IV;

  public AEStoPHPCryptography()
  {
    this.Key = new byte[32 /*0x20*/];
    this.IV = new byte[16 /*0x10*/];
    this.GenerateRandomKeys();
  }

  public AEStoPHPCryptography(string key, string iv)
  {
    this.Key = Convert.FromBase64String(key);
    this.IV = Convert.FromBase64String(iv);
    if (this.Key.Length * 8 != 256 /*0x0100*/)
      throw new Exception("The Key must be exactally 256 bits long!");
    if (this.IV.Length * 8 != 128 /*0x80*/)
      throw new Exception("The IV must be exactally 128 bits long!");
  }

  public void GenerateRandomKeys()
  {
    RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider();
    cryptoServiceProvider.GetBytes(this.Key);
    cryptoServiceProvider.GetBytes(this.IV);
  }

  public string Encrypt(string plainText) => Utility.ToUrlSafeBase64(this.Encrypt2(plainText));

  private byte[] Encrypt2(string plainText)
  {
    try
    {
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Padding = PaddingMode.PKCS7;
      rijndaelManaged.Mode = CipherMode.CBC;
      rijndaelManaged.KeySize = 256 /*0x0100*/;
      rijndaelManaged.Key = this.Key;
      rijndaelManaged.IV = this.IV;
      ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write);
      StreamWriter streamWriter = new StreamWriter((Stream) cryptoStream);
      streamWriter.Write(plainText);
      streamWriter.Close();
      cryptoStream.Close();
      rijndaelManaged.Clear();
      return memoryStream.ToArray();
    }
    catch (Exception ex)
    {
      throw new CryptographicException("Problem trying to encrypt.", ex);
    }
  }

  public string Decrypt(string cipherText) => this.Decrypt2(Utility.FromUrlSafeBase64(cipherText));

  private string Decrypt2(byte[] cipherText)
  {
    try
    {
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Padding = PaddingMode.PKCS7;
      rijndaelManaged.Mode = CipherMode.CBC;
      rijndaelManaged.KeySize = 256 /*0x0100*/;
      rijndaelManaged.Key = this.Key;
      rijndaelManaged.IV = this.IV;
      ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
      MemoryStream memoryStream = new MemoryStream(cipherText);
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read);
      StreamReader streamReader = new StreamReader((Stream) cryptoStream);
      string end = streamReader.ReadToEnd();
      streamReader.Close();
      cryptoStream.Close();
      memoryStream.Close();
      rijndaelManaged.Clear();
      return end;
    }
    catch (Exception ex)
    {
      throw new CryptographicException("Problem trying to decrypt.", ex);
    }
  }
}
