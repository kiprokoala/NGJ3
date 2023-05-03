using UnityEngine;

public class CollectSunglasses : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.transform.parent = collision.transform;

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer>();

            sp.flipX = rb.velocity.x <= -0.1f || (rb.velocity.x < 0.1f && sp.flipX);
            transform.position = new Vector3(collision.transform.position.x - 0.15f, collision.transform.position.y + 0.85f, 0);

            sp.sortingOrder = 2;
        }

        //Instantiate(gameObject, new Vector3(-0.15f, 0.85f,0), Quaternion.identity);
    }
}
