// Decompiled with JetBrains decompiler
// Type: SmartBot.GADB
// Assembly: GAuto_Auto_None, Version=2.4.3.8, Culture=neutral, PublicKeyToken=null
// MVID: 76F663E8-D92E-4496-B4AA-6E6B9F025406
// Assembly location: E:\LMTK\Auto Game\GAUTOFREE\Release\GAuto_Auto_None.exe

using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Text;

#nullable disable
namespace SmartBot;

public class GADB
{
  public static bool CheckAndCreateTable(string tableName)
  {
    if (!File.Exists(frmLogin.GAuto.Settings.SettingDB))
      SQLiteConnection.CreateFile(frmLogin.GAuto.Settings.SettingDB);
    SQLiteConnection connection = (SQLiteConnection) null;
    if (File.Exists(frmLogin.GAuto.Settings.SettingDB))
    {
      connection = new SQLiteConnection("Data Source=" + frmLogin.GAuto.Settings.SettingDB);
      connection.Open();
    }
    if (connection == null)
      return false;
    if (connection.State == ConnectionState.Open)
    {
      SQLiteDataReader reader = new SQLiteCommand($"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';", connection).ExecuteReader();
      DataTable dataTable = new DataTable();
      dataTable.Load((IDataReader) reader);
      if (dataTable.Rows.Count <= 0)
      {
        lock (frmLogin.DBLock)
        {
          try
          {
            new SQLiteCommand(GADB.NewTableString(tableName), connection).ExecuteNonQuery();
          }
          catch (Exception ex)
          {
            connection.Close();
            return false;
          }
        }
      }
      connection.Close();
    }
    return true;
  }

  public static void ProcessInfoDB(string tableName, bool tosave, string key, DBInfoClass info)
  {
    if (string.IsNullOrEmpty(tableName))
      tableName = frmLogin.GAuto.Settings.SettingTable;
    SQLiteConnection connection = (SQLiteConnection) null;
    if (File.Exists(frmLogin.GAuto.Settings.SettingDB))
    {
      connection = new SQLiteConnection("Data Source=" + frmLogin.GAuto.Settings.SettingDB);
      connection.Open();
    }
    if (connection == null || connection.State != ConnectionState.Open)
      return;
    if (connection.State == ConnectionState.Open && GADB.CheckAndCreateTable(tableName))
    {
      if (tosave)
      {
        SQLiteDataReader reader = new SQLiteCommand($"SELECT key FROM '{tableName}' WHERE key = '{key}';", connection).ExecuteReader();
        DataTable dataTable = new DataTable();
        dataTable.Load((IDataReader) reader);
        if (info.Value.StartsWith("0") && info.Value.Length > 1)
          info.Value = "\\" + info.Value;
        if (info.Value.Contains("'"))
          info.Value = info.Value.Replace("'", "''");
        string commandText = string.Format("UPDATE '{0}' SET value = '{2}', desc = '{3}', param1 = '{4}', param2 = '{5}', param3 = '{6}', param4 = '{7}' WHERE key = '{1}';", (object) tableName, (object) key, (object) info.Value, (object) info.Description, (object) info.Params[0], (object) info.Params[1], (object) info.Params[2], (object) info.Params[3]);
        if (dataTable.Rows.Count == 0)
          commandText = $"INSERT INTO '{tableName}' (key, value, desc, param1, param2, param3, param4) VALUES ('{key}','{info.Value}','{info.Description}','{info.Params[0]}','{info.Params[1]}','{info.Params[2]}','{info.Params[3]}');";
        SQLiteCommand sqLiteCommand = new SQLiteCommand(commandText, connection);
        lock (frmLogin.settingDB)
          sqLiteCommand.ExecuteNonQuery();
      }
      else if (!tosave)
      {
        SQLiteDataReader reader = new SQLiteCommand($"SELECT * FROM '{tableName}' WHERE key = '{key}';", connection).ExecuteReader();
        DataTable dataTable = new DataTable();
        dataTable.Load((IDataReader) reader);
        if (dataTable.Rows.Count > 0)
        {
          DataRow row = dataTable.Rows[0];
          GADB.ExtractInfo(info, row);
        }
      }
    }
    connection.Close();
  }

