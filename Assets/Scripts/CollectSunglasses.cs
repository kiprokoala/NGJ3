using System.Collections;
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

            SpriteRenderer sp_player = collision.GetComponent<SpriteRenderer>();

            sp.flipX = sp_player.flipX;
            transform.position = new Vector3(collision.transform.position.x - 0.15f, collision.transform.position.y + 0.85f, 0);

            sp.sortingOrder = 2;
            charaMove.instance.damage = 100000;

            StartCoroutine(GiveAwaySunglasses(collision.transform));
        }
    }

    IEnumerator GiveAwaySunglasses(Transform transform)
    {
        yield return new WaitForSeconds(10f);
        charaMove.instance.damage = 1;
        Destroy(gameObject);
    }
}
