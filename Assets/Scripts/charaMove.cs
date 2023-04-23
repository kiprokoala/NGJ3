using UnityEngine;

public class charaMove : MonoBehaviour
{
    public float moveSpeed;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;

    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime;

        //On met la local scale dans le sens du déplacement du personnage
        transform.localScale = horizontalMovement <= -0.01f ? new Vector3(-1, 1, 1) : (horizontalMovement >= 0.01f) ? new Vector3(1, 1, 1) : transform.localScale;
    }

    private void Update()
    {
        MovePlayer(horizontalMovement, verticalMovement);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        transform.position = new Vector3(transform.position.x + _horizontalMovement, transform.position.y + _verticalMovement, 0);
        }
}