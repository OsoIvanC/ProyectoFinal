using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    [SerializeField] List<Weapon> weapons;

    Weapon activeWeapon;

    int activeIndex;

    bool isActive;

    private void Awake()
    {
        activeIndex = 0;
        activeWeapon = weapons[0];
        activeIndex = weapons.LastIndexOf(activeWeapon);
        
        InputHandler._instance.actions.Interactions.Melee.performed += _ => activeIndex = 0;
        InputHandler._instance.actions.Interactions.SingleShot.performed += _ => activeIndex = 1;
        InputHandler._instance.actions.Interactions.Automatic.performed += _ => activeIndex = 2;
    }

    void ChangeWeapon(int index)
    {
        if (activeWeapon == weapons[index])
            return;

        activeWeapon = weapons[index];
        activeIndex = weapons.LastIndexOf(activeWeapon);
    }

    void ActivateWeapon()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if(i == activeIndex)
            {
                
            }
        }
    }
}
