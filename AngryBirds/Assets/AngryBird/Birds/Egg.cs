using System;
using UnityEngine;

namespace AngryBird.Birds
{
    public class Egg : GameEntity
    {
        [SerializeField]
        private PointEffector2D pointEffector2D;

        private void Start()
        {
            Time = 1.0f;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            collider2D.isTrigger = false;
        }

        protected override void Die()
        {
            base.Die();
            if (deathParticles != null)
            {
                deathParticles.Play();
            }
            if (deathParticles != null)
            {
                deathParticles.Play();
            } pointEffector2D.forceMagnitude = 100;
            
        }
    }
}
