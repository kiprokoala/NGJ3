using UnityEngine;

public class charaMove : MonoBehaviour
{
    private float moveSpeed = 5;
    public int damage = 1;

    private float horizontalMovement;
    private float verticalMovement;

    public Rigidbody2D rb;

    public Animator animator;

    public static charaMove instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime;

        //On met la local scale dans le sens du déplacement du personnage
        transform.localScale = horizontalMovement <= -0.01f ? new Vector3(-1, 1, 1) : (horizontalMovement >= 0.01f) ? new Vector3(1, 1, 1) : transform.localScale;
        animator.SetFloat("speed", Mathf.Abs(horizontalMovement));
    }

    private void Update()
    {
        MovePlayer(horizontalMovement, verticalMovement);
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("isPunching");
        }
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        //On donne la valeur de l'input donné aux positions (pour déplacer de tant)
        float pos_x = transform.position.x + _horizontalMovement;
        float pos_y = transform.position.y + _verticalMovement;

        //On vérifie que ce n'est pas hors bounds
        pos_x = (pos_x > 0) ? pos_x : transform.position.x;
        pos_y = (pos_y <= GenerateTiles.instance.ground_height && pos_y > 1f) ? pos_y : transform.position.y;

        //On donne enfin la valeur à la position du joueur
        transform.position = new Vector3(pos_x, pos_y, 0);
    }

    public void upSpeed()
    {
        moveSpeed += 0.05f;
    }
}