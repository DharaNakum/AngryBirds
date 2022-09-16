using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AngryBird.Views
{
    public class StartView : MonoBehaviour
    {
        private void Start()
        {
            //throw new NotImplementedException();
            StartCoroutine(Wait());
        }
        private IEnumerator Wait()
        {

            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("LevelSelection");
        }
    }
}
