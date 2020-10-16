using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieOnHit : timeToLive
{
    private void OnCollisionEnter(Collision collision)
    {
        //Other bullets cant destroy this bullet
        if(collision.gameObject.tag == "Bullet")
        {
            //And ignore the collision with bullets that can collide
            Physics.IgnoreCollision(collision.collider, GetComponent<Collision>().collider);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
