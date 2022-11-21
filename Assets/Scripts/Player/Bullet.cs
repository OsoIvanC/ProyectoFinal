using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float bulletVelocity;
    public GunManager manager;


    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        //transform.DOMove(GunManager.instance.GetShootDir() * GunManager.instance.bulletVelocity,1).SetEase(Ease.Flash);

        if (manager == null)
            return;

        gameObject.transform.parent = null;
        rb.AddForce(transform.forward * bulletVelocity, ForceMode.Impulse);
        
        if (gameObject.activeInHierarchy)
            Invoke("DeActive", 2);
    }

    void DeActive()
    {
        gameObject.SetActive(false);
        //gameObject.transform.parent = null;
        transform.position = manager.barrelPos.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        DeActive();
        Debug.Log(collision.gameObject.name);

        IController controller;

        controller = collision.gameObject.GetComponent<IController>();

        if (controller != null)
            controller.TakeDamage(manager.damage);

        //gameObject.SetActive(false);
    }
}
