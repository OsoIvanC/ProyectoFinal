using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public static WaveManager instance;

    [Header("ROOMS")]
    [SerializeField]
    List<Room> rooms;
    [SerializeField]
    List<Room> activeRooms;
    [SerializeField]
    List<Room> notActiveRooms;

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
    [SerializeField]
    int numberOfEnemies, maxNumberOfEnemiesInScreen;
    [SerializeField]
    float statsMultiplier;




    [Header("Enemies")]
    public GameObject enemiePrefab;
    Queue<GameObject> enemiesQueue;

    Queue<GameObject> enemiesQueue1;
    Queue<GameObject> enemiesQueue2;
    int spawnedEnemiesCount;


    private void Awake()
    {
        instance = this;
        spawnedEnemiesCount = 0;
        //UpdateRoomLists();

        InitWaves();
        //actualWave = GetActualWave();
    }


    void PoolEnemieCreator()
    {
        enemiesQueue1 = new Queue<GameObject>();
        enemiesQueue2 = new Queue<GameObject>();

        GameObject temp;

        for (int i = 0; i < maxNumberOfEnemiesInScreen; i++)
        {
            temp = Instantiate(enemiePrefab, new Vector3(1000,1000,1000), Quaternion.identity);
            temp.transform.SetParent(this.transform);
            temp.SetActive(false);
            enemiesQueue1.Enqueue(temp);

        }
    }

    GameObject GenerateEnemy(Vector3 pos,Quaternion rot,Transform parent)
    {
        GameObject retValue = enemiesQueue1.Dequeue();

        retValue.transform.SetParent(parent);

        retValue.transform.localPosition = pos;

        retValue.transform.localRotation = rot;

        retValue.SetActive(true);

        enemiesQueue1.Enqueue(retValue);

        return retValue;
    }


    void DeleteEnemy(GameObject enemy)
    {
        enemy.transform.SetParent(null);
        enemy.SetActive(false);
        spawnedEnemiesCount--;
    }

    public void UpdateRoomLists()
    {
        foreach (Room room in rooms)
        {
            if(room.isActive)
                activeRooms.Add(room);
            else
                notActiveRooms.Add(room);
        }
    }

    public void InitWaves()
    {
        waves = new Queue<Wave>();

        Wave temp;

        for (int i = 0; i < numberOfWaves; i++)
        {
            if (i > 0)
                ModifyWaveValues();

            temp = new Wave(timeToSpawn , numberOfEnemies , statsMultiplier);

            waves.Enqueue(temp);
            wavesList.Add(temp);
        }

        PoolEnemieCreator();

        StartWave(GetActualWave());
    }

    public void ModifyWaveValues()
    {
        timeToSpawn *=waveModifier;
        numberOfEnemies = (int)(numberOfEnemies * waveModifier);
        statsMultiplier *= waveModifier;
    }
    public Wave GetActualWave()
    {
        return waves.Dequeue();
    }
  
    public void StartWave(Wave wave)
    {
        spawnedEnemiesCount = 0;
        StartCoroutine(WaveController(wave));
        //enemiesQueue = new Queue<GameObject> ();

        //GameObject temp;

        //for (int i = 0; i < wave.numberOfEnemies; i++)
        //{
        //    temp = GenerateEnemy(transform.position, Quaternion.identity, this.transform);
        //    temp.SetActive(false);
        //    enemiesQueue.Enqueue(temp);
        //}
    }

    IEnumerator WaveController(Wave wave)
    {
        var eof = new WaitForEndOfFrame();
        int totalEnemiesSpawned = 0;
        while (totalEnemiesSpawned < wave.numberOfEnemies)
        {
            if(spawnedEnemiesCount >= maxNumberOfEnemiesInScreen)
            {
                yield return eof;
                continue;
            }
            GenerateEnemy(Vector3.zero, Quaternion.identity, transform);
            spawnedEnemiesCount++;
            totalEnemiesSpawned++;
            yield return new WaitForSeconds(wave.timeToSpawn);
        }
    }
}
