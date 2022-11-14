using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public static GunManager instance;

    public float bulletVelocity;

    public Queue<GameObject> pooledBullets = new Queue<GameObject>();

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

        for (int i = 0; i < magazine; ++i)
        {
            temp = Instantiate(bulletPrefab, barrelPos.position, Quaternion.identity);
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
    private void Update()
    {
        Debug.DrawLine(barrelPos.position, GetShootDir(), Color.blue);

        //Debug.DrawLine(barrelPos.position, barrelPos.position - barrelPos.forward, Color.blue);
    }
}
