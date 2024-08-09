using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate_NextLV : MonoBehaviour
{
    public string sceneToLoad; // Tên của scene mà bạn muốn chuyển đến

     private void OnTriggerEnter2D(Collider2D other)
     {
         if(other.tag == "Player")
         {
             Debug.Log("next scene to" + sceneToLoad);
             SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
         }
     }
}
