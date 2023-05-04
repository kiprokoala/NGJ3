using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            GenerateTiles.instance.GenerateLandscape();
            Destroy(gameObject);
            GenerateTiles.instance.passed_checkpoint++;
            charaMove.instance.upSpeed();
        }
    }
}
