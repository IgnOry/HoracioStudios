using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalShoot : MonoBehaviour
{

    private float time_ = 0f;

    protected gunRotation gunRot;
    public int actualBullets_;

    public feedBackCam cam;
    public Transform spawn;
    public GameObject shot;
    public float speed = 1f;
    public float cadence = 1f;
    public float reloadTime = 1f; //Time it takes to reload
    public int numBullets = 1;
    //public float bulletTTL = 1f; //Time bullets live

    void Start()
    {
        gunRot = gameObject.GetComponent<gunRotation>();
        actualBullets_ = numBullets;
    }

    void Update()
    {
        if (time_ <= 0f && actualBullets_ > 0 && (Input.GetAxis("Fire") != 0 || Input.GetAxis("Fire_Joy") != 0))
        {
            Shoot();
            cam.startShaking();
            time_ = cadence;
        }
        else if (actualBullets_ <= 0)
        {
            actualBullets_ = numBullets;
            time_ = reloadTime;
        }
        else
        {
            time_ -= Time.deltaTime;
        }
    }

    //This is a virtual method and will be different for each character
    protected virtual void Shoot()
    {
        GameObject obj = Instantiate(shot, spawn.position, transform.rotation);
        obj.GetComponent<Rigidbody>().velocity = gunRot.getGunDir() * speed;
        obj.layer = gameObject.layer;
        actualBullets_--;
    }
}
