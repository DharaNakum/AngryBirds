
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using System;
using AngryBird.GameManager;
using Newtonsoft.Json;


namespace AngryBird
{
    public class JsonHandler : MonoBehaviour
    {
        public static string json;

        public static void WritePlayerData(List<PlayerData> playerDatas, List<BirdData> birdDatas)
        {
            /*FileStream fileStream = new FileStream (path, FileMode.Create);
    
            using (StreamWriter writer = new StreamWriter (fileStream)) {
                writer.Write (content);
            }*/
            //playerpref.getstring()
            //PlayerData list<>playerData = JsonUtility.FromJson<PlayerData>(json);
            Dictionary<string, List<PlayerData>> playerDictionary = new Dictionary<string,List<PlayerData>>();
            playerDictionary.Add("PlayerData",playerDatas);
            Debug.Log(playerDictionary);
            Dictionary<string, List<BirdData>> birdDictionary = new Dictionary<string,List<BirdData>>();
            birdDictionary.Add("BirdData",birdDatas);
            GameData gameData = new GameData();
            gameData.PlayerDataDictionary = playerDictionary;
            gameData.BirdDataDictionary = birdDictionary;
             json = JsonConvert.SerializeObject(gameData);
            Debug.Log(json);
            //return json;
            PlayerPrefs.SetString("GameData",json);
        }
       
    }

}
