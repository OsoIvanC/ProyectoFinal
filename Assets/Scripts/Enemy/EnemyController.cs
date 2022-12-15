using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


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


    [Header("UI")]
    [SerializeField]
    protected Slider healthBar;
    [SerializeField]
    protected Image healthImage;

    public void HealthBar()
    {
        healthBar.value = stats.health;

        float perc = (stats.health / stats.maxHealth) * 100;

        if (perc > 75)
            healthImage.color = Color.green;
        else if (perc <= 75 && perc > 50)
            healthImage.color = Color.yellow;
        else if (perc <= 50 && perc > 25)
            healthImage.color = new Color(255, 165, 0);
        else
            healthImage.color = Color.red;
    }


    public virtual void ModifyStats(float value)
    {
        stats.maxHealth *= value;

        stats.health = stats.maxHealth;

        stats.attackDamage *= value;

    }



}


