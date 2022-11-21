using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;





[System.Serializable]
enum EnemyType
{
    MELEE,
    RANGE
}

[System.Serializable]
struct EnemyStats
{
    [SerializeField]
    float maxHealth;

    [SerializeField]
    float health;

    [SerializeField]
    float attackRange;

    [SerializeField]
    float attackDamage;


}
public class EnemyController : MonoBehaviour, IController
{
    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Death()
    {
        throw new System.NotImplementedException();
    }

    public void Gravity()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    public void Rotate()
    {
        throw new System.NotImplementedException();
    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float value)
    {
        throw new System.NotImplementedException();
    }
}


