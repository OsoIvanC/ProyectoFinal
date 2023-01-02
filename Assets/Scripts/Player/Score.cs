using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Score 
{
    public int value;
    public string name;

    public Score(int v,string n)
    {
        value = v;
        name = n;
    }
}
