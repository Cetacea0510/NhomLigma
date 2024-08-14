using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject settingMenu;

    public void Start()
    {
        settingMenu.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RedoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        Debug.Log("Volume");
        audioMixer.SetFloat("VolumeMaster", Mathf.Log10(volume) * 20);
    }

}
