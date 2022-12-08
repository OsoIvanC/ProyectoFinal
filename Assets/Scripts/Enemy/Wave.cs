using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave 
{
    [SerializeField]
    public float timeToSpawn;

    [SerializeField]
    public int numberOfEnemies;


    [SerializeField]
    public int maxMelee;


    [SerializeField]
    public int maxRange;

    [SerializeField]
    float statsMultiplier;

    public Wave(float tSpawn,int maxMelee,int maxRange,float sMultiplier = 1.5f)
    {
        timeToSpawn = tSpawn;
        this.maxMelee = maxMelee;
        this.maxRange = maxRange;

        numberOfEnemies = maxMelee + maxRange;

        statsMultiplier = sMultiplier;
    }
   

}
