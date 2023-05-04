using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ManageLife.instance.getMaxHealth() != ManageLife.instance.getHealth() && collision.tag == "Player")
        {
            ManageLife.instance.heal(3);
            Destroy(gameObject);
        }
    }
}
