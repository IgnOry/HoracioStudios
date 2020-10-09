using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{

    public float hp;

    public void takeDamage(float dmg)
    {
        hp -= dmg;
        if (hp < 0)
            Destroy(gameObject);
    }
}
