using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void Restart(GameObject panelToDeactivate)
    {
        Debug.Log("Restart");

        Time.timeScale = 1;

        panelToDeactivate.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }
}
