using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public static class SaveData
{
    private static PlayerData scoresEmpty = new PlayerData(0, 0, 0, 0, 0);

    public static void SavePlayer(PlayerData player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = player;

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer(){
        string path = Application.persistentDataPath + "/player.fun";
        Debug.Log(path);

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
            Debug.Log("Save file not found in " + path + ". Creating new empty one.");
            SavePlayer(scoresEmpty);
            return null;
        }
    }
}