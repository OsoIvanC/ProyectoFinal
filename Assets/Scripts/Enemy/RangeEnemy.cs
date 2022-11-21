using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RangeEnemy : EnemyController,IController
{
    
    [SerializeField]
    LayerMask playerMask;

    [SerializeField]
    Transform player;

    [SerializeField]
    Transform tower;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float checkRange;

    [SerializeField]
    GunManager gunManager;

    [SerializeField]
    float fireRate;

    Collider col;
    bool allowFire;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        gunManager = GetComponent<GunManager>();

        allowFire = true;
      
        col = GetComponent<Collider>(); 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,checkRange);
    }
    void CheckAttackRange()
    {
        Collider[] attackColliders = Physics.OverlapSphere(transform.position, stats.attackRange, playerMask);
        Collider[] reachColliders = Physics.OverlapSphere(transform.position, checkRange, playerMask);

        if (reachColliders.Length <= 0)
        {
            animator.SetBool("isOn", false);
            player = null;
            col.enabled = false;
            return;
        }
        
        col.enabled = true;

        animator.SetBool("isOn", true);

        player = reachColliders[0].transform;

        Rotate();

        if (attackColliders.Length > 0)
        {
            if (allowFire)
                StartCoroutine(ShootCall());
        }

    }


    private void LateUpdate()
    {
        CheckAttackRange();
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float value)
    {
        stats.Health -= value;

        if (stats.Health <= 0)
            Death();
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }

    public void Rotate()
    {
        tower.LookAt(player);
    }

    public void Gravity()
    {
        throw new System.NotImplementedException();
    }

    public void Shoot()
    {
        GameObject bullet = gunManager.GetPooledBullet();

        if (bullet == null) return;

        //bullet.transform.SetParent(GunManager.instance.barrelPos);

        bullet.transform.position = gunManager.barrelPos.position;

        bullet.transform.forward = gunManager.barrelPos.forward;
        //bullet.transform.localRotation = Quaternion.Euler(90, 45, 0);

        bullet.SetActive(true);

    }


    IEnumerator ShootCall()
    {
        allowFire = false;

        Debug.Log("Shoot");

        //Shoot();

        yield return new WaitForSeconds(fireRate);

        allowFire = true;
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
