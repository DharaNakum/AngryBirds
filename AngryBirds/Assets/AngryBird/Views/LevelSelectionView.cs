using UnityEngine;
using UnityEngine.SceneManagement;

namespace AngryBird.Views
{
    public class LevelSelectionView : MonoBehaviour
    {
        public void OnLevelOneClick()
        {
            SceneManager.LoadScene("Game");
        }
        public void OnLevelTwoClick()
        {
            SceneManager.LoadScene("Level2");
        }
        public void OnLevelThreeClick()
        {
            SceneManager.LoadScene("Level3");
        }
        public void OnLevelFourClick()
        {
            SceneManager.LoadScene("Level4");
        }
        public void OnLevelFiveClick()
        {
            SceneManager.LoadScene("Level5");
        }
    }
}
