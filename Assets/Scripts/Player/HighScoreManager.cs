using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class HighScoreManager : MonoBehaviour
{
    [SerializeField]
    public static HighScore scores;

    public static HighScoreManager instance;

    [SerializeField]
    TMPro.TMP_Text[] highScores;

    //string path;
    private void Awake()
    {
        instance = this;
        scores = ReadJson();
    }
    public  void SaveIntoJson()
    {
        scores.scores = Sort(scores.scores);
       
        string json = JsonUtility.ToJson(scores);

        File.WriteAllText(Application.dataPath + "/HighScore.json", json);
    }

    public static void AddScore(Score s)
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

    public void ShowHS()
    {
   
        for (int i = 0; i < scores.scores.Count; i++)
        {
            highScores[i].text = scores.scores[i].name + "--" + scores.scores[i].value;
        }
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