  private static void ExtractInfo(DBInfoClass info, DataRow row)
  {
    if (row == null || row.ItemArray.Length < 7 || info == null)
      return;
    info.Key = !string.IsNullOrEmpty(row["key"].ToString()) ? row["key"].ToString() : "";
    info.Value = !string.IsNullOrEmpty(row["value"].ToString()) ? row["value"].ToString() : "";
    info.Description = !string.IsNullOrEmpty(row["desc"].ToString()) ? row["desc"].ToString() : "";
    for (int index = 1; index <= 4; ++index)
      info.Params[index - 1] = !string.IsNullOrEmpty(row["param" + index.ToString()].ToString()) ? row["param" + index.ToString()].ToString() : "";
  }

  public static string GetCharTableName(int id) => id != 0 ? id.ToString("X8") : "";

  public static void SaveSingleSetting(
    string tableName,
    string keyName,
    string value,
    string desc = "",
    params string[] parameters)
  {
    if (!(tableName != ""))
      return;
    DBInfoClass info = new DBInfoClass();
    info.Key = keyName;
    info.Value = value;
    info.Description = desc;
    if (parameters != null && parameters.Length > 0)
    {
      int index1 = 0;
      for (int index2 = 0; index2 < parameters.Length; ++index2)
      {
        string parameter = parameters[index2];
        info.Params[index1] = parameter;
        ++index1;
      }
    }
    GADB.ProcessInfoDB(tableName, true, info.Key, info);
  }

  private static string NewTableString(string tableName)
  {
    string str = $"CREATE TABLE '{tableName}' (key STRING PRIMARY KEY UNIQUE NOT NULL, value STRING, desc STRING, param1 STRING, param2 STRING, param3 STRING, param4 STRING);";
    if (tableName == "tnprices2")
      str = "CREATE TABLE tnprices2 (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, bangid INTEGER NOT NULL, friendid INTEGER NOT NULL, spread DOUBLE NOT NULL, itemid INTEGER, mytype INTEGER DEFAULT (0), midprice DOUBLE DEFAULT (0), lowprice DOUBLE DEFAULT (0), highprice DOUBLE DEFAULT (0));";
    return str;
  }

