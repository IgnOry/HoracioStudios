using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySniper : Abilities
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float speedBullet;
    public float multiplier;
    public Camera cam_;

    private float camSize_;
    private normalShoot shootBehaviour_;

    protected FMODUnity.StudioEventEmitter emitter;

    // Start is called before the first frame update
    protected override void Start()
    {
        camSize_ = cam_.orthographicSize;
        shootBehaviour_ = gameObject.GetComponent<normalShoot>();

        if (!shootBehaviour_)
            Debug.Log("What the fucvk????");

        foreach (FMODUnity.StudioEventEmitter em in gameObject.GetComponents<FMODUnity.StudioEventEmitter>())
        {
            if (em.Event == "event:/Abilities/ShootingAbilities")
            {
                emitter = em;
            }
            else
            {
                //Debug.Log(em.Event);
            }
        }

        base.Start();
    }

    protected override bool PrepareAbility()
    {
        shootBehaviour_.SetBlockShoot(true);

        template.SetActive(true);

        cam_.orthographicSize *= multiplier;

        //View template
        base.PrepareAbility();

        return true;
    }

    protected override void UseAbility()
    {
        cam_.orthographicSize = camSize_;

        //Shoot the bullet
        GameObject obj = Instantiate(bullet, spawnPoint.position, transform.rotation);
        gunRotation gunRot = gameObject.GetComponent<gunRotation>();
        obj.GetComponent<Rigidbody>().velocity = gunRot.getGunDir() * speedBullet;
        obj.layer = gameObject.layer;

        if (emitter)
            emitter.Play();

        //Set everything false
        base.UseAbility();

        shootBehaviour_.SetBlockShoot(false);

        template.SetActive(false);
    }
}
