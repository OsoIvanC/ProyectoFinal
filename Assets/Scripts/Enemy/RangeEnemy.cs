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

    AudioSource source;
    private void Awake()
    {
        animator = GetComponent<Animator>();

        gunManager = GetComponent<GunManager>();

        source = GetComponent<AudioSource>();

        stats.health = stats.maxHealth;

        healthBar.maxValue = stats.maxHealth;
        
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
            //source.PlayOneShot(deactivateClip);
            return;
        }
        
        col.enabled = true;

        //source.PlayOneShot(activateClip);
        animator.SetBool("isOn", true);


        if (reachColliders[0].CompareTag("Player"))
            player = reachColliders[0].transform;
        else
            player = null;

        Rotate();

        if (attackColliders.Length > 0 && player != null)
        {
            if (allowFire)
                StartCoroutine(ShootCall());
        }

    }

    public void PlayClip(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    private void LateUpdate()
    {

        if (!Controller.isAlive) return;

        if (Controller.pause) return;

        HealthBar();

        CheckAttackRange();
    }

    public void Attack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float value)
    {
        stats.health -= value;

        if (stats.health <= 0)
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

        if (!Controller.isAlive) return;

        if (Controller.pause) return;

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

        Shoot();

        yield return new WaitForSeconds(fireRate);

        allowFire = true;
    }

    public void Death()
    {
        Controller.score += 10;
        WaveManager.instance.DeleteEnemy(this.gameObject, EnemyType.RANGE);
        WaveManager.instance.turretSpawns.Remove(spawn);
    }
}
