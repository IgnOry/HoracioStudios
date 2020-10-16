using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunRotation : MonoBehaviour
{

    private Vector3 gunDir;
    public SpriteRenderer _sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        gunDir = dir.normalized;
        gunDir.z = gunDir.y;
        gunDir.y = 0;
        _sprite.flipY = gunDir.x < 0;
        //Debug.DrawLine(transform.position, transform.position + gunDir, Color.green);
        //Debug.Log(gunDir);
    }

    //this way we can get the direction of aim to shoot
    public Vector3 getGunDir() { return gunDir; }
}
