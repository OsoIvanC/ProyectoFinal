using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public List<Transform> spwanPoints;

    public List<GameObject> doors;
    
    public bool isActive;
    public Transform GetRandomSpawn()
    {
        if (!isActive)
            return null;

        return spwanPoints[Random.Range(0,spwanPoints.Count)];
    }


    public void OpenDoors()
    {
        foreach(var door in doors)
            door.SetActive(false);
    }

    public void CloseDoor()
    {
        foreach (var door in doors)
            door.SetActive(true);
    }

}
