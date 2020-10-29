using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public float coolDown;

    private bool abilityUp = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(abilityUp && Input.GetMouseButton(1))
        {
            ShowAbility();
        }

        if(abilityUp && Input.GetMouseButtonUp(1))
        {
            UseAbility();
            abilityUp = false;
            Invoke("SetAbilityUp", coolDown);
        }
    }

    //Override this method
    protected virtual void UseAbility()
    {
        //Debug.Log("Habilidad usada");
    }

    //Show the ability template
    protected virtual void ShowAbility()
    {
        //Debug.Log("Lo estoy enseñando");
    }

    protected void SetAbilityUp()
    {
        abilityUp = true;
    }
}
