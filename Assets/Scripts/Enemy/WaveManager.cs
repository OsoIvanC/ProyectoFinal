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
    int numberOfEnemies;
    [SerializeField]
    float statsMultiplier;




    [Header("Enemies")]
    public GameObject enemiePrefab;
    Queue<GameObject> enemiesQueue;
    

    private void Awake()
    {
        instance = this;

        //UpdateRoomLists();

        InitWaves();
        //actualWave = GetActualWave();
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
        enemiesQueue = new Queue<GameObject> ();

        GameObject temp;

        for (int i = 0; i < wave.numberOfEnemies; i++)
        {
            temp = Instantiate(enemiePrefab, transform.position, Quaternion.identity);
            temp.transform.SetParent(this.transform);
            temp.SetActive(false);
            enemiesQueue.Enqueue(temp);
        }
    }



}
