using UnityEngine;
using System.Collections;

namespace AngryBird.Birds
{
    public class Matilda : Bird
    {
        public GameObject egg;
        protected override void Start()
        {
            base.Start();
            BirdTypes = BirdType.Matilda;
        }

        public override void BirdAbility()
        {
            base.BirdAbility();
            Instantiate(egg, transform.position, Quaternion.identity, GameManager.GameManager.Instance.birds);
            rigidBody.AddForce(Vector2.up*700,ForceMode2D.Force);
        }
    }
}
