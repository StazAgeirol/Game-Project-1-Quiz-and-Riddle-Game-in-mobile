using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
   public static void SavePlayer(PlayerSaveSystem plry)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/LogicGeniusAppSAveData.bat";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(plry);
        
        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Been Save");
        Debug.Log(Application.persistentDataPath);
    }

    public static PlayerData LoadPayer()
    {
        string path = Application.persistentDataPath + "/LogicGeniusAppSAveData.bat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Error No save fileSetting");
            return null;
        }
    }

   


}
