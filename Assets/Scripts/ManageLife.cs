using UnityEngine;

public class ManageLife : MonoBehaviour
{
    private int health = 10;
    public Lifebar lifebar;
    [SerializeField]
    private GameObject deathMenu;

    private void Start()
    {
        lifebar.SetMaxHealth(health);   
    }

    private void Update()
    {

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
}
