using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float bulletVelocity;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        //transform.DOMove(GunManager.instance.GetShootDir() * GunManager.instance.bulletVelocity,1).SetEase(Ease.Flash);

        rb.AddForce(-GunManager.instance.barrelPos.forward * bulletVelocity, ForceMode.Impulse);
        if (gameObject.activeInHierarchy)
            Invoke("DeActive", 2);
    }

    void DeActive()
    {
        gameObject.SetActive(false);
        gameObject.transform.parent = null;
        transform.position = GunManager.instance.barrelPos.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DeActive();
        Debug.Log(collision.gameObject.name);
        //gameObject.SetActive(false);
    }
}
