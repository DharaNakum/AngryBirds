using UnityEngine;
using UnityEngine.SceneManagement;

namespace AngryBird.Views
{
    public class GameOverView : MonoBehaviour
    {
        public void OnLevelClick()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("LevelSelection");
        }
        public void OnReloadClick()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
