using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AngryBird.Views
{
    public class GamePlayView : MonoBehaviour
    {
        public TextMeshProUGUI score;
        public TextMeshProUGUI attempt;
        public TextMeshProUGUI highScore;
        public Button endLevel;
       
        private void Start()
        {
            //SetHighScore();
        }

        public void SetButton(bool isVisible)
        {
            endLevel.gameObject.SetActive(isVisible);
        }

        public void OnEndLevelClick()
        {
            if (GameManager.GameManager.Instance.playerDataS.Find(x =>
                x.LevelType == GameManager.GameManager.Instance.level) != null)
            {
                if (GameManager.GameManager.Instance.playerDataS.Find(x =>
                        x.LevelType == GameManager.GameManager.Instance.level).HighScore <
                    GameManager.GameManager.Score)
                {
                    GameManager.GameManager.Instance.playerDataS.Find(x =>
                        x.LevelType == GameManager.GameManager.Instance.level).HighScore = GameManager.GameManager.Score;
                    Debug.Log("greater");
                }

                GameManager.GameManager.Instance.playerDataS.Find(x =>
                    x.LevelType == GameManager.GameManager.Instance.level).IsPassed = true;
            }
            else
            {
                PlayerData playerdata = new PlayerData();
                playerdata.LevelType = GameManager.GameManager.Instance.level;
                playerdata.HighScore = GameManager.GameManager.Score;
                playerdata.IsPassed = true;
                GameManager.GameManager.Instance.playerDataS.Add(playerdata);
                /*Debug.Log(GameManager.GameManager.Instance.playerDataS);
                Debug.Log(JsonUtility.ToJson(playerdata));*/
                
            }
             //Debug.Log("********"+JsonConvert.SerializeObject(GameManager.GameManager.Instance.playerDataS));
            
           JsonHandler.WritePlayerData(GameManager.GameManager.Instance.playerDataS,GameManager.GameManager.Instance.birdDataS);
            /*PlayerData playerData = new PlayerData
            {
                HighScore = GameManager.GameManager.Score, CurrentLevel = GameManager.GameManager.Instance.level
            };
            string json;
            if (File.Exists(@"E:\Dhara\AngryBird\"+"save" + GameManager.GameManager.Instance.level + ".txt"))
            {
                Debug.Log("got file");
                json = File.ReadAllText(@"E:\Dhara\AngryBird\" + "save" + GameManager.GameManager.Instance.level + ".txt");
                PlayerData playerDataLoad = JsonUtility.FromJson<PlayerData>(json);
                Debug.Log(playerData.HighScore);
                if (playerData.HighScore > playerDataLoad.HighScore)
                {
                    json = JsonUtility.ToJson(playerData);
                    File.WriteAllText(@"E:\Dhara\AngryBird\" + "save" + playerData.CurrentLevel + ".txt",json);
                }
            }
            else
            {
                json = JsonUtility.ToJson(playerData);
                File.WriteAllText(@"E:\Dhara\AngryBird\" + "save" + playerData.CurrentLevel + ".txt",json);
            }
            */

            SceneManager.LoadScene("LevelSelection");
        }

        public void SetHighScore(int data)
        {
           
            /*if (File.Exists(@"E:\Dhara\AngryBird\"+"save" + GameManager.GameManager.Instance.level + ".txt"))
            {
                Debug.Log("got file");
               string json =File.ReadAllText(@"E:\Dhara\AngryBird\" + "save" + GameManager.GameManager.Instance.level + ".txt");
               PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
                Debug.Log(playerData.HighScore);
                highScore.text = playerData.HighScore.ToString();
            }*/
            highScore.text = data.ToString();
        }

        public void SetScore(int gameScore)
        {
            score.text = gameScore.ToString();
        }
        public void SetAttempt(int gameAttempt)
        {
            attempt.text = gameAttempt.ToString();
        }
    }
}
