using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{

    [SerializeField] GameObject WeaponGFX;
    Collider _collider;
    

    private void Awake()
    {
        _collider = GetComponent<Collider>();

        _collider.enabled = false;
    }


}
