using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField]
    HighScore scores;

    [SerializeField]
    Button test;

    //string path;
    private void Awake()
    {
        scores = ReadJson();

        AddScore(new Score(150, "Pedro"));
        AddScore(new Score(150, "Luis"));
        AddScore(new Score(150, "Lupe"));
        AddScore(new Score(120, "Pedro"));
        AddScore(new Score(120, "Lupe"));

        test.onClick.AddListener(SaveIntoJson);
    }
    public void SaveIntoJson()
    {
        scores.scores = Sort(scores.scores);
       
        string json = JsonUtility.ToJson(scores);

        File.WriteAllText(Application.dataPath + "/HighScore.json", json);
    }

    void AddScore(Score s)
    {
        foreach (var score in scores.scores)
        {
            if (score.name == s.name)
            {
                if(s.value > score.value)
                    score.value = s.value;
                
                return;
            }
        }

        scores.scores.Add(s);

    }

    public HighScore ReadJson()
    {
        HighScore hS = new HighScore();

        try
        {
            hS = JsonUtility.FromJson<HighScore>(Application.dataPath + "/HighScore.json");
        }
        catch
        {
            hS = new HighScore();
        }

        return hS;

    }


    public List<Score> Sort(List<Score> s)
    {
        List<Score> highScores = s.OrderBy(order => order.value).ToList();

        highScores.Reverse();

        return highScores;
    }
}

[System.Serializable]
public class HighScore
{
    public List<Score> scores;

    public HighScore()
    {
        scores = new List<Score>();
    }
}
