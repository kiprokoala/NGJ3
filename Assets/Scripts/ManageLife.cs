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
}
