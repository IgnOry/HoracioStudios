using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityChuerk : MonoBehaviour
{
    public GameObject cuesco;
    float gas = 0.4f;
    float cooldown = 0.06f;
    float actualCD = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gas < 0.0f)
            gas = 0.0f;
        GetComponent<basicMovement3D>().speed = Input.GetKey(KeyCode.Return) && gas > 0.0f ? 8f : 5f;
        if (Input.GetKey(KeyCode.Return))
        {
            gas -= Time.deltaTime;
            actualCD += Time.deltaTime;
            if (actualCD > cooldown && gas > 0.0f)
            {
                GameObject newCuesco = GameObject.Instantiate(cuesco);
                newCuesco.transform.position = this.transform.position;
                newCuesco.GetComponent<Turbocuesco>().setTag(transform.tag);
                actualCD = 0.0f;
            }
        }
        else if (gas < 0.8f)
        {
            gas += Time.deltaTime;
        }
        Debug.Log("GAS: " + gas);
    }
}
