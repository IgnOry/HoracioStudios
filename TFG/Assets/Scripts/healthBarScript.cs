using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class healthBarScript : MonoBehaviour
{
    public Image HealthBar;
    public float currentHealth;
    public float maxHealth;
    private float fill;
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = character.GetComponent<health>().maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //currentHealth;
        currentHealth = character.GetComponent<health>().currentHealth;

        fill = currentHealth / maxHealth;

        changeColor(fill);

        HealthBar.fillAmount = fill;
    }

    void changeColor(float fill_)
    {
        if (fill_ >= 0.5)
        {
            HealthBar.color = new Color(0, 255, 0, 100);
        }
        else if (fill > 0.25 && fill < 0.5)
        {
            HealthBar.color = new Color(255, 255, 0, 100);
        }
        else if (fill <= 0.25)
        {
            HealthBar.color = new Color(255, 0, 0, 100);
        }
    }
}
