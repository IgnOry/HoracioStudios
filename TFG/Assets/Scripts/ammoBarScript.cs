using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoBarScript : MonoBehaviour
{
    public Image AmmoBar;
    public float currentAmmo;
    public float maxAmmo;
    private float fill;
    public GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        maxAmmo = gun.GetComponent<normalShoot>().getMaxBullets();
    }

    // Update is called once per frame
    void Update()
    {
        currentAmmo = gun.GetComponent<normalShoot>().getCurrentBullets();

        fill = currentAmmo / maxAmmo;

        AmmoBar.fillAmount = fill;
    }
}
