using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GenerateTiles.instance.GenerateLandscape();
        Destroy(gameObject);
    }
}
