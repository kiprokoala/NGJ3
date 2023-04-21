using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform camera;
    public float relativeMovement = .5f;

    void Update()
    {
        transform.position = new Vector2(camera.position.x * relativeMovement, transform.position.y);
    }
}
