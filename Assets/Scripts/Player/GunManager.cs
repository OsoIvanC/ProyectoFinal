using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
   

    public float bulletVelocity;

    public Queue<GameObject> pooledBullets;

    public Transform barrelPos;

    public GameObject bulletPrefab;

    public int magazine;

    public Vector3 shootDir;

    public float damage;

  
    private void Start()
    {
        pooledBullets = new Queue<GameObject>();

        GameObject temp;
        //GameObject bullets = new GameObject("Bullets");

        //bullets.transform.position = Vector3.zero;

        for (int i = 0; i < magazine; ++i)
        {
            temp = Instantiate(bulletPrefab, barrelPos.position, Quaternion.identity);
            temp.transform.SetParent(this.transform);
            temp.GetComponent<Bullet>().manager = this;
            temp.SetActive(false);
            temp.layer = temp.transform.parent.gameObject.layer;
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
