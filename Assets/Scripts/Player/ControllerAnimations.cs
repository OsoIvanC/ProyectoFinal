using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ControllerAnimations : MonoBehaviour
{
    Animator animator;

    public Animator GetAnimator { get => animator; }

    Controller controller;

    List<Collider> weaponCollider;

    [SerializeField]
    Collider activeCollider;

    [SerializeField]
    WeaponManager weaponManager;


    private void Awake()
    {
        animator = GetComponent<Animator>();

        controller = GetComponentInParent<Controller>();
    }

    private void LateUpdate()
    {
        //Debug.Log(controller.InputVector.magnitude);
        animator.SetFloat("Magnitude", controller.InputVector.magnitude);
    }

    public void PlayAnimTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }
    
    public void ActivateCollider()
    {
        activeCollider = weaponManager.GetActiveWeapon().GetComponent<Collider>();

        if (activeCollider != null && !activeCollider.enabled)
            activeCollider.enabled = true;
    }
    public void DeactivateCollider()
    {
        if (activeCollider != null && activeCollider.enabled)
            activeCollider.enabled = false;

        activeCollider = null;
    }

}
