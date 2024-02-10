using System.Collections.Generic;
using Leguar.TotalJSON;
using UnityEngine;

public class Storage
{
    public int LastLevel { get; set; }
    public int Budget { get; set; }
    public List<string> ShoppedGameObjectNames { get; set; }
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
       //     ShoppedGameObjectNames = new List<string>()
        };

        // foreach (GameObject obj in gm.shoppedGameObject)
        // {
        //     if (obj != null)
        //     {
        //         // Save the name of the GameObject
        //         data.ShoppedGameObjectNames.Add(obj.name);
        //     }
        // }

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
            gm.budget = data.Budget; // Assign the loaded budget to the GameManager's budget

            // gm.shoppedGameObject.Clear();
            // foreach (string objName in data.ShoppedGameObjectNames)
            // {
            //     // Load the GameObject by name
            //     GameObject prefab = Resources.Load<GameObject>(objName);
            //     if (prefab != null)
            //     {
            //         GameObject obj = Instantiate(prefab);
            //         gm.shoppedGameObject.Add(obj);
            //     }
            // }
        }
        else
        {
            data = new Storage();
        }
    }
}