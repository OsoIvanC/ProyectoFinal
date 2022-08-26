using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour,IController
{
    [SerializeField] Stats myStats;
    public Stats EnemyStats { get { return myStats; } }

    Renderer myRenderer;

    [SerializeField]
    Color actualColor;

    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
        actualColor = myRenderer.material.color;
        myStats.Init();
    }
    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void Gravity()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    public void Rotate()
    {
        throw new System.NotImplementedException();
    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float value)
    {
        StartCoroutine(ColorChange());
    }


    IEnumerator ColorChange()
    {
        myRenderer.material.color =  Color.red;
        yield return new WaitForSeconds(0.1f);
        myRenderer.material.color = actualColor;
    }
    

    
}
