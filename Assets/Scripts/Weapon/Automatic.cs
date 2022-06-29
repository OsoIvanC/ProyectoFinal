using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic : MonoBehaviour,IGun
{
    bool isShooting;
    bool isReloading;
    
    [SerializeField]
    float bulletDamage;
    
    [SerializeField] 
    Transform barrelPos;
    
    [SerializeField]
    float fireRate;
    
    [SerializeField]
    int maxAmmo;

    [SerializeField]
    float reloadTime;


    int ammoClip;
    float nextFire;

    public void Reload()
    {
       StartCoroutine(Reloading());
    }

    IEnumerator Reloading()
    {
        isReloading = true;

        Debug.Log("RELOADING");
        yield return new WaitForSeconds(reloadTime);
        Debug.Log("FINISHED RELODING");
        ammoClip = maxAmmo;

        isReloading = false;
    }
    public void Shoot()
    {
        //Debug.Log("Shoot");

        RaycastHit hit;

        if(ammoClip <= 0)
            Reload();

        if (isReloading)
            return;
 
       if (Physics.Raycast(barrelPos.position, barrelPos.forward, out hit))
       {
           //Debug.DrawRay(barrelPos.position, barrelPos.forward * hit.distance, Color.red);
           //Debug.Log(hit.collider.name);


           if (Time.time > 1 / fireRate + nextFire)
           {
              ammoClip--;
              if (hit.collider.CompareTag("Enemy"))
              {
                   hit.collider.GetComponent<Enemy>().TakeDamage(bulletDamage);
              }
              nextFire = Time.time;
           }
       }

    }

    void Start()
    {
        barrelPos = transform.GetChild(0);
        InputHandler._instance.actions.Interactions.Attack.performed += _ => isShooting = true;
        InputHandler._instance.actions.Interactions.Attack.canceled += _ => isShooting = false;
        ammoClip = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting)
            Shoot();

        Debug.DrawRay(barrelPos.position, barrelPos.forward * 10, Color.red);
        Debug.Log(ammoClip);
    }
}
