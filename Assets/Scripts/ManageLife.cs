using UnityEngine;

public class ManageLife : MonoBehaviour
{
    private int health = 10;
    public Lifebar lifebar;

    private void Start()
    {
        lifebar.SetMaxHealth(health);   
    }

    private void Update()
    {
        if (health == 0)
        {
            Death();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Equals(collision.collider.GetType(), typeof(CircleCollider2D)) && collision.enabled && Equals(collision.otherCollider.GetType(), typeof(BoxCollider2D)))
        {
            health--;
            lifebar.setHealth(health);
        }
    }

    private void Death()
    {

    }
}
