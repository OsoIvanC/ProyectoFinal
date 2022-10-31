using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;
    [SerializeField] List<Weapon> weapons;
    [SerializeField] Weapon activeWeapon;
    [SerializeField] ControllerAnimations animations;
    public List<Weapon> Weapons { get { return weapons; } protected set { weapons = value; } }


    private void Awake()
    {

        instance = this;
        animations = GetComponentInParent<ControllerAnimations>();

        
        activeWeapon = GetActiveWeapon();
    }

    protected Weapon GetActiveWeapon()
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

    public void ChangeWeapon(Weapon newWeapon)
    {
        
        if (activeWeapon == newWeapon)
            return;

        activeWeapon.gameObject.SetActive(false);

        activeWeapon = newWeapon;


        switch (newWeapon.type)
        {
            case WeaponType.SWORD:
                animations.ChangeAnimLayer(1, 1);
                animations.ChangeAnimLayer(2, 0);
                break;
            case WeaponType.GUN:
                animations.ChangeAnimLayer(1, 0);
                animations.ChangeAnimLayer(2, 1);
                break;
            default:
                break;
        }


        activeWeapon.gameObject.SetActive(true);
    }

    
}
