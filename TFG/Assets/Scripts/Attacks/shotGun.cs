using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotGun : normalShoot
{
    public float shotAngle_;
    public int shotNum_;

    protected override void Shoot()
    {
        float incr = shotAngle_ / shotNum_;

        for(int i = 0; i < shotNum_; i++) {
            GameObject obj = Instantiate(shot, spawn.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().velocity =  Rotate(gunRot.getGunDir(), (shotAngle_/2.0f) - incr*i) * speed;
            obj.layer = gameObject.layer;
        }
        actualBullets -= shotNum_;
    }

}
