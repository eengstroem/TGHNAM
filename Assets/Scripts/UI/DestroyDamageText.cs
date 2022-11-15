using UnityEngine;

public class DestroyDamageText : MonoBehaviour
{
    [SerializeField] private float seconds = 0.5f;
    public Vector3 RandomizeIntensity = new Vector3(0.8f, 0.2f, 0);
    public Vector3 Offset = new Vector3(0, 0.3f, 0);
    void Start()
    {
        Destroy(gameObject, seconds);

        transform.position += Offset;
        transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.x), Random.Range(-RandomizeIntensity.y, RandomizeIntensity.y), 0);
    }
}
