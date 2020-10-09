using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedBackCam : MonoBehaviour
{

    public float time_ = 1.0f; //Time it moves
    public float intensity_ = 1.0f;
    public normalShoot normalShoot_;

    private Vector3 vectorPos_;
    private float t_;
    private float cadence_;

    void Start()
    {
        vectorPos_ = transform.position - transform.parent.position;
        t_ = 0;
        cadence_ = normalShoot_.cadence;
    }

    void Update()
    {
        if (cadence_ <= 0f && Input.GetMouseButtonDown(0))
        {
            t_ = time_;
            cadence_ = normalShoot_.cadence;
            Debug.Log(transform.position);
            Debug.Log(vectorPos_);
        }
        else if(cadence_ > -1f)
            cadence_ -= Time.deltaTime;

        Shake();
    }

    void Shake()
    {
        if (t_ > 0)
        {
            transform.position = (vectorPos_ + transform.parent.position) + new Vector3(Random.insideUnitCircle.x, 0,Random.insideUnitCircle.y) * intensity_;
            t_ -= Time.deltaTime;
            if (t_ <= 0)
                transform.position = vectorPos_ + transform.parent.position;
        }
    }
}