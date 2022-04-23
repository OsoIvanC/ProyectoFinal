using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OsoScripts.Objects
{
    public class Bullet : MonoBehaviour
    {
        Rigidbody _rigidbody;

        [SerializeField]
        float bulletSpeed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _rigidbody.velocity = transform.forward * bulletSpeed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyController>().stats.health -= 1;
            }
            //Destroy(gameObject);

        }

    }
}
