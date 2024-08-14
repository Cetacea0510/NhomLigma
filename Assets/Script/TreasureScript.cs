using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    public int Health = 999999;
    public GameObject treasure;
    public GameObject treasureOpenButton;
    public AudioClip treasureOpen;

    void Start()
    {
        treasureOpenButton.SetActive(false); // Tắt nút lúc khởi động
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Khi người chơi va chạm với kho báu
        if (collision.gameObject.tag == "Player")
        {
            treasureOpenButton.SetActive(true); // Bật nút mở kho báu
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        // Khi người chơi rời khỏi vùng va chạm
        if (collision.gameObject.tag == "Player")
        {
            treasureOpenButton.SetActive(false); // Tắt nút mở kho báu
        }
    }

    public void WhenButtonClicked()
    {
        AudioManager.instance.PlaySound(treasureOpen);
        treasure.SetActive(false); // Tắt kho báu khi nút được nhấn
        treasureOpenButton.SetActive(false); // Tắt luôn nút sau khi mở kho báu
    }
}
