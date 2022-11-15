using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneTimer : MonoBehaviour
{
    private float timer = 7f;
    [SerializeField] private TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = "Skip ad in: " + timer.ToString("f0");
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
