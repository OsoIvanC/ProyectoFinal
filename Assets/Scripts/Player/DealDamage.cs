using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("ATTACKHIT");
            other.gameObject.GetComponent<IController>().TakeDamage(this.GetComponentInParent<Controller>().PlayerStats.AttackDamage);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
