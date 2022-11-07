using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    
    private void OnEnable()
    {
        transform.DOMove(GunManager.instance.GetShootDir() * GunManager.instance.bulletVelocity,1).SetEase(Ease.Flash);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
