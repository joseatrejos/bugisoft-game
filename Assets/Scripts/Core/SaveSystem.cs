using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGameState(GameState gameState) 
    {
        string path = Application.persistentDataPath + "/player.fun";

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        GameStateData data = new GameStateData(gameState);
        string json = JsonUtility.ToJson(data);
        formatter.Serialize(stream, json);
        stream.Close();
        Debug.Log(path);
    }

    public static GameStateData LoadGameState()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            //GameStateData data = formatter.Deserialize(stream) as GameStateData;
            string json = formatter.Deserialize(stream) as string;
            GameStateData data = JsonUtility.FromJson<GameStateData>(json);

            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
