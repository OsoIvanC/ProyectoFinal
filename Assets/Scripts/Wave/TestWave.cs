using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWave : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, Random.Range(1.5f,4));
    }

    private void OnDestroy()
    {
        WaveManager.Instance.activeCubes --;
    }
}
