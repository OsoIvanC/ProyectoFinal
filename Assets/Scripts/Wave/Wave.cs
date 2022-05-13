using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int numberOfEnemies { get; private set; }
    public float statsModifier { get; private set; }
    public List<Enemy> enemies { get; private set; }




}
