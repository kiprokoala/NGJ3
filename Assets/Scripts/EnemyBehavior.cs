using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int life = 1;
    public float moveSpeed = 0.5f;

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
        Vector3 displacement = _player.transform.position - transform.position;
        displacement = displacement.normalized;
        if (Vector2.Distance(_player.transform.position, transform.position) > 1.0f)
        {
            transform.position += (displacement * moveSpeed * Time.deltaTime);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Equals(collision.GetType(), typeof(CircleCollider2D)))
        {
            life -= 1;
        }
    }
}
