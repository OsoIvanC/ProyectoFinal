using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("ATTACKHIT");
            other.gameObject.GetComponent<IController>().TakeDamage(this.GetComponentInParent<Controller>().PlayerStats.AttackDamage);
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("ATTACKHIT");
            other.gameObject.GetComponent<IController>().TakeDamage(this.GetComponentInParent<Enemy>().stats.attackDamage);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            this.GetComponent<Collider>().enabled = false;
        }

        if (other.CompareTag("Player"))
        {
            this.GetComponent<Collider>().enabled = false;
        }
    }
}
