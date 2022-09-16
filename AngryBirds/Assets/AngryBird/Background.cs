using System;
using UnityEngine;

namespace AngryBird
{
    public class Background : MonoBehaviour
    {
        [SerializeField]
        private Collider2D myCollider;

        public void SetCollider(bool isEnabled)
        {
            myCollider.isTrigger = isEnabled;
            myCollider.enabled = isEnabled;
        }
        
        private void OnMouseDown()
        {
            //if(GameManager.GameManager.Instance.)
            Debug.Log("on background mouse up");
            GameManager.GameManager.Instance.catapult.currentBird.BirdAbility();
            SetCollider(false);
        }
    }
}
