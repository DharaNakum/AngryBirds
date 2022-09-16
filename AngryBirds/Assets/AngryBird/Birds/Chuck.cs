using System;
using UnityEditor;
using UnityEngine;

namespace AngryBird.Birds
{
    public class Chuck : Bird
    {
        protected override void Start()
        {
           base.Start();
           SpeedMultiplier = 1;
           BirdTypes = BirdType.Chuck;
        }

        public override void BirdAbility()
        {
            base.BirdAbility();
            rigidBody.AddForce(rigidBody.velocity.normalized*400,ForceMode2D.Force);
            //rigidBody.AddForce();
            //ForceBird(SpeedMultiplier);
        }
    }
}
