using UnityEngine;

namespace AngryBird.Birds
{
    public class Bomb : Bird
    {
        [SerializeField]
        private PointEffector2D pointEffector2D;
        protected override void Start()
        {
            base.Start();
            BirdTypes = BirdType.Bomb;
        }

        public override void BirdAbility()
        {
            base.BirdAbility();
            pointEffector2D.forceMagnitude = 100.0f;
            Die();
        }

        protected override void Die()
        {
            base.Die();
            if (deathParticles != null)
            {
                deathParticles.Play();
            }
            pointEffector2D.forceMagnitude = 100;
            rigidBody.isKinematic = true;
        }
        
    }
}
