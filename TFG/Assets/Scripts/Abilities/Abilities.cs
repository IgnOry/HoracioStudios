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
        
    }

    //Override this method
    protected virtual void UseAbility()
    {

    }

    protected void SetAbilityUp()
    {
        abilityUp = true;
    }
}
