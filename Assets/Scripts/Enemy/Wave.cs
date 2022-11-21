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
    float statsMultiplier;

    public Wave(float tSpawn,int nEnemies,float sMultiplier = 1.5f)
    {
        timeToSpawn = tSpawn;
        numberOfEnemies = nEnemies;
        statsMultiplier = sMultiplier;
    }
    
   

}
