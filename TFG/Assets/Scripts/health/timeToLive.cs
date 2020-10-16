using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeToLive : health
{

    public float time_ = 1f;

    void Update()
    {
        time_ -= Time.deltaTime;
        if (time_ <= 0)
            Destroy(gameObject);
    }

    public void setTime(float t)
    {
        time_ = t;
    }
}