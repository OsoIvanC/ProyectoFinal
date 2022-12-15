using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField]
    GameObject lookAt;   
    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - lookAt.transform.position);
    }
}
