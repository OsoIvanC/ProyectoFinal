using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ControllerAnimations : MonoBehaviour
{
    Animator animator;

    public Animator GetAnimator { get => animator; }

    Controller controller;

    [SerializeField]
    Collider activeCollider;

    [SerializeField]
    Inventory inventory;


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
        activeCollider = inventory.ActiveWeapon.GetComponent<Collider>();

        if (activeCollider != null && !activeCollider.enabled)
            activeCollider.enabled = true;
    }

    public void ChangeAnimLayer(int layer, int value)
    {
        animator.SetLayerWeight(layer, value);
    }
    public void DeactivateCollider()
    {
        if (activeCollider != null && activeCollider.enabled)
            activeCollider.enabled = false;

        activeCollider = null;
    }

}
