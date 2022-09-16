using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AngryBird.Catapult
{
    public class Catapult : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] birdPrefab = null;
        
        [SerializeField]
        private GameObject centerPoint = null;

        public Birds.Bird currentBird;
        public GameObject CenterPoint => centerPoint;
        public int[] birdsIndices ;
        public static int Index;

        private void Start()
        {
            Index = 0;
            AddBird();
        }

        public void AddBird()
        {
            
            int index = birdsIndices[Index];
            GameObject birdGameObject = Instantiate(birdPrefab[index], GameManager.GameManager.Instance.birds, true);
            
            birdGameObject.transform.position = centerPoint.transform.position;

            Birds.Bird bird = birdGameObject.GetComponent<Birds.Bird>();
            currentBird = bird;//change
            Index++;
            GameManager.GameManager.Instance.attempts--;
            UiManager.Instance.gamePlayView.SetAttempt(GameManager.GameManager.Instance.attempts);
            //Birds.SpriteType spriteType= GameManager.GameManager.Instance.birdData.GetSpriteType(Random.Range(0, 3));
            //Bird.SpriteType spriteType= GameManager.GameManager.Instance.birdData.GetSpriteType(1);
            //bird.SetSprite(spriteType);
        }
        
      
    }
}
