using System;
using UnityEngine;

namespace AngryBird.EnemyObject
{
    public class Wood : GameEntity
    {
        private void Start()
        {
            Time = 1.0f;
            MaximumLife = 9.0f;
            SpritesLife = MaximumLife;
            SpriteIndex = 0;
        }

        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);
            
        }

        protected override void Die()
        {
            base.Die();
            GameManager.GameManager.Score += 5;
            UiManager.Instance.gamePlayView.SetScore(GameManager.GameManager.Score);
        }
    }
}
