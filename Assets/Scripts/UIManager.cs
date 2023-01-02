using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{

    public TMP_InputField menuField;
    public static UIManager Instance { get; private set; }
    public static string playerName;

    public AudioSource source;

    private void Awake()
    {
        Instance = this;

        if (menuField != null)
            menuField.onEndEdit.AddListener(SetName);    
    }

    void SetName(string name)
    {
        playerName = name;  
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

    public void ActivateObj(GameObject gO)
    {
        gO.SetActive(true);
    }

    public void DeactivateObj(GameObject gO)
    {
        gO.SetActive(false);
    }
    public void PlayAudio(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
