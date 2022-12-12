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

    public EnemyStats stats;

    public Transform spawn;

    [Header("AUDIO")]
    [SerializeField]
    protected AudioClip deathClip;
    [SerializeField]
    protected AudioClip activateClip;
    [SerializeField]
    protected AudioClip deactivateClip;
    [SerializeField]
    protected AudioClip attackClip;




    public virtual void ModifyStats(float value)
    {
        stats.maxHealth *= value;

        stats.health = stats.maxHealth;

        stats.attackDamage *= value;

    }



}


