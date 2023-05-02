using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Profiling.Experimental;

public class EnemyBehavior : MonoBehaviour
{
    public int life = 1;
    public float moveSpeed = 0.5f;

    public Animator animator;

    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
            Points.instance.addPoint();
        }
        moveEnemy();
    }

    void moveEnemy()
    {
        GameObject _player = GameObject.FindGameObjectWithTag("Player");

        //On amène l'ennemi vers le joueur
        Vector3 move = _player.transform.position - transform.position;
        move = move.normalized;
        float distance = Vector2.Distance(_player.transform.position, transform.position);
        if (distance > 1.0f)
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
        Debug.Log(collision.collider.GetType() + "<- me || them -> " + collision.otherCollider.GetType());
        if (Equals(collision.collider.GetType(), typeof(CircleCollider2D)) && collision.enabled && Equals(collision.otherCollider.GetType(), typeof(BoxCollider2D)))
        {
            life -= 1;
        }
    }
}
