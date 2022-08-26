using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] List<Weapon> weapons;
    //[SerializeField] Weapon activeWeapon;
    public List<Weapon> Weapons { get { return weapons; } protected set { weapons = value; } }
    
    public Weapon GetActiveWeapon()
    {
        Weapon active = null;

        foreach (Weapon weapon in weapons)
        {
            if(weapon.gameObject.activeSelf)
            {
                active = weapon;
                break;
            }
        }
        return active;
    }

}
