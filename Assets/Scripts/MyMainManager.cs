using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MyMainManager : MonoBehaviour
{
    public static MyMainManager Instance;
    public string input;
    public int score;
   

    private void Awake()
    {
        if(Instance!= null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadStuff();
    }

    public void ReadStringInput(string s)
    {
        input = s;
        Debug.Log(input);
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int highscore;
        
    }

    public void SaveStuff()
    {
        SaveData data = new SaveData();
        data.name = name;
        data.highscore = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadStuff()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            name = data.name;
            score = data.highscore;
        }
    }

}
