using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadBabySpecialBullet : dieOnHit
{
    public float charmTime; // Amount of damage it does

    //Only do damage when collides with other team pj
    protected override void OnCollisionEnter(Collision collision)
    {
        //Ignore collisions with other bullets and handle collisions with "enemies"
        if ("Wall" != collision.gameObject.tag)
        {
            collision.gameObject.GetComponent<StateMachine>().SetState(States.Charm, charmTime, -GetComponent<Rigidbody>().velocity.normalized);
            //Destroy(gameObject);
        }
        base.OnCollisionEnter(collision);
    }
}
