using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMolotov : MonoBehaviour
{
    public GameObject molotov;
    public GameObject targetM;
    public float distance = 0;
    public float coolDown;

    Vector2 mPos;
    Vector2 gPos;

    private bool abilityUp = true;
    private bool preparing_ = false;

    private GameObject target;

    // Update is called once per frame
    void Update()
    {
        if (abilityUp && Input.GetMouseButton(1))
        {
            PrepareAbility();
            preparing_ = true;
        }

        if (preparing_ && Input.GetMouseButtonUp(1))
        {
            UseAbility();
            abilityUp = false;
            preparing_ = false;
            Invoke("SetAbilityUp", coolDown); //Puede que se necesite el timer para dar el porcentaje
        }
    }

    protected void UseAbility()
    {
        GetComponent<AudioSource>().Play();
        GameObject gun = gameObject.GetComponentInChildren<gunRotation>().gameObject;

        GameObject obj = Instantiate(molotov, gun.transform.position, transform.rotation);
        obj.layer = gameObject.layer;
        obj.GetComponent<Rigidbody>().velocity = new Vector3(mPos.x, gameObject.transform.position.y+5, mPos.y) - obj.transform.position;
        Debug.Log(obj.GetComponent<Rigidbody>().velocity);

        Destroy(target);
    }

    protected void SetAbilityUp()
    {
        abilityUp = true;
    }

    //Show the ability template
    protected void PrepareAbility()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        var layerMask = 1 << LayerMask.NameToLayer("Ground"); // No se si vale para algo

        if (Physics.Raycast(ray, out hit, 100, layerMask)) //Los dos ultimos parámetros son para solo pillar Ground como capa, 100 arbitrario
        {
            Transform objectHit = hit.transform;

            gPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.z);
            mPos = new Vector2(hit.point.x, hit.point.z);

            if (Vector2.Distance(gPos, mPos) < distance)
            {

                if (target != null)
                {
                    target.transform.position = new Vector3(mPos.x, gameObject.transform.position.y, mPos.y);
                }

                else
                {
                    target = Instantiate(targetM, new Vector3(mPos.x, gameObject.transform.position.y, mPos.y), new Quaternion(0, 0, 0, 0));
                    target.transform.Rotate(new Vector3(90, 0, 0));
                }
            }
            else //Falla un poco
            {
                Vector3 diff = mPos - gPos;
                float dist = diff.magnitude;
                if (target == null)
                {
                    target = Instantiate(targetM);
                    target.transform.position = new Vector3(gPos.x, gameObject.transform.position.y, gPos.y) + diff.normalized * distance;
                    target.transform.Rotate(new Vector3(90, 0, 0));
                }

                else
                {
                    target.transform.position = new Vector3(gPos.x, gameObject.transform.position.y, gPos.y) + diff.normalized * distance;
                    mPos = new Vector2(target.transform.position.x, target.transform.position.z);
                }
            }
        }
    }
}
