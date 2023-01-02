using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField]
    List<Score> scores;

    [SerializeField]
    Button test;

    string path;
    private void Awake()
    {
        path = Application.persistentDataPath + "/HighScores.json";
        test.onClick.AddListener(SaveIntoJson);

        AddScore(new Score(10,"Carlos"));
        AddScore(new Score(20, "Ivan"));
        AddScore(new Score(30, "Ivan"));
        AddScore(new Score(50, "Carlos"));

    }
    public void SaveIntoJson()
    {

        Debug.Log("Clicked");

        AddScore(new Score(80, "Ivan"));
        AddScore(new Score(90, "Carlos"));

        scores = Sort(scores);
    }

    public void AddScore(Score s)
    {
   
        foreach (var item in scores)
        {
            if (item.name == s.name)
            {
                item.value = s.value;
                return;
            }
        
        }
        scores.Add(s);
    }

    public List<Score> Sort(List<Score> s)
    {
        List<Score> highScores = s.OrderBy(order => order.value).ToList();

        highScores.Reverse();

        return highScores;
    }
   
}
