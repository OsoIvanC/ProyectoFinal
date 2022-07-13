using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    [SerializeField] float health;


    private void Awake()
    {
        instance = this;
    }

    public void TakeDamage(float value)
    {
        Debug.Log("Taking Damage");
        
        health -= value;


        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
