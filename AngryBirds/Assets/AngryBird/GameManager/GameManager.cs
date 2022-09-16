using System;
using AngryBird.EnemyObject;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace AngryBird.GameManager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public int attempts;
        public Level level;
        public Catapult.Catapult catapult;
        public static int Score;
        public float offset;
        public Background background;
        //public Birds.Bird bird;
        public float releaseTime;
        public int[] birdIndex ;
        //public Enemy.Enemy enemy;
        public BirdType currentBirdType;
        public GameObject pointPrefab;
        public GameObject point;
       
        public Transform birds;
        public bool isLevelWin;
        public Vector3 position;
        public List<PlayerData> playerDataS = new List<PlayerData>();
        public List<BirdData> birdDataS = new List<BirdData>();
        protected void Awake()
        {
            position = new Vector3(0,0,0);
            if (Instance == null)
            {
                Instance = this;
                Score = 0;
            }

        }

        public void Start()
        {
           // Debug.Log(attempts);
           string json = PlayerPrefs.GetString("GameData");
           Debug.Log(json);
           GameData gameData = JsonConvert.DeserializeObject<GameData>(json);
           Dictionary<string, List<PlayerData>> playerdictionary = gameData.PlayerDataDictionary;
           Dictionary<string, List<BirdData>> birdDataDictionary = gameData.BirdDataDictionary;
          Debug.Log("dictionary " + playerdictionary );
          foreach (var value in playerdictionary.Values)
          {
              playerDataS.AddRange(value);
              Debug.Log("player value "+ value);
          }

          foreach (var value in birdDataDictionary.Values)
          {
              birdDataS.AddRange(value);
              Debug.Log("bird value "+ value);
          }
              
          Debug.Log("list ** " + playerDataS);
          //Debug.Log(playerDataS[level.index].HighScore);
            //isLevelWin = false;
           
            // GenerateBird();
        }

        /*public void GenerateBird()
        {
            for (int i = 0; i < birdIndex.Length; i++)
            {
                catapult.AddBird(birdIndex[i],position);
                position.x = position.x + offset;
            }
        }*/
        
        public void GameOver()
        {
            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {

            yield return new WaitForSeconds(2.0f);
            if (isLevelWin)
            {
                yield break;
            }
            Pig.EnemiesAlive = 0;
            Time.timeScale = 0;
            UiManager.Instance.gameOverView.gameObject.SetActive(true);
        }
        
    }

    public class GameData
    {
        public  Dictionary<string, List<PlayerData>> PlayerDataDictionary = new Dictionary<string,List<PlayerData>>();
        public  Dictionary<string, List<BirdData>> BirdDataDictionary = new Dictionary<string,List<BirdData>>();
    }
}
