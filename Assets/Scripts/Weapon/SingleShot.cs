using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : Weapon,IGun
{
    [SerializeField]
    Transform barrelPos;
    [SerializeField] LayerMask mask;

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        barrelPos = transform.GetChild(0);
        InputHandler._instance.actions.Interactions.Attack.performed += _ => Shoot();
    }
   
    public void Reload()
    {
        //throw new System.NotImplementedException();
    }

    public void Shoot()
    {
        Debug.Log("Shoot");

        RaycastHit hit;

        if(Physics.Raycast(barrelPos.position,barrelPos.forward,out hit))
        {
            Debug.DrawRay(barrelPos.position, barrelPos.forward * hit.distance, Color.red);
            Debug.Log(hit.collider.name);

            if(hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }
}
