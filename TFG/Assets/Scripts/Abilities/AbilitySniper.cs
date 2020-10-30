using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySniper : Abilities
{
    public GameObject template;
    public GameObject bullet;
    public Transform spawnPoint;
    public float speedBullet;
    public float multiplier;
    public Camera cam_;

    private float camSize_;
    private normalShoot shootBehaviour_;

    // Start is called before the first frame update
    void Start()
    {
        camSize_ = cam_.orthographicSize;
        shootBehaviour_ = GetComponent<normalShoot>();
    }

    protected override void PrepareAbility()
    {
        //View template
        base.PrepareAbility();
        shootBehaviour_.SetBlockShoot(true);
        template.SetActive(true);

        cam_.orthographicSize *= multiplier;
    }

    protected override void UseAbility()
    {
        cam_.orthographicSize = camSize_;

        //Shoot the bullet
        GameObject obj = Instantiate(bullet, spawnPoint.position, transform.rotation);
        gunRotation gunRot = GetComponent<gunRotation>();
        obj.GetComponent<Rigidbody>().velocity = gunRot.getGunDir() * speedBullet;
        obj.layer = gameObject.layer;


        //Set everything false
        base.UseAbility();
        shootBehaviour_.SetBlockShoot(false);
        template.SetActive(false);
    }
}
