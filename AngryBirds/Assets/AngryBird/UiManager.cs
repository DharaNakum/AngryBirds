using AngryBird.Views;
using UnityEngine;

namespace AngryBird
{
    public class UiManager : MonoBehaviour
    {
        public static UiManager Instance;
        public Views.GamePlayView gamePlayView;
        public Views.GameOverView gameOverView;
        private void Awake()
        {
            if (Instance==null)
            {
                Instance = this;
            }
        }
    }
}
