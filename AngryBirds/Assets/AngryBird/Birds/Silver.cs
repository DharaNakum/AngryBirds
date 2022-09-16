using UnityEngine;

namespace AngryBird.Birds
{
    public class Silver : Bird
    {
        public override void BirdAbility()
        {
            base.BirdAbility();
            rigidBody.velocity = Vector2.down;
            rigidBody.mass = 4;
            rigidBody.AddForce(Vector2.down*800,ForceMode2D.Force);
        }
    }
}
