using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public static GunManager instance;

    public float bulletVelocity;

    public Queue<GameObject> pooledBullets;

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
        pooledBullets = new Queue<GameObject>();

        GameObject temp;
        GameObject bullets = new GameObject("Bullets");

        bullets.transform.position = Vector3.zero;

        for (int i = 0; i < magazine; ++i)
        {
            temp = Instantiate(bulletPrefab, barrelPos.position, Quaternion.identity);
            temp.transform.SetParent(bullets.transform);
            temp.SetActive(false);
            pooledBullets.Enqueue(temp);
        }
    }

    public GameObject GetPooledBullet()
    {
        GameObject obj = pooledBullets.Dequeue();
        pooledBullets.Enqueue(obj);
        return obj;
    }


    public Vector3 GetShootDir()
    {
        return barrelPos.position - barrelPos.forward;
    }
    
}
