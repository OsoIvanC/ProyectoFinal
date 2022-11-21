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

    public float Health;

}
public class EnemyController : MonoBehaviour
{
    [SerializeField]
    protected EnemyStats stats;

}


