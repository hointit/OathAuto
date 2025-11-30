// Decompiled with JetBrains decompiler
// Type: SmartBot.PetClass
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Collections.Generic;

#nullable disable
namespace SmartBot;

public class PetClass
{
  private int ClassSize = 58;
  private TargetProcess localTarget;
  public int ActivePetGuidID;
  public int ActivePetDBID;
  public AllEnums.PetActions PetAction = AllEnums.PetActions.XuatChien;
  private string _HuyetTePetName = "";
  private string _CongSinhPetName = "";
  public int CongSinhTimeStamp;
  public int HuyetTeTimeStamp;
  private string _AlwaysActivePetName = "";
  public List<SinglePetClass> AllPets = new List<SinglePetClass>();
  public bool PetAOENeed = true;
  private bool _AllInformationLoaded;
  private int _CharDBID;
  public bool NoToy;
  public long NoToyStamp;
  public bool flagAllowPet = true;
  public long btnThuPetStamp;

  public void Initialize(TargetProcess _tempTarget) => this.localTarget = _tempTarget;

  public PetClass()
  {
    for (int index = 0; index < 10; ++index)
      this.AllPets.Add(new SinglePetClass());
  }

  private bool EverythingOK() => true;

  public int ActivePetIndex
  {
    get
    {
      if (this.ActivePetDBID > 0 && this.AllPets != null && this.AllPets.Count > 0)
      {
        for (int index = this.AllPets.Count - 1; index >= 0; --index)
        {
          SinglePetClass allPet = this.AllPets[index];
          if (allPet.DatabaseID == this.ActivePetDBID && allPet.PetOwnerDBID == this.ActivePetGuidID && allPet.HP > 0)
            return index;
        }
      }
      return -1;
    }
  }

  public int ActivePetID
  {
    get
    {
      return this.AllPets != null && this.ActivePetIndex >= 0 && this.ActivePetIndex < this.AllPets.Count && this.AllPets.Count > this.ActivePetIndex ? this.AllPets[this.ActivePetIndex].ID : 0;
    }
  }

  public string HuyetTePetName
  {
    get => this._HuyetTePetName;
    set
    {
      if (this.AllInformationLoaded && this._HuyetTePetName != value)
        this.SaveSingleSetting(nameof (HuyetTePetName), value.ToString());
      this._HuyetTePetName = value;
    }
  }

  public string CongSinhPetName
  {
    get => this._CongSinhPetName;
    set
    {
      if (this.AllInformationLoaded && this._CongSinhPetName != value)
        this.SaveSingleSetting(nameof (CongSinhPetName), value.ToString());
      this._CongSinhPetName = value;
    }
  }

  public int AlwaysActivePetDBID
  {
    get => this.AlwaysActivePetName != "" ? this.GetPetDBIDFromName(this.AlwaysActivePetName) : -1;
  }

  public int AlwaysActivePetGuidID
  {
    get
    {
      return this.AlwaysActivePetName != "" ? this.GetPetGuidIDFromName(this.AlwaysActivePetName) : -1;
    }
  }

  public string AlwaysActivePetName
  {
    get => this._AlwaysActivePetName;
    set
    {
      if (this.AllInformationLoaded && this._AlwaysActivePetName != value)
        this.SaveSingleSetting(nameof (AlwaysActivePetName), value.ToString());
      this._AlwaysActivePetName = value;
    }
  }

  public string GetPetNameFromDBID(int dbID)
  {
    if (dbID > 0 && this.AllPets != null && this.AllPets.Count > 0)
    {
      for (int index = this.AllPets.Count - 1; index >= 0; --index)
      {
        SinglePetClass allPet = this.AllPets[index];
        if (allPet.DatabaseID == dbID)
          return allPet.PetName;
      }
    }
    return "";
  }

  public SinglePetClass GetPetByName(string name)
  {
    if (name != "" && name.Length < 30 && this.AllPets != null)
    {
      if (this.AllPets.Count > 0)
      {
        try
        {
          for (int index = this.AllPets.Count - 1; index >= 0; --index)
          {
            SinglePetClass allPet = this.AllPets[index];
            if (allPet.PetName == name)
              return allPet;
          }
        }
        catch (Exception ex)
        {
          GA.WriteUserLog($"Lỗi lấy thông tin pet theo tên. Tên pet: {name}\n{ex.Message}\nStack traces\n{ex.StackTrace}");
        }
      }
    }
    return (SinglePetClass) null;
  }

  public SinglePetClass GetPetByDBID(int dbID, int PetOwnerDBID)
  {
    if (dbID != 0 && this.AllPets != null)
    {
      if (this.AllPets.Count > 0)
      {
        try
        {
          for (int index = this.AllPets.Count - 1; index >= 0; --index)
          {
            SinglePetClass allPet = this.AllPets[index];
            if (allPet.DatabaseID == dbID && dbID != 0 && allPet.PetOwnerDBID == PetOwnerDBID && PetOwnerDBID != 0)
              return allPet;
          }
        }
        catch (Exception ex)
        {
          GA.WriteUserLog($"Lỗi lấy pet theo dbid. \n{ex.Message}\nStack traces\n{ex.StackTrace}");
        }
      }
    }
    return (SinglePetClass) null;
  }

  public int GetPetGuidIDFromName(string name)
  {
    if (name != "" && name.Length < 30 && this.AllPets != null && this.AllPets.Count > 0)
    {
      for (int index = this.AllPets.Count - 1; index >= 0; --index)
      {
        SinglePetClass allPet = this.AllPets[index];
        if (allPet.PetName == name)
          return allPet.PetOwnerDBID;
      }
    }
    return -1;
  }

  public int GetPetDBIDFromName(string name)
  {
    if (name != "" && name.Length < 30 && this.AllPets != null && this.AllPets.Count > 0)
    {
      for (int index = this.AllPets.Count - 1; index >= 0; --index)
      {
        SinglePetClass allPet = this.AllPets[index];
        if (allPet.PetName == name)
          return allPet.DatabaseID;
      }
    }
    return -1;
  }

  public int GetPetIDFromName(string name)
  {
    if (name != "" && name.Length < 30 && this.AllPets != null && this.AllPets.Count > 0)
    {
      for (int index = this.AllPets.Count - 1; index >= 0; --index)
      {
        SinglePetClass allPet = this.AllPets[index];
        if (allPet.PetName == name)
          return allPet.ID;
      }
    }
    return -1;
  }

  public bool AllInformationLoaded
  {
    get => this._AllInformationLoaded;
    set => this._AllInformationLoaded = value;
  }

  public int CharDBID
  {
    get => this._CharDBID;
    set
    {
      if (this._CharDBID == value)
        return;
      this._CharDBID = value;
    }
  }


  public void SaveSingleSetting(
    string keyName,
    string value,
    string desc = "",
    params string[] parameters)
  {
  }
}
