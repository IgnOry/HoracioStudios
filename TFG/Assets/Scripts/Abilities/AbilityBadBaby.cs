using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBadBaby : Abilities
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float speedBullet;

    protected override void PrepareAbility()
    {
        //View template
        base.PrepareAbility();
        template.SetActive(true);
    }

    protected override void UseAbility()
    {
        //Shoot the bullet
        GameObject obj = Instantiate(bullet, spawnPoint.position, bullet.transform.rotation);
        gunRotation gunRot = GetComponent<gunRotation>();
        obj.GetComponent<Rigidbody>().velocity = gunRot.getGunDir() * speedBullet;
        obj.layer = gameObject.layer;

        //Gets the distance from the Ability Template
        obj.GetComponent<BadBabySpecialBullet>().time_ = template.transform.localScale.x / speedBullet;


        //Set everything false
        base.UseAbility();
        template.SetActive(false);
    }
}
