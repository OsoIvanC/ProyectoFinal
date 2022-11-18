using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    List<Transform> spwanPoints = new List<Transform>();

    GameObject door;
    
    public bool isActive;
    public Transform GetRandomSpawn()
    {
        if (!isActive)
            return null;

        return spwanPoints[Random.Range(0,spwanPoints.Count)];
    }

    public void OpenDoor()
    {
        door.SetActive(false);
    }
    public void CloseDoor()
    {
        door.SetActive(true);
    }

}
