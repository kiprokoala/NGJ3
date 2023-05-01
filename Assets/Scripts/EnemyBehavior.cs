using UnityEngine;

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
            animator.SetTrigger("moving");
        }
        else
        {
            animator.ResetTrigger("moving");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Equals(collision.GetType(), typeof(BoxCollider2D)))
        {
            Debug.Log(collision.GetType() + " + " + collision.enabled);
        }
        if (Equals(collision.GetType(), typeof(CircleCollider2D)) && collision.enabled)
        {
            life -= 1;
        }
    }
}
