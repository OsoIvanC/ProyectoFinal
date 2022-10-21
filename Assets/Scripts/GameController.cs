using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public float timeToActivate;

    private void Awake()
    {
        instance = this;
    }

    public void ActivateEnemy(GameObject enemy)
    {
        StartCoroutine(Activate(enemy));
    }

    IEnumerator Activate(GameObject enemy)
    {
        Debug.Log($"Activating {enemy.name}");

        yield return new WaitForSeconds(timeToActivate);

        enemy.SetActive(true);
    }



}
