using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Profiling.Experimental;

public class EnemyBehavior : MonoBehaviour
{
    public int maxLife;
    private int life;
    public float moveSpeed;

    public Animator animator;

    private void Start()
    {
        moveSpeed += GenerateTiles.instance.passed_checkpoint / 1000;
        life = maxLife;
    }

    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
            Points.instance.addPoint(maxLife);
        }
        moveEnemy();
    }

    void moveEnemy()
    {
        GameObject _player = GameObject.FindGameObjectWithTag("Player");

        //On amène l'ennemi vers le joueur
        Vector3 move = (_player.transform.position - transform.position).normalized;
        //On vérifie qu'il n'est pas trop loin du joueur (pour s'arrêter et taper)
        if (Mathf.Abs(_player.transform.position.x - transform.position.x) > 1.4f)
        {
            transform.localScale = move.x <= -0.01f ? new Vector3(-1, 1, 1) : (move.x >= 0.01f) ? new Vector3(1, 1, 1) : transform.localScale;
            transform.position += (move * moveSpeed * Time.deltaTime);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Equals(collision.collider.GetType(), typeof(CircleCollider2D)) && collision.enabled && Equals(collision.otherCollider.GetType(), typeof(BoxCollider2D)) && collision.transform.tag == "Player")
        {
            life -= charaMove.instance.damage;
        }
    }
}
