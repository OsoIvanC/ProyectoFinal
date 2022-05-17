using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform followTarget;

    [SerializeField]
    Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        var followVector = new Vector3(followTarget.position.x, transform.position.y, followTarget.position.z);

        transform.position = followVector + offset;
    }
}
