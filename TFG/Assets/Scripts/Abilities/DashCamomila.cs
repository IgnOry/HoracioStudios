using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCamomila : Abilities
{

    public Animator _animator;
    public float dashSpeed;
    public float dashTime;

    public float startTime;

    public FMODUnity.StudioEventEmitter emitter;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (startTime > 0 && Time.fixedTime >= startTime + dashTime)
            EndDash();
    }

    protected override bool PrepareAbility()
    {
        if (!gameObject.GetComponentInParent<basicMovement3D>().getAnimator().GetBool("moving"))
            return false;

        float x = gameObject.GetComponentInParent<basicMovement3D>().getMoveX();
        float z = gameObject.GetComponentInParent<basicMovement3D>().getMoveZ();

        gameObject.GetComponentInParent<basicMovement3D>().enabled = false;
        //Use ability turbio

        x *= dashSpeed;
        z *= dashSpeed;

        bool spriteFlip = gameObject.GetComponentInParent<basicMovement3D>().getSpriteFlip();

        gameObject.GetComponentInParent<basicMovement3D>().getAnimator().SetBool("backwards", (x > 0f && spriteFlip) || (x <= 0f && !spriteFlip));
        gameObject.GetComponentInParent<basicMovement3D>().getAnimator().ResetTrigger("stopDash");
        gameObject.GetComponentInParent<basicMovement3D>().getAnimator().SetTrigger("dashing");
        //gameObject.GetComponentInParent<basicMovement3D>().getAnimator().Play("dashing");

        gameObject.GetComponentInParent<Rigidbody>().velocity = new Vector3(x, gameObject.GetComponentInParent<Rigidbody>().velocity.y, z);

        startTime = Time.fixedTime;

        emitter.Play();

        return true;
    }

    protected void EndDash()
    {
        startTime = -1;

        gameObject.GetComponentInParent<basicMovement3D>().getAnimator().ResetTrigger("dashing");
        gameObject.GetComponentInParent<basicMovement3D>().getAnimator().SetTrigger("stopDash");
        //gameObject.GetComponentInParent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        gameObject.GetComponentInParent<basicMovement3D>().enabled = true;
    }
}
