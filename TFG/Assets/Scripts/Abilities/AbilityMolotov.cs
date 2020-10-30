using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMolotov : Abilities
{
    public GameObject molotov;
    public float speed;
    public float distance = 0;
    //Override this method
    override protected void UseAbility()
    {
        //Instanciar molotov
        GameObject gun = gameObject.GetComponentInChildren<gunRotation>().gameObject;
        GameObject obj = Instantiate(molotov, gun.transform.position, transform.rotation);

        Vector3 vel = gun.GetComponent<gunRotation>().getGunDir() * speed;
        vel.y = distance;

        obj.GetComponent<Rigidbody>().velocity = vel;
        Debug.Log(obj.GetComponent<Rigidbody>().velocity);
        obj.layer = gameObject.layer;        
        //En direccion a donde apunta el arma
        base.UseAbility();
        distance = 0;
    }

    //Show the ability template
    override protected void PrepareAbility()
    {
        //base.PrepareAbility();

        if (Input.GetMouseButton(1))
        {
            if (distance < 2f)
            distance += 0.005f;
        }

    }

    /*override*/ void Update()
    {
        if (Input.GetMouseButton(1))
        {
            PrepareAbility();
            //preparing_ = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            UseAbility();

            Invoke("SetAbilityUp", coolDown); //Puede que se necesite el timer para dar el porcentaje
        }
    }
}
