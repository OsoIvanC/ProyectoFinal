using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    Transform weaponHolder;

    [SerializeField]
    Weapon activeWeapon;


    public Weapon ActiveWeapon { get { SetActiveWeapon(); return activeWeapon; } }
    ControllerAnimations animations;



    private void Awake()
    {
        SetActiveWeapon();
    }

    void SetActiveWeapon()
    {
        foreach(Transform weapon in weaponHolder)
        {
            if(weapon.gameObject.activeSelf)
            {
                activeWeapon = weapon.GetComponent<Weapon>();
                break;
            }
        }
    }

}
