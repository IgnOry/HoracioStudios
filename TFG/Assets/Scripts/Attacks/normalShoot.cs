using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalShoot : MonoBehaviour
{

    private float time_ = 0f;
    private bool block_ = false;

    protected gunRotation gunRot;

    public int actualBullets;
    public feedBackCam cam;
    public Transform spawn;
    public GameObject shot;
    public float speed = 1f;
    public float cadence = 1f;
    public float reloadTime = 1f; //Time it takes to reload
    public int maxBullets = 1;
    public bool rotateBullet = true;
    //public float bulletTTL = 1f; //Time bullets live

    protected virtual void Start()
    {
        gunRot = gameObject.GetComponent<gunRotation>();
        actualBullets = maxBullets;
    }

    protected virtual void Update()
    {
        if (!block_ && time_ <= 0f && actualBullets > 0 && (Input.GetAxis("Fire") != 0 || Input.GetAxis("Fire_Joy") != 0))
        {
            Shoot();
            cam.startShaking();
            time_ = cadence;
        }
        else if (actualBullets <= 0)
        {
            Reload();
        }
        else
        {
            time_ -= Time.deltaTime;
        }
    }

    //This is a virtual method and will be different for each character
    protected virtual void Shoot()
    {
        GameObject obj;
        if (rotateBullet)
            obj = Instantiate(shot, spawn.position, transform.rotation);
        else
            obj = Instantiate(shot, spawn.position, Quaternion.identity);
        
        obj.GetComponent<Rigidbody>().velocity = gunRot.getGunDir() * speed;

        //fixes rotation so bullet looks in the direction it's shot
        if (rotateBullet)
        {
            obj.transform.rotation = Quaternion.LookRotation(obj.GetComponent<Rigidbody>().velocity, Vector3.up);
            obj.transform.rotation *= Quaternion.Euler(90, -90, 0);
        }

        obj.layer = gameObject.layer;
        actualBullets--;
    }

    protected virtual void Reload()
    {
        actualBullets = maxBullets;
        time_ = reloadTime;
    }

    protected Vector3 Rotate(Vector3 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.z;
        v.x = (cos * tx) - (sin * ty);
        v.z = (sin * tx) + (cos * ty);
        return v.normalized;
    }

    public int getCurrentBullets()
    {
        return actualBullets;
    }

    public int getMaxBullets()
    {
        return maxBullets;
    }

    public void SetBlockShoot(bool set)
    {
        block_ = set;
    }

}
