using UnityEngine;

public class ManageLife : MonoBehaviour
{
    private int maxHealth = 10;
    private int health;

    [SerializeField]
    private Lifebar lifebar;
    [SerializeField]
    private GameObject deathMenu;

    public static ManageLife instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;
        lifebar.SetMaxHealth(health);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Equals(collision.collider.GetType(), typeof(CircleCollider2D)) && collision.enabled && Equals(collision.otherCollider.GetType(), typeof(BoxCollider2D)))
        {
            health--;
            lifebar.setHealth(health);
            if (health == 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        deathMenu.SetActive(true);

        //On prend le meilleur score
        PlayerPrefs.SetInt("best", PlayerPrefs.GetInt("best") > Points.instance.getScore() ? PlayerPrefs.GetInt("best") : Points.instance.getScore());
        Time.timeScale = 0;
        charaMove.instance.enabled = false;
        Menu.instance.fillInfo();
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int getHealth()
    {
        return health;
    }

    public void heal(int bonus)
    {
        if (health + bonus >= maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += bonus;
        }
        lifebar.setHealth(health);
    }
}
