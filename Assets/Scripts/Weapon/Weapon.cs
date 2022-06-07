using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] protected float maxAmmo;
    [SerializeField] protected float damage;
    
    float ammo;
    
    public virtual void Awake()
    {
        ammo = maxAmmo;
    }
}

public interface IGun
{
    public void Shoot();
    public void Reload();
}
