using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacter : MonoBehaviour
{
    public GameObject HealthBar;
    public GameObject AmmoBar;
    public GameObject Reload;
    public GameObject Ability;
    public FMODUnity.StudioEventEmitter emitter;

    public Abilities abilities;

    float currentHealth;
    float maxHealth;
    float currentAmmo;
    float maxAmmo;

    float fillHealth;
    float fillAmmo;

    // Start is called before the first frame update
    void Start()
    {
        //HealthBar = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        //AmmoBar = gameObject.transform.GetChild(1).GetChild(0).gameObject;
        //Reload = gameObject.transform.GetChild(2).gameObject;

        if (emitter)
            emitter.Play();

        maxHealth = gameObject.transform.parent.GetComponent<health>().maxHealth;
        //Para que sea automatico hace falta uno estandar
        maxAmmo = gameObject.transform.parent.GetChild(2).GetComponent<normalShoot>().getMaxBullets();
    }

    // Update is called once per frame
    void Update()
    {

        //Actualizacion de valores
        currentHealth = gameObject.transform.parent.GetComponent<health>().getCurrentHealth();
        //Para que sea automatico hace falta uno estandar
        currentAmmo = gameObject.transform.parent.GetChild(2).GetComponent<normalShoot>().getCurrentBullets();

        fillHealth = currentHealth / maxHealth;
        fillAmmo = currentAmmo / maxAmmo;

        //Actualización de barras
        changeColorHealth(fillHealth);

        emitter.SetParameter("Health", fillHealth * 100);

        if (fillAmmo <= 0)
        {
            Reload.SetActive(true);
            AmmoBar.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            Reload.SetActive(false);
            AmmoBar.transform.parent.gameObject.SetActive(true);
        }

        if (abilities.abilityUp)
            Ability.SetActive(true);
        else
            Ability.SetActive(false);

        if (fillHealth >= 0 && fillHealth <= 1)
            HealthBar.transform.localScale = new Vector3(fillHealth, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);

        if (fillAmmo >= 0 && fillAmmo <= 1)
            AmmoBar.transform.localScale = new Vector3(fillAmmo, AmmoBar.transform.localScale.y, AmmoBar.transform.localScale.z);
    }

    void changeColorHealth(float fill_)
    {
        if (fill_ >= 0.5)
        {
            HealthBar.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, 100);
        }
        else if (fill_ > 0.25 && fill_ < 0.5)
        {
            HealthBar.GetComponent<SpriteRenderer>().color = new Color(255, 255, 0, 100);
        }
        else if (fill_ <= 0.25)
        {
            HealthBar.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 100);
        }
    }
}
