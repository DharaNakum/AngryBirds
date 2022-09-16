using System.Collections.Generic;
using AngryBird;
using AngryBird.Birds;
using UnityEngine;

namespace AngryBird.EnemyObject
{
    public class Pig : GameEntity
    {
        public static int EnemiesAlive = 0;
        private void Start()
        {
            Time = 1.0f;
            MaximumLife = 11.0f;
            SpritesLife = MaximumLife;
            SpriteIndex = 0;
            EnemiesAlive++;
            //Debug.Log("Enemy Alive " + EnemiesAlive);
        }

        protected override void Die()
        {
            base.Die();
            EnemiesAlive--;
            if (GameManager.GameManager.Instance.birdDataS.Find(x =>
                x.BirdTypes == GameManager.GameManager.Instance.currentBirdType)!=null )
            {
                GameManager.GameManager.Instance.birdDataS.Find(x =>
                    x.BirdTypes == GameManager.GameManager.Instance.currentBirdType).BirdKill++;
            }
            else
            {
                BirdData birdData = new BirdData
                {
                    BirdTypes = GameManager.GameManager.Instance.currentBirdType, BirdKill = 1
                };
                GameManager.GameManager.Instance.birdDataS.Add(birdData);
            }
            // Debug.Log("Enemy Alive " + EnemiesAlive);
            if(EnemiesAlive <= 0)
            {
                GameManager.GameManager.Instance.isLevelWin = true;
                Debug.Log("LEVEL WON!");
                UiManager.Instance.gamePlayView.SetButton(true);
                GameManager.GameManager.Score += 10;
                UiManager.Instance.gamePlayView.SetScore(GameManager.GameManager.Score);
            }
        }
    }
}
