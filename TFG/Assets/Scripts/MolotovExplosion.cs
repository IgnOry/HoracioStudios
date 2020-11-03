using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovExplosion : MonoBehaviour
{
    public GameObject llamas;
    public float delay = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Instantiate(llamas, transform.position, llamas.transform.rotation);
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        transform.Rotate(Vector3.back, 1000f * Time.deltaTime);
    }
}
