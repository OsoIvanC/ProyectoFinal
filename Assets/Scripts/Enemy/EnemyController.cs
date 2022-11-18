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
public class EnemyController : MonoBehaviour
{

}


