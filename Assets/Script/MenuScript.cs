using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject settingObject;

    public void Start()
    {
        settingObject.SetActive(false);
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("VolumeMaster", Mathf.Log10(volume) * 20);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Hieu2");
    }
    public void OnQuit()
    {
        Application.Quit();
    }
    
}
