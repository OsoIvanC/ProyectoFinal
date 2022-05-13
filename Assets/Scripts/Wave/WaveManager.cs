using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WaveState
{
    PREP,
    START,
    SPAWN,
    END
}
public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance;

    [SerializeField]
    GameObject test;

    [SerializeField]
    int numberOfCubes;

    public int activeCubes;

    WaveState state;

    [SerializeField]
    List<Transform> spawnPoints;

    int waveNumber = 0; 

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        
    }

    private void Start()
    {
        Prep();
    }

    void Prep()
    {
        StartCoroutine("PrepTime");
    }

    IEnumerator PrepTime()
    {
        waveNumber++;
        numberOfCubes = waveNumber * 2;    
        yield return new WaitForSeconds(3);

        StartGame();
    }
    void StartGame()
    {
        StartCoroutine("InitGame");
    }

    IEnumerator InitGame()
    {
        Debug.Log("INIT WAVE# " + waveNumber);
        yield return new WaitForSeconds(1);
        activeCubes = numberOfCubes;
        Spawn();
    }
    void Spawn()
    {
        StartCoroutine("Game");
    }
    IEnumerator Game()
    {
        int i = 0;
        while (activeCubes > 0)
        {
            //Debug.Log("IN GAME");
            while(i < numberOfCubes)
            {
                Debug.Log("Spawn");
                Instantiate(test, spawnPoints[Random.Range(0, spawnPoints.Count)]);
                i++;
                yield return new WaitForSeconds(2.5f);
            }
            yield return null;
        }
        End();
    }

    void End()
    {
        StartCoroutine("EndWave");
    }

    IEnumerator EndWave()
    {
        Debug.Log("END WAVE# " + waveNumber);
        yield return new WaitForSeconds(1);
        Prep();
    }
}
