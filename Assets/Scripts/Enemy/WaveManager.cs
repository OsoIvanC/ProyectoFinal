using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;


public enum EnemyType
{
    MELEE,
    RANGE
}
public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public const int TimeBetweenWaves = 3;
    
    [Header("ROOMS")]
    [SerializeField]
    List<Room> rooms;
    int roomNumber;
    int waveNumber;

    [Header("WAVES")]
    [SerializeField]
    int numberOfWaves;
    [SerializeField]
    List<Wave> wavesList;
    [SerializeField]
    float waveModifier;
    Queue<Wave> waves;
    //[SerializeField]
    //Wave actualWave;
    
    [Header("InitValues")]
    [SerializeField]
    float timeToSpawn;
    
    int numberOfEnemies;
    
    [SerializeField]
    int  maxMelee , maxRange;
    [SerializeField]
    float statsMultiplier;
    [SerializeField]
    int maxNumberOfEnemiesInScreen;

    [Header("Enemies")]
    public GameObject meleePrefab;
    public GameObject rangePrefab;
    
    Queue<GameObject> enemiesQueue1;
    Queue<GameObject> enemiesQueue2;
    int spawnedEnemiesCount;
    int spawnedMeleeCount;
    int spawnedRangeCount;

    public int enemiesKilled;
    public int totalEnemiesSpawned ;

    [SerializeField]
    List<Transform> spawnPoints;

    public GameObject lastEnemieInWave;

    [Header("UI")]
    [SerializeField]
    TMP_Text wavesText;
    [SerializeField]
    TMP_Text countDown;
    [SerializeField]
    GameObject newWavePanel;


    public List<Transform> turretSpawns;


    private void Awake()
    {
        instance = this;

        newWavePanel.SetActive(false);

        spawnedEnemiesCount = 0;
        spawnedMeleeCount = 0;
        spawnedRangeCount = 0;
        
        totalEnemiesSpawned = 0;
        enemiesKilled = 0;

        roomNumber = 0;

        numberOfEnemies = maxMelee + maxRange;

        UpdateSpawns();
        InitWaves();


        //actualWave = GetActualWave();
    }

    Transform RandomSpwan()
    {
        Transform t = spawnPoints[Random.Range(0, spawnPoints.Count)];

        //spawnPoints.Remove(t);

        return t;
    }

    void UpdateSpawns()
    {
        if (roomNumber < rooms.Count)
            foreach (Transform t in rooms[roomNumber].spwanPoints)
                spawnPoints.Add(t);
    }

    void OpenDoors()
    {
        if (roomNumber < rooms.Count)
            rooms[roomNumber].OpenDoors();    
    }

    void PoolEnemieCreator()
    {
        enemiesQueue1 = new Queue<GameObject>();
        enemiesQueue2 = new Queue<GameObject>();

        GameObject temp;
        GameObject temp2;

        for (int i = 0; i < maxMelee; i++)
        {
            temp = Instantiate(meleePrefab, new Vector3(1000,1000,1000), Quaternion.identity);
            temp.transform.SetParent(this.transform);
            temp.SetActive(false);
            enemiesQueue1.Enqueue(temp);
        }

        for (int i = 0; i < maxRange; i++)
        {
            temp2 = Instantiate(rangePrefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
            temp2.transform.SetParent(this.transform);
            temp2.SetActive(false);
            enemiesQueue2.Enqueue(temp2);
        }
    }

    GameObject GenerateMeleeEnemy(Vector3 pos,Quaternion rot,Transform parent)
    {
        GameObject retValue = enemiesQueue1.Dequeue();

        retValue.transform.SetParent(parent);

        retValue.transform.localPosition = pos;

        retValue.transform.localRotation = rot;

        retValue.SetActive(true);

        enemiesQueue1.Enqueue(retValue);

        return retValue;
    }

    GameObject GenerateRangeEnemy(Vector3 pos, Quaternion rot, Transform parent)
    {
        GameObject retValue = enemiesQueue2.Dequeue();

        retValue.transform.SetParent(parent);

        retValue.transform.localPosition = pos;

        retValue.transform.localRotation = rot;

        retValue.SetActive(true);

        enemiesQueue2.Enqueue(retValue);

        return retValue;
    }

    public void DeleteEnemy(GameObject enemy,EnemyType type)
    {
        enemy.transform.SetParent(null);
        enemy.SetActive(false);


        switch (type)
        {
            case EnemyType.MELEE:
                spawnedMeleeCount--;
                break;
            case EnemyType.RANGE:
                spawnedRangeCount--;
                break;
            default:
                break;
        }

        enemiesKilled ++;

        CheckWave();
    }

    void CheckWave()
    {
        if (enemiesKilled >= totalEnemiesSpawned)
        {
            StartCoroutine(NextWave()); 
        }
    }

    void NewWave()
    {
        OpenDoors();

        waveNumber++;
        roomNumber++;

        Debug.Log("Wave: " + waveNumber);
        Debug.Log("Room: " + roomNumber);
        
        UpdateSpawns();

        StartWave(GetActualWave());

        //Debug.Log("NEW WAVE");
    }

    private void LateUpdate()
    {
        wavesText.text = $"{waveNumber + 1}/{numberOfWaves}";
    }

    public void InitWaves()
    {
        waves = new Queue<Wave>();

        Wave temp;

        //maxNumberOfEnemiesInScreen = maxMelee + maxRange;

        for (int i = 0; i < numberOfWaves; i++)
        {
            if (i > 0)
                ModifyWaveValues();

            temp = new Wave(timeToSpawn , maxMelee, maxRange , statsMultiplier);

            waves.Enqueue(temp);
            wavesList.Add(temp);
        }

        PoolEnemieCreator();

        StartWave(GetActualWave());
    }

    public void ModifyWaveValues()
    {
        timeToSpawn *=waveModifier;

        maxMelee = (int) Mathf.Ceil(maxMelee * waveModifier);
        maxRange = (int)Mathf.Ceil(maxRange * waveModifier);
        
        statsMultiplier *= waveModifier;
    }
    public Wave GetActualWave()
    {
        return waves.Dequeue();
    }
  
    public void StartWave(Wave wave)
    {
        spawnedEnemiesCount = 0;
        spawnedMeleeCount = 0;
        spawnedRangeCount = 0;

        totalEnemiesSpawned = 0;
        enemiesKilled = 0;

        StartCoroutine(WaveController(wave));
    }

    IEnumerator WaveController(Wave wave)
    {
        var eof = new WaitForEndOfFrame();
        
        int r ;

        while (totalEnemiesSpawned < wave.numberOfEnemies)
        {
            r = Random.Range(0, 2);

            if (spawnedEnemiesCount >= maxNumberOfEnemiesInScreen)
            {
                yield return eof;
                continue;
            }

            if (r == 0)
            {
                if (spawnedMeleeCount > maxMelee)
                {
                    yield return eof;
                    continue;
                }

                Transform t = RandomSpwan();

                GenerateMeleeEnemy(CheckSpawns(t).position, Quaternion.identity, null);

                spawnedMeleeCount++;
            }
            else
            {
                if (spawnedRangeCount > maxRange)
                {
                    yield return eof;
                    continue;
                }

                Transform t = RandomSpwan();

                GameObject turret =  GenerateRangeEnemy(CheckSpawns(t).position, Quaternion.identity, null);

                turret.GetComponent<EnemyController>().spawn = t;
                
                turretSpawns.Add(t);

                spawnedRangeCount++;
            }

            spawnedEnemiesCount++;
            totalEnemiesSpawned++;
            
            yield return new WaitForSeconds(wave.timeToSpawn);
        }
    }


    IEnumerator NextWave()
    {
        int t = TimeBetweenWaves;

        newWavePanel.SetActive(true);
        
        while (t > 0)
        {
            t--;
            countDown.text = $" Starts in {t.ToString()}";
            yield return new WaitForSeconds(1);
        }

        newWavePanel.SetActive(false);

        NewWave();
    }
    Transform CheckSpawns(Transform sp)
    {
        if (turretSpawns.Contains(sp))
            return CheckSpawns(RandomSpwan());
        else
            return sp;
    }
}
