using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public float coolDown;

    private bool abilityUp = true;
    private bool preparing_ = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(abilityUp && Input.GetMouseButtonDown(1))
        {
            PrepareAbility();
            preparing_ = true;
        }

        if(preparing_ && Input.GetMouseButtonUp(1))
        {
            UseAbility();
            abilityUp = false;
            preparing_ = false;
            Invoke("SetAbilityUp", coolDown); //Puede que se necesite el timer para dar el porcentaje
        }
    }

    //Override this method
    protected virtual void UseAbility()
    {
        Debug.Log("Habilidad usada");
    }

    //Show the ability template
    protected virtual void PrepareAbility()
    {
        Debug.Log("Lo estoy enseñando");
    }

    protected void SetAbilityUp()
    {
        abilityUp = true;
    }
}
