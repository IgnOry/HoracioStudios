using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public float coolDown;
    public GameObject template;

    public bool abilityUp = true;
    protected bool preparing_ = false;
    private StateMachine states_;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        states_ = GetComponentInParent<StateMachine>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(states_.GetState().state >= States.Charm)
        {
            //we have to test it
            template.SetActive(false);
            preparing_ = false;
        }
        else if(abilityUp && !preparing_ && (Input.GetAxis("FireAbility") != 0 /*|| Input.GetAxis("FireAbility_Joy") != 0*/))
        {
            preparing_ = PrepareAbility();
        }

        if(preparing_ && (Input.GetAxis("FireAbility") == 0 /*|| Input.GetAxis("FireAbility_Joy") == 0*/))
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
        //Debug.Log("Habilidad usada");
    }

    //Show the ability template
    protected virtual bool PrepareAbility()
    {
        //Debug.Log("Lo estoy enseñando");
        return true;
    }

    protected void SetAbilityUp()
    {
        abilityUp = true;
    }
}
