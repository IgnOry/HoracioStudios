using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public void takeDamage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth < 0)
            Destroy(gameObject);
    }
}
