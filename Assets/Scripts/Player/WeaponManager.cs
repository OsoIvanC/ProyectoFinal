using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;
    [SerializeField] List<Weapon> weapons;
    [SerializeField] public Weapon activeWeapon;
    [SerializeField] ControllerAnimations animations;
    [SerializeField] Controller controller; 
    public List<Weapon> Weapons { get { return weapons; } protected set { weapons = value; } }

    bool toogle;

    private void Awake()
    {

        instance = this;
        animations = GetComponentInParent<ControllerAnimations>();
        controller = GetComponentInParent<Controller>();

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

        if (controller.isAttacking)
            return;

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

    public void ScrollWeapon(Vector2 value)
    {

        if (value.y > 0)
            ChangeWeapon(Controller.Instance.Melee);
        else
            ChangeWeapon(Controller.Instance.Range);
    }

    public void Toogle()
    {
        toogle = !toogle;

        if (toogle)
            ChangeWeapon(Controller.Instance.Melee);
        else
            ChangeWeapon(Controller.Instance.Range);
    }

}
