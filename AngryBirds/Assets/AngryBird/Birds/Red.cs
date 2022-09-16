using UnityEngine;

namespace AngryBird.Birds
{
    public class Red : Bird
    {
        protected override void Start()
        {
            base.Start();
            BirdTypes = BirdType.Red;
        }

        public override void BirdAbility()
        {
            base.BirdAbility();
            if (IsDragging || IsReleased==false)
            {
                return;
            }
            Debug.Log("red blast");
        }
    }
}
