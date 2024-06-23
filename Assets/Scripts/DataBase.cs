using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataBase : MonoBehaviour
{
    private string path = Application.persistentDataPath;//+"/Resources/Saves/";
    public void SaveData<T>(string saveName,T savedata)
    {
    string jsonToSave=    JsonUtility.ToJson(savedata);
        File.WriteAllText(path+saveName+".json",jsonToSave);
    }
    public void LoadData<T>(string saveName, System.Action<T> callback)
    {
        if (File.Exists(path + saveName + ".json"))
        {
            string loadedJson = File.ReadAllText(path + saveName + ".json");
            callback(JsonUtility.FromJson<T>(loadedJson));
            
        }

        //else kýsmýný ben ekledim.
        else File.Create(path + saveName + ".json");
        
    }
}
