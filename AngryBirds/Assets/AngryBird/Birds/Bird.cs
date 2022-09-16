using System;
using UnityEngine;
using System.Collections;
using AngryBird.EnemyObject;
using UnityEngine.Serialization;

namespace AngryBird.Birds
{
    public class Bird : GameEntity
    {
        protected float FlightSpeed;
        protected Vector3 OriginalPosition;
        protected  bool IsReleased;
        protected bool IsDragging;
        protected bool IsInMinDragDistance;
        protected Vector3 NewPosition;
        protected float MaxDragDistance;
        protected float MinDragDistance;
        protected float Distance3D;
        protected Vector3 LastPosV3;
        protected Vector2 LastPosV2;
        protected BirdType BirdTypes;
        protected int SpeedMultiplier;
        public int birdKillCount;
        

        public ParticleSystem trailParticles;
     
        protected void Awake()
        {
            IsDragging = false;
            IsReleased = false;
            IsInMinDragDistance = false;
            birdKillCount = 0;
        }
        protected virtual void Start()
        {
            rigidBody.isKinematic = true;
            FlightSpeed = 450f;
            OriginalPosition = transform.position;
            MaxDragDistance = 2f;
            MinDragDistance = 0.8f;
            Time = 3.0f;
            SpeedMultiplier = 1;
            GameManager.GameManager.Instance.background.SetCollider(false);
            MaximumLife = 18.0f;
            SpritesLife = MaximumLife;
            SpriteIndex = 0;
            

        }
        protected void Update()
        {
            if (IsReleased)
            {
                return;
            }
            if (IsDragging)
            {
                NewPosition = GetMousePos();
                Distance3D = Vector2.Distance(NewPosition, OriginalPosition);
                if (Distance3D< MinDragDistance)
                {
                    rigidBody.position = NewPosition;
                    IsInMinDragDistance = true;
                }
                else if (Distance3D > MaxDragDistance )
                {
                    ChangeDirection();
                }
                else
                {
                    IsInMinDragDistance = false;
                    rigidBody.position = NewPosition;
                }
               
            }
           
        }

        private void ChangeDirection()
        {
            IsInMinDragDistance = false;
            LastPosV3 = NewPosition - GameManager.GameManager.Instance.catapult.CenterPoint.transform.position;
            LastPosV2 = new Vector2(LastPosV3.x, LastPosV3.y);
            rigidBody.position = GameManager.GameManager.Instance.catapult.CenterPoint.GetComponent<Rigidbody2D>().position +
                                 LastPosV2.normalized * MaxDragDistance;
        }

        private static Vector3 GetMousePos()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
        protected virtual void OnMouseDown()
        {
            if (IsReleased )
            {
                return;
            }
            IsDragging = true;
            rigidBody.isKinematic = true;
            GameManager.GameManager.Instance.currentBirdType = this.BirdTypes;
        }
        protected virtual void OnMouseUp()
        {
            if (IsReleased)
            {
                return;
            }
            Debug.Log("on bird mouse up");
            if (IsInMinDragDistance)
            {
                rigidBody.position = OriginalPosition;
                IsDragging = false;
                return;
            }
            GameManager.GameManager.Instance.background.SetCollider(true);
            IsDragging = false;
            rigidBody.isKinematic = false;
            ReleaseMe();
        }
        private void ReleaseMe()
        {
            IsReleased = true;
            Vector3 trajectory3D = transform.position - OriginalPosition;
            Vector2 trajectory2D = -trajectory3D;
            rigidBody.AddForce(trajectory2D * FlightSpeed * SpeedMultiplier, ForceMode2D.Force);
            StartCoroutine(Wait());
            if (trailParticles != null)
            {
                trailParticles.Play();
            }
        }
        private IEnumerator Wait ()
        {
            
            yield return new WaitForSeconds(GameManager.GameManager.Instance.releaseTime);
            
            if (GameManager.GameManager.Instance.attempts > 0)
            {
                Debug.Log("Bird Ins");
                GameManager.GameManager.Instance.catapult.AddBird();
            }
            else
            {
                if (Pig.EnemiesAlive > 0)
                {
                    GameManager.GameManager.Instance.GameOver();
                }
            }
           
        }
        

        public virtual void BirdAbility()
        {
           
        }

        protected override void Damage(in float damage)
        {
            base.Damage(in damage);
            if (trailParticles.isPlaying)
            {
                trailParticles.Stop();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            IsDragging = false;
            
        }
    }
}


