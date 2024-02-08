using System.Collections.Generic;
using UnityEngine;
using Leguar.TotalJSON;

public class Storage
{
    public int LastLevel { get; set; }
    public int Budget { get; set; }
    public List<GameObject> ShoppedGameObjectNames { get; set; } 
}

public class UserData : MonoBehaviour
{
    private Storage data;
    [SerializeField] private GameManager gm;

    private void Start()
    {
        LoadData();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    private void SaveData()
    {
        data = new Storage
        {
            LastLevel = gm.LastLevel,
            Budget = gm.budget,
            ShoppedGameObjectNames = new List<GameObject>()
        };

        foreach (GameObject obj in gm.shoppedGameObject)
        {
            data.ShoppedGameObjectNames.Add(obj);
        }

        JSON json = JSON.Serialize(data);
        string jsonData = json.CreateString();
        PlayerPrefs.SetString("UserData", jsonData);
        PlayerPrefs.Save();
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("UserData"))
        {
            string jsonData = PlayerPrefs.GetString("UserData");
            JSON json = JSON.ParseString(jsonData);
            data = json.Deserialize<Storage>();

            gm.LastLevel = data.LastLevel;
            gm.budget = data.Budget;

            gm.shoppedGameObject.Clear();
            foreach (GameObject obj in data.ShoppedGameObjectNames)
            {
                if (obj != null)
                {
                    gm.shoppedGameObject.Add(obj);
                }
            }
        }
        else
        {
            data = new Storage();
        }
    }
}