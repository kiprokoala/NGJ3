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
        //Mort
        if (Input.GetKeyDown(KeyCode.M))
        {
            health--;
            lifebar.setHealth(health);
        }
        //Pouvoir
        if (Input.GetKeyDown(KeyCode.P))
        {
            health++;
            lifebar.setHealth(health);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Equals(collision.GetType(), typeof(CircleCollider2D)) && collision.enabled && Equals(collision.collider.GetType(), typeof(BoxCollider2D)))
        {
            health--;
            lifebar.setHealth(health);
        }
    }
}
