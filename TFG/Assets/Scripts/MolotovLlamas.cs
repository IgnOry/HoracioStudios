using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovLlamas : MonoBehaviour
{
    //Esto es una burda imitación de Turbocuesco.cs, a falta de temas de balanceado

    public float despawnTime;
    float actualCD = 0;
    public float damagePerTick = 0.1f;
    string damageTag;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0); //Si no se ve feucho
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (actualCD < despawnTime)
            actualCD += Time.deltaTime;
        else
            Destroy(this.gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        //other.GetComponent<health>().takeDamage(damagePerTick); //Para testear

        if (other.tag == damageTag)
        {
            other.GetComponent<health>().takeDamage(damagePerTick);
        }
    }

    public void setTag(string tag)
    {
        damageTag = tag == "ATeam" ? "BTeam" : "ATeam";
    }
}
