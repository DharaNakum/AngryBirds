using System;
using UnityEngine;
using System.Collections;

namespace AngryBird.Birds
{
    public class JayJakeJim : Bird
    {
        public bool isTriggered;
        public GameObject jayJakeJim;
        private GameObject m_Jay;
        private GameObject m_Jake;
        protected override void Start()
        {
            base.Start();
            BirdTypes = BirdType.JayJakeJim;
        }

        public override void BirdAbility()
        {
            base.BirdAbility();
            var position = transform.position;
             m_Jay = Instantiate(jayJakeJim, position, Quaternion.identity, GameManager.GameManager.Instance.birds);
            m_Jay.GetComponent<Rigidbody2D>().AddForce((rigidBody.velocity.normalized-new Vector2(0.2f,0.2f))*400,ForceMode2D.Force);
             m_Jake =Instantiate(jayJakeJim, position, Quaternion.identity, GameManager.GameManager.Instance.birds);
            m_Jake.GetComponent<Rigidbody2D>().AddForce((rigidBody.velocity.normalized+new Vector2(0.4f,0.4f))*400,ForceMode2D.Force);
            //rigidBody.AddForce(rigidBody.velocity.normalized*100,ForceMode2D.Force);
        }
    
    }
}
