using System;
using UnityEngine;

namespace AngryBird.Birds
{
    public class JayJake : GameEntity
    {
        public ParticleSystem trailParticles;

        private void Start()
        {
            if (trailParticles != null)
            {
                trailParticles.Play();
            }

            Time = 1.0f;
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            collider2D.isTrigger = false;
        }

        protected override void OnCollisionEnter2D(Collision2D collision)
        {
            base.OnCollisionEnter2D(collision);
            if (trailParticles.isPlaying)
            {
                trailParticles.Stop();
            }
        }
    }
}
