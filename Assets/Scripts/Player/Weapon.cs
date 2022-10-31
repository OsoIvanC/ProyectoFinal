using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WeaponType
{
    SWORD,
    GUN
}

public class Weapon : MonoBehaviour
{

    [SerializeField] GameObject WeaponGFX;

    public WeaponType type;
    Collider _collider;

    [SerializeField]
    bool _isMelee;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        
        if(_collider == null)
            return;

        _collider.enabled = false;
    }


}
