using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacter : MonoBehaviour
{
    public GameObject UI_Prefab;

    public GameObject healthBar;
    public GameObject ammoBar;

    public Image HealthBar;
    public Image AmmoBar;

    float currentHealth;
    float maxHealth;
    float currentAmmo;
    float maxAmmo;

    float fillHealth;
    float fillAmmo;

    // Start is called before the first frame update
    void Start()
    {
        Canvas canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        GameObject auxUI = Instantiate(UI_Prefab, canvas.transform);
        healthBar = auxUI.transform.GetChild(0).gameObject;
        ammoBar = auxUI.transform.GetChild(1).gameObject;

        HealthBar = auxUI.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        AmmoBar = auxUI.transform.GetChild(1).GetChild(0).GetComponent<Image>();

        maxHealth = gameObject.transform.parent.GetComponent<health>().maxHealth;
        //Para que sea automatico hace falta uno estandar
        maxAmmo = gameObject.transform.parent.GetChild(2).GetComponent<normalShoot>().getMaxBullets();
    }

    // Update is called once per frame
    void Update()
    {

        //Actualizacion de posicion
        Vector3 pos0 = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 pos1 = Camera.main.WorldToScreenPoint(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 0.5f));
        healthBar.transform.position = pos0;
        ammoBar.transform.position = pos1;

        //Actualizacion de valores
        currentHealth = gameObject.transform.parent.GetComponent<health>().getCurrentHealth();
        //Para que sea automatico hace falta uno estandar
        currentAmmo = gameObject.transform.parent.GetChild(2).GetComponent<normalShoot>().getCurrentBullets();

        fillHealth = currentHealth / maxHealth;
        fillAmmo = currentAmmo / maxAmmo;

        //Actualización de barras
        changeColorHealth(fillHealth);
        HealthBar.fillAmount = fillHealth;
        AmmoBar.fillAmount = fillAmmo;
    }

    void changeColorHealth(float fill_)
    {
        if (fill_ >= 0.5)
        {
            HealthBar.color = new Color(0, 255, 0, 100);
        }
        else if (fill_ > 0.25 && fill_ < 0.5)
        {
            HealthBar.color = new Color(255, 255, 0, 100);
        }
        else if (fill_ <= 0.25)
        {
            HealthBar.color = new Color(255, 0, 0, 100);
        }
    }
}
