using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    public int level;

    public TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "Level" + level.ToString();
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + level);
    }
}
