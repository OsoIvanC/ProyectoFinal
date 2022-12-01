using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;


[System.Serializable]
public struct EnemyStats
{
    public float maxHealth;

    
    public float health;

    
    public float attackRange;

    
    public float attackDamage;

}
public class EnemyController : MonoBehaviour
{
    
    public  EnemyStats stats;

   

    [SerializeField]
    protected AudioClip deathClip;


}


