using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badBabyShoot : normalShoot
{
    public float distShield; //Distance from the character to the shield
    public float speedRot; //Speed the bullets rotate
    public GameObject shield;
    //public GameObject parent;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        createShield();
    }


    protected override void Update()
    {
        //Rotate the spawn point to rotate the bullets too
        spawn.Rotate(new Vector3(0.0f, 1.0f, 0.0f)*speedRot * Time.deltaTime, Space.World);
        base.Update();   
    }

    protected override void Shoot()
    {
        base.Shoot();
        resetShield();
        createShield();
    }

    //Creates the bullets that rotates around the player
    private void createShield()
    {
        for (int i = 0; i < actualBullets; i++)
        {
            GameObject obj = Instantiate(shield, spawn.position, Quaternion.identity);
            obj.transform.SetParent(spawn); //Set the bullets as a child from the spawn point
            obj.transform.localPosition = Vector3.zero;
            obj.transform.Translate(Rotate(new Vector3(0.0f, 0.0f, 1.0f), 360*((float)i/(float)actualBullets)).normalized*distShield);
            obj.layer = gameObject.layer;
        }
    }

    private void resetShield()
    {
        foreach (Transform child in spawn)
        {
            Destroy(child.gameObject);
        }
    }

    //Return the number of bullets you have
    private int checkShield()
    {
        return GameObject.FindGameObjectsWithTag("BBShield").Length;
    }

    protected override void Reload()
    {
        base.Reload();
        Invoke("createShield", reloadTime);
    }

    public void killShield()
    {
        actualBullets--;
        resetShield();
        createShield();
    }


}
