using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public static GunManager instance;

    public float bulletVelocity;

    public List<GameObject> pooledBullets = new List<GameObject>();

    public Transform barrelPos;

    public GameObject bulletPrefab;

    public int magazine;

    public Vector3 shootDir;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        pooledBullets = new List<GameObject>();

        GameObject temp;

        for (int i = 0; i < magazine; ++i)
        {
            temp = Instantiate(bulletPrefab, barrelPos.position, Quaternion.identity);
            temp.SetActive(false);
            pooledBullets.Add(temp);
        }
    }

    public GameObject GetPooledBullet()
    {
        for(int i = 0; i < magazine; ++i)
        {
            if (!pooledBullets[i].activeInHierarchy)
                return pooledBullets[i];
        }

        return null;
    }


    public Vector3 GetShootDir()
    {
        return barrelPos.position - barrelPos.forward;
    }
    private void Update()
    {
        Debug.DrawLine(barrelPos.position,  barrelPos.position - barrelPos.forward , Color.blue);

        //Debug.DrawLine(barrelPos.position, barrelPos.position - barrelPos.forward, Color.blue);
    }
}