  internal static void LoadGlobalSettings()
  {
    string tableName = "gauto";
    if (string.IsNullOrEmpty(tableName) || !GADB.CheckAndCreateTable(tableName))
      return;
    SQLiteConnection connection = (SQLiteConnection) null;
    if (File.Exists(frmLogin.GAuto.Settings.SettingDB))
    {
      connection = new SQLiteConnection("Data Source=" + frmLogin.GAuto.Settings.SettingDB);
      connection.Open();
    }
    if (connection.State != ConnectionState.Open)
      return;
    SQLiteDataReader reader = new SQLiteCommand($"SELECT * FROM '{tableName}';", connection).ExecuteReader();
    DataTable dataTable = new DataTable();
    dataTable.Load((IDataReader) reader);
    if (dataTable.Rows.Count > 0)
    {
      Type type = typeof (GlobalSettings);
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        DBInfoClass info = new DBInfoClass();
        GADB.ExtractInfo(info, row);
        PropertyInfo property = type.GetProperty(info.Key);
        if (info.Value.StartsWith("\\"))
          info.Value = info.Value.Remove(0, 1);
        if (property != null)
        {
          Type propertyType = property.PropertyType;
          if (property.PropertyType == typeof (GAutoList<string>))
          {
            string[] strArray = info.Value.Split('|');
            GAutoList<string> gautoList = new GAutoList<string>();
            if (strArray.Length > 0)
            {
              for (int index = 0; index < strArray.Length; ++index)
              {
                if (!string.IsNullOrEmpty(strArray[index]))
                  gautoList.Add(strArray[index]);
              }
              property.SetValue((object) frmLogin.GAuto.Settings, (object) gautoList, (object[]) null);
              if (info.Key == "ItemTuHuyList")
              {
                frmLogin.GAuto.Settings.ItemTuHuyList.OnAdd += new EventHandler(frmLogin.frmLoginInstance.ItemKhongNhatList_OnAdd);
                frmLogin.GAuto.Settings.ItemTuHuyList.OnRemove += new EventHandler(frmLogin.frmLoginInstance.ItemKhongNhatList_OnRemove);
              }
              else if (info.Key == "ItemBanList")
              {
                frmLogin.GAuto.Settings.ItemBanList.OnAdd += new EventHandler(frmLogin.frmLoginInstance.ItemBanList_OnAdd);
                frmLogin.GAuto.Settings.ItemBanList.OnRemove += new EventHandler(frmLogin.frmLoginInstance.ItemBanList_OnRemove);
              }
              else if (info.Key == "ListItemNhat")
              {
                frmLogin.GAuto.Settings.ListItemNhat.OnAdd += new EventHandler(frmLogin.frmLoginInstance.ListItemNhat_OnAdd);
                frmLogin.GAuto.Settings.ListItemNhat.OnRemove += new EventHandler(frmLogin.frmLoginInstance.ListItemNhat_OnRemove);
              }
              else if (info.Key == "BuffNameList")
              {
                frmLogin.GAuto.Settings.BuffNameList.OnAdd += new EventHandler(frmLogin.frmLoginInstance.BuffNameList_OnAdd);
                frmLogin.GAuto.Settings.BuffNameList.OnRemove += new EventHandler(frmLogin.frmLoginInstance.BuffNameList_Remove);
              }
              else if (info.Key == "ListBuffPetID")
              {
                frmLogin.GAuto.Settings.ListBuffPetID.OnAdd += new EventHandler(frmLogin.frmLoginInstance.ListBuffPetID_OnAdd);
                frmLogin.GAuto.Settings.ListBuffPetID.OnRemove += new EventHandler(frmLogin.frmLoginInstance.ListBuffPetID_OnRemove);
              }
              else if (!(info.Key == "ListLoginProfile"))
                ;
            }
          }
          else if (property.PropertyType == typeof (GAutoList<LoginProfileClass>))
          {
            string[] strArray1 = info.Value.Split('|');
            if (strArray1.Length > 0)
            {
              foreach (string str in strArray1)
              {
                if (!string.IsNullOrEmpty(str))
                {
                  string[] strArray2 = str.Split(';');
                  if (strArray2.Length >= 6)
                  {
                    LoginProfileClass loginProfileClass = new LoginProfileClass();
                    loginProfileClass.Username = strArray2[0];
                    string data = "";
                    try
                    {
                      data = Encoding.UTF8.GetString(Convert.FromBase64String(strArray2[1]));
                    }
                    catch (Exception ex)
                    {
                    }
                    string password = GA.XOREncrypt(data, "%6fhru4?");
                    loginProfileClass.Password = GA.ConvertToSecureString(password);
                    loginProfileClass.NPH = strArray2[2];
                    loginProfileClass.Server = strArray2[3];
                    loginProfileClass.MinorServer = strArray2[4];
                    loginProfileClass.CharName = strArray2[5];
                    loginProfileClass.GamePath = strArray2[6];
                    frmLogin.GAuto.Settings.ListLoginProfile.Add(loginProfileClass);
                  }
                }
              }
            }
          }
          else
          {
            object obj = Convert.ChangeType((object) info.Value, propertyType);
            if (obj != null)
              property.SetValue((object) frmLogin.GAuto.Settings, obj, (object[]) null);
          }
        }
        else if (property == null && info.Key == "hotkey")
        {
          string[] strArray3 = info.Value.Split('|');
          if (strArray3.Length > 0)
          {
            for (int index = 0; index < strArray3.Length; ++index)
            {
              if (!string.IsNullOrEmpty(strArray3[index]) && strArray3[index].Contains(","))
              {
                string[] strArray4 = strArray3[index].Split(',');
                if (strArray4.Length == 2)
                {
                  int result1 = 0;
                  int result2 = 0;
                  int.TryParse(strArray4[0], out result1);
                  int.TryParse(strArray4[1], out result2);
                  GA.ActiveHotKeys[result1 - 1].KeyValue = result2;
                  GA.ActiveHotKeys[result1 - 1].NotDefault = true;
                  GA.ActiveHotKeys[result1 - 1].Changed = true;
                }
              }
            }
          }
        }
      }
    }
    connection.Close();
  }

  public static void LoadAllSettings(AutoAccount account)
  {
    string charTableName = GADB.GetCharTableName(account.Myself.DatabaseID);
    if (string.IsNullOrEmpty(charTableName) || !GADB.CheckAndCreateTable(charTableName))
      return;
    SQLiteConnection connection = (SQLiteConnection) null;
    if (File.Exists(frmLogin.GAuto.Settings.SettingDB))
    {
      connection = new SQLiteConnection("Data Source=" + frmLogin.GAuto.Settings.SettingDB);
      connection.Open();
    }
    if (connection.State != ConnectionState.Open)
      return;
    SQLiteDataReader reader = new SQLiteCommand($"SELECT * FROM '{charTableName}';", connection).ExecuteReader();
    DataTable dataTable = new DataTable();
    dataTable.Load((IDataReader) reader);
    if (dataTable.Rows.Count > 0)
    {
      Type type = typeof (AutoSettings);
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        DBInfoClass info = new DBInfoClass();
        GADB.ExtractInfo(info, row);
        PropertyInfo property = type.GetProperty(info.Key);
        if (info.Value.StartsWith("\\"))
          info.Value = info.Value.Remove(0, 1);
        if (property != null)
        {
          Type propertyType = property.PropertyType;
          if (property.PropertyType == typeof (GAutoList<string>))
          {
            string[] strArray = info.Value.Split('|');
            GAutoList<string> gautoList = new GAutoList<string>();
            if (strArray.Length > 0)
            {
              for (int index = 0; index < strArray.Length; ++index)
              {
                if (!string.IsNullOrEmpty(strArray[index]))
                  gautoList.Add(strArray[index]);
              }
              property.SetValue((object) account.Settings, (object) gautoList, (object[]) null);
              if (info.Key == "AutoPartyList")
              {
                account.Settings.AutoPartyList.OnAdd += new EventHandler(account.AutoPartyList_OnAdd);
                account.Settings.AutoPartyList.OnRemove += new EventHandler(account.AutoPartyList_OnRemove);
              }
              else if (info.Key == "ListItemNhatIgnore")
              {
                account.Settings.ListItemNhatIgnore.OnAdd += new EventHandler(account.ListItemNhatIgnore_OnAdd);
                account.Settings.ListItemNhatIgnore.OnRemove += new EventHandler(account.ListItemNhatIgnore_OnRemove);
              }
              else if (info.Key == "PTBlacklist")
              {
                account.Settings.PTBlacklist.OnAdd += new EventHandler(account.PTBlacklist_OnAdd);
                account.Settings.PTBlacklist.OnRemove += new EventHandler(account.PTBlacklist_OnRemove);
              }
              else if (info.Key == "QuaiNoAttackList")
              {
                account.Settings.QuaiNoAttackList.OnAdd += new EventHandler(account.QuaiNoAttackList_OnAdd);
                account.Settings.QuaiNoAttackList.OnRemove += new EventHandler(account.QuaiNoAttackList_OnRemove);
              }
              else if (info.Key == "PKPlayerList")
              {
                account.Settings.PKPlayerList.OnAdd += new EventHandler(account.PKPlayerList_OnAdd);
                account.Settings.PKPlayerList.OnRemove += new EventHandler(account.PKPlayerList_OnRemove);
              }
              else if (info.Key == "PKBlackList")
              {
                account.Settings.PKBlackList.OnAdd += new EventHandler(account.PKBlackList_OnAdd);
                account.Settings.PKBlackList.OnRemove += new EventHandler(account.PKBlackList_OnRemove);
              }
              else if (!(info.Key == "txtPassCap2"))
                ;
            }
          }
          else if (property.PropertyType == typeof (GAutoList<int>))
          {
            string[] strArray = info.Value.Split('|');
            GAutoList<int> gautoList = new GAutoList<int>();
            int result = 0;
            if (strArray.Length > 0)
            {
              for (int index = 0; index < strArray.Length; ++index)
              {
                if (!string.IsNullOrEmpty(strArray[index]))
                {
                  int.TryParse(strArray[index], out result);
                  gautoList.Add(result);
                }
              }
              property.SetValue((object) account.Settings, (object) gautoList, (object[]) null);
              if (info.Key == "PKBangList")
              {
                account.Settings.PKBangList.OnAdd += new EventHandler(account.PKBangList_OnAdd);
                account.Settings.PKBangList.OnRemove += new EventHandler(account.PKBangList_OnRemove);
              }
            }
          }
          else if (property.PropertyType == typeof (GAutoList<ItemToBuy>))
          {
            GAutoList<ItemToBuy> gautoList = new GAutoList<ItemToBuy>();
            string str1 = info.Value;
            char[] chArray = new char[1]{ '|' };
            foreach (string str2 in str1.Split(chArray))
            {
              if (!string.IsNullOrEmpty(str2))
              {
                string[] strArray = str2.Split(';');
                ItemToBuy itemToBuy1 = (ItemToBuy) null;
                int result1 = 0;
                int result2 = 20;
                int.TryParse(strArray[0], out result1);
                int.TryParse(strArray[1], out result2);
                if (result1 != 0)
                {
                  foreach (ItemToBuy itemToBuy2 in frmLogin.GAuto.Settings.ListItemToBuy)
                  {
                    if (itemToBuy2.ID == result1)
                    {
                      itemToBuy1 = new ItemToBuy();
                      itemToBuy1.Amount = result2;
                      itemToBuy1.ID = itemToBuy2.ID;
                      itemToBuy1.Name = itemToBuy2.Name;
                      itemToBuy1.NPCType = itemToBuy2.NPCType;
                      itemToBuy1.RealAmountToBuy = itemToBuy2.RealAmountToBuy;
                      itemToBuy1.MenuIndex = itemToBuy2.MenuIndex;
                      itemToBuy1.MenuKNB1 = itemToBuy2.MenuKNB1;
                      itemToBuy1.MenuKNB2 = itemToBuy2.MenuKNB2;
                      itemToBuy1.buyStampMax = itemToBuy2.buyStampMax;
                      break;
                    }
                  }
                  if (itemToBuy1 != null)
                    gautoList.Add(itemToBuy1);
                }
              }
            }
            if (gautoList.Count > 0)
            {
              property.SetValue((object) account.Settings, (object) gautoList, (object[]) null);
              if (info.Key == "ListItemToBuy")
              {
                account.Settings.ListItemToBuy.OnAdd += new EventHandler(account.ListItemToBuy_OnAdd);
                account.Settings.ListItemToBuy.OnRemove += new EventHandler(account.ListItemToBuy_OnRemove);
              }
            }
          }
          else if (property.PropertyType == typeof (GAutoList<ItemToUse>))
          {
            GAutoList<ItemToUse> gautoList = new GAutoList<ItemToUse>();
            string str3 = info.Value;
            char[] chArray = new char[1]{ '|' };
            foreach (string str4 in str3.Split(chArray))
            {
              if (!string.IsNullOrEmpty(str4))
              {
                string[] strArray = str4.Split(';');
                ItemToUse itemToUse = new ItemToUse();
                int result = 30;
                itemToUse.Name = strArray[0];
                int.TryParse(strArray[1], out result);
                itemToUse.DelaySeconds = result;
                if (itemToUse.Name != "")
                  gautoList.Add(itemToUse);
              }
            }
            if (gautoList.Count > 0)
            {
              property.SetValue((object) account.Settings, (object) gautoList, (object[]) null);
              if (info.Key == "ListItemToUse")
              {
                account.Settings.ListItemToUse.OnAdd += new EventHandler(account.ListItemToUse_OnAdd);
                account.Settings.ListItemToUse.OnRemove += new EventHandler(account.ListItemToUse_OnRemove);
              }
            }
          }
          else if (property.PropertyType == typeof (GAutoList<SkillPlayItem>))
          {
            GAutoList<SkillPlayItem> gautoList = new GAutoList<SkillPlayItem>();
            string str5 = info.Value;
            char[] chArray = new char[1]{ '|' };
            foreach (string str6 in str5.Split(chArray))
            {
              if (!string.IsNullOrEmpty(str6))
              {
                string[] strArray = str6.Split(';');
                SkillPlayItem skillPlayItem = new SkillPlayItem();
                if (strArray.Length >= 3)
                {
                  int.TryParse(strArray[2], out skillPlayItem.SkillDelayInSecond);
                  SingleSkill singleSkill = new SingleSkill();
                  singleSkill.Name = strArray[1];
                  int.TryParse(strArray[0], out singleSkill.ID);
                  skillPlayItem.SkillItem = singleSkill;
                  if (frmLogin.GAuto.SkillBookDB.Count > 0 && account.MyFlag.ReadMenPai)
                  {
                    for (int index = 0; index < frmLogin.GAuto.SkillBookDB.Count; ++index)
                    {
                      if (frmLogin.GAuto.SkillBookDB[index].SkillID == singleSkill.ID)
                      {
                        singleSkill.Special = frmLogin.GAuto.SkillBookDB[index].Special;
                        singleSkill.BookSlot = frmLogin.GAuto.SkillBookDB[index].BookSlot;
                        singleSkill.BuffPeriod = frmLogin.GAuto.SkillBookDB[index].BuffPeriod;
                        singleSkill.RageRequired = frmLogin.GAuto.SkillBookDB[index].RageRequired;
                        singleSkill.SkillBook = frmLogin.GAuto.SkillBookDB[index].SkillBook;
                        singleSkill.Special = frmLogin.GAuto.SkillBookDB[index].Special;
                        break;
                      }
                    }
                  }
                  skillPlayItem.IsEnabled = true;
                  if (info.Key == "SkillBuffList")
                  {
                    int.TryParse(strArray[3], out skillPlayItem.WaitingTime);
                    bool.TryParse(strArray[4], out skillPlayItem.BuffSelf);
                    bool.TryParse(strArray[5], out skillPlayItem.BuffParty);
                    bool.TryParse(strArray[6], out skillPlayItem.BuffList);
                    bool.TryParse(strArray[7], out skillPlayItem.BuffArmy);
                    try
                    {
                      if (strArray.Length >= 9)
                        bool.TryParse(strArray[8], out skillPlayItem.IsEnabled);
                    }
                    catch (Exception ex)
                    {
                    }
                  }
                  else
                    goto label_90;
label_82:
                  if (account.MySkills != null)
                  {
                    for (int index = 1; index < account.MySkills.AllSkills.Count; ++index)
                    {
                      if (skillPlayItem.SkillItem.Name == account.MySkills.AllSkills[index].Name)
                        skillPlayItem.SkillItem.KeyDesc = account.MySkills.AllSkills[index].KeyDesc;
                    }
                  }
                  if (skillPlayItem.SkillDelayInSecond != 0 && singleSkill.ID != 0 && singleSkill.Name != "")
                  {
                    gautoList.Add(skillPlayItem);
                    continue;
                  }
                  continue;
label_90:
                  try
                  {
                    if (strArray.Length >= 4)
                    {
                      bool.TryParse(strArray[3], out skillPlayItem.IsEnabled);
                      goto label_82;
                    }
                    goto label_82;
                  }
                  catch (Exception ex)
                  {
                    goto label_82;
                  }
                }
              }
            }
            if (gautoList.Count > 0)
            {
              property.SetValue((object) account.Settings, (object) gautoList, (object[]) null);
              if (info.Key == "SkillPlayList")
              {
                account.Settings.SkillPlayList.OnAdd += new EventHandler(account.SkillPlayList_OnAdd);
                account.Settings.SkillPlayList.OnRemove += new EventHandler(account.SkillPlayList_OnRemove);
              }
              else if (info.Key == "SkillPKList")
              {
                account.Settings.SkillPKList.OnAdd += new EventHandler(account.SkillPKList_OnAdd);
                account.Settings.SkillPKList.OnRemove += new EventHandler(account.SkillPKList_OnRemove);
              }
              else if (info.Key == "SkillBuffList")
              {
                account.Settings.SkillBuffList.OnAdd += new EventHandler(account.SkillBuffList_OnAdd);
                account.Settings.SkillBuffList.OnRemove += new EventHandler(account.SkillBuffList_OnRemove);
              }
            }
          }
          else if (property.PropertyType == typeof (GAutoList<GEventClass>))
          {
            GAutoList<GEventClass> gautoList = new GAutoList<GEventClass>();
            string str7 = info.Value;
            char[] chArray = new char[1]{ '|' };
            foreach (string str8 in str7.Split(chArray))
            {
              if (!string.IsNullOrEmpty(str8))
              {
                string[] strArray1 = str8.Split(';');
                GEventClass geventClass = new GEventClass();
                geventClass.EventName = strArray1[1];
                string[] strArray2 = strArray1[0].Split(':');
                int.TryParse(strArray2[0], out geventClass.Hour);
                int.TryParse(strArray2[1], out geventClass.Minute);
                if (geventClass.EventName != "")
                  gautoList.Add(geventClass);
              }
            }
            if (gautoList.Count > 0)
            {
              property.SetValue((object) account.Settings, (object) gautoList, (object[]) null);
              if (info.Key == "ListScheduler")
              {
                account.Settings.ListScheduler.OnAdd += new EventHandler(account.ListScheduler_OnAdd);
                account.Settings.ListScheduler.OnRemove += new EventHandler(account.ListScheduler_OnRemove);
              }
            }
            else
              account.Settings.ListScheduler = new GAutoList<GEventClass>();
          }
          else if (property.PropertyType == typeof (AllEnums.FightingModes))
            property.SetValue((object) account.Settings, (object) (AllEnums.FightingModes) Enum.Parse(typeof (AllEnums.FightingModes), info.Value), (object[]) null);
          else if (property.PropertyType == typeof (AllEnums.NhatItemModes))
            property.SetValue((object) account.Settings, (object) (AllEnums.NhatItemModes) Enum.Parse(typeof (AllEnums.NhatItemModes), info.Value), (object[]) null);
          else if (property.PropertyType == typeof (AllEnums.NgaMyBuffModes))
            property.SetValue((object) account.Settings, (object) (AllEnums.NgaMyBuffModes) Enum.Parse(typeof (AllEnums.NgaMyBuffModes), info.Value), (object[]) null);
          else if (info.Key == "PetAOEDBID")
          {
            int result = 0;
            int.TryParse(info.Value, out result);
            account.Settings.PetAOEDBID = result;
            int.TryParse(info.Params[0], out result);
            account.Settings.numPetAOE = result;
            int.TryParse(info.Params[1], out result);
            account.Settings.PetAOESkillID = result;
          }
          else if (info.Key == "txtPassCap2")
          {
            if (info.Value != "")
            {
              string data = "";
              try
              {
                data = Encoding.UTF8.GetString(Convert.FromBase64String(info.Value));
              }
              catch (Exception ex)
              {
              }
              string str = GA.XOREncrypt(data, "8u43!29").Replace("Peter", "").Replace("mary", "");
              account.Settings.txtPassCap2 = str;
            }
          }
          else if (info.Key == "AfterDeathSetting")
          {
            account.Settings.AfterDeathSetting = !(info.Value == "ExitGame") ? (!(info.Value == "HappyTea") ? AllEnums.AfterDeathSettings.BackToTrainSpot : AllEnums.AfterDeathSettings.HappyTea) : AllEnums.AfterDeathSettings.ExitGame;
          }
          else
          {
            object obj = Convert.ChangeType((object) info.Value, propertyType);
            if (obj != null)
              property.SetValue((object) account.Settings, obj, (object[]) null);
          }
        }
        else if (info.Key == "AlwaysActivePetName")
          account.MyPet.AlwaysActivePetName = info.Value;
        else if (info.Key == "HuyetTePetName")
          account.MyPet.HuyetTePetName = info.Value;
        else if (info.Key == "CongSinhPetName")
          account.MyPet.CongSinhPetName = info.Value;
      }
    }
    connection.Close();
  }

  internal static void RemoveSingleSetting(string tempTable, string key)
  {
    if (!File.Exists(frmLogin.GAuto.Settings.SettingDB))
      return;
    SQLiteConnection connection = new SQLiteConnection("Data Source=" + frmLogin.GAuto.Settings.SettingDB);
    connection.Open();
    string commandText = $"DELETE FROM {tempTable} WHERE key = '{key}'";
    if (connection.State != ConnectionState.Open)
      return;
    SQLiteCommand sqLiteCommand = new SQLiteCommand(commandText, connection);
    try
    {
      lock (frmLogin.settingDB)
        sqLiteCommand.ExecuteNonQuery();
    }
    catch (Exception ex)
    {
    }
    connection.Close();
  }
}
