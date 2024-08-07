using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate_NextLV : MonoBehaviour
{

    public string targetScene;  // Tên của màn chơi mới
    public string targetPortalTag;  // Tag của cổng trong màn mới mà nhân vật sẽ xuất hiện gần

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Lưu tên của cổng đích để sử dụng trong màn mới
            PlayerPrefs.SetString("targetPortalTag", targetPortalTag);

            // Chuyển sang màn mới
            SceneManager.LoadScene(targetScene);
        }
    }
}