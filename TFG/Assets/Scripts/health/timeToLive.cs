using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeToLive : health
{

    public float time_ = 1f;

    void Start()
    {
        Destroy(gameObject, time_);
    }
}