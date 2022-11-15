using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.UI
{
    public class SceneSelect : MonoBehaviour
    {
        public void OpenScene()
        {
            SceneManager.LoadScene("StoryScreen");
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}