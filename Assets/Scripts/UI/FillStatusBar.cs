using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public GameObject player;
    public Image fillImage;
    private Slider slider;
    
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        var fillValue = player.GetComponent<PlayerHealth>().currentHealth / player.GetComponent<PlayerHealth>().maxHealth;
        slider.value = fillValue;
    }
}
