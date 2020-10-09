using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalShoot : MonoBehaviour
{

    private gunRotation gunRot;
    private float time_ = 0f;

    public Transform spawn;
    public GameObject shot;
    public float speed = 1f;
    public float cadence = 1f;

    void Start()
    {
        gunRot = gameObject.GetComponent<gunRotation>();
    }

    void Update()
    {
        if (time_ <= 0f && Input.GetMouseButtonDown(0))
        {
            Shoot();
            time_ = cadence;
        }
        else
        {
            time_ -= Time.deltaTime;
        }
    }

   
    void Shoot()
    {
        GameObject obj = Instantiate(shot, spawn.position + gunRot.getGunDir(), Quaternion.identity);
        obj.GetComponent<Rigidbody>().velocity = gunRot.getGunDir() * speed;
        obj.tag = gameObject.tag;
        obj.layer = gameObject.layer;
    }
}
