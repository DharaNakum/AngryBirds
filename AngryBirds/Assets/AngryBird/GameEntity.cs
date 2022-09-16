using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

namespace AngryBird
{
    public abstract class GameEntity : MonoBehaviour
    {
        [SerializeField]
        protected new Collider2D collider2D;
        [SerializeField]
        protected Rigidbody2D rigidBody;
        [SerializeField]
        protected SpriteRenderer spriteRenderer;
        protected float Time;
        protected float MaximumLife;
        protected float SpritesLife;
        protected int Health;

        public Sprite[] sprites;
        public ParticleSystem deathParticles;
        protected int SpriteIndex;
       
        
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            
            Damage (collision.relativeVelocity.magnitude);
        }

        protected virtual void Damage(in float damage)
        {
            
            MaximumLife -= damage;
            if (MaximumLife < SpritesLife)
            {
                if (SpriteIndex<sprites.Length)
                {
                    if (sprites[SpriteIndex] != null)
                    {
                        spriteRenderer.sprite = sprites[SpriteIndex];
                        SpriteIndex++;
                        SpritesLife = SpritesLife / 2;
                    }
                }
            }
            if (MaximumLife <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            spriteRenderer.enabled = false;
            rigidBody.velocity = Vector2.zero;
            rigidBody.angularVelocity =0.0f;
            collider2D.enabled = false;
            if (deathParticles != null)
            {
                deathParticles.Play();
            }
            StartCoroutine(WaitForDeath(Time));
        }
        
        private IEnumerator WaitForDeath (float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }
    }
   
    public enum BirdType
    {
        Red,
        Bomb,
        Chuck,
        Matilda,
        JayJakeJim,
    }

    public enum Level
    {
        One=1,
        Two=2,
        Three=3,
        Four=4,
        Five=5,
    }

    public class PlayerData
    {
        public Level LevelType;
        public bool IsPassed;
        public int HighScore;
    }
    public class BirdData
    {
        public BirdType BirdTypes;
        public int BirdKill;
    }
    

   
}
