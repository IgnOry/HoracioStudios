using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public float dmg;

    private string team;

    //Only do dagame when collides with other team pj
    private void OnCollisionEnter(Collision collision)
    {
        if (team != collision.gameObject.tag)
        {
            if("Untagged" != collision.gameObject.tag)
            {
                collision.gameObject.GetComponent<health>().takeDamage(dmg);
            }
        }

        Destroy(gameObject);
    }
}
