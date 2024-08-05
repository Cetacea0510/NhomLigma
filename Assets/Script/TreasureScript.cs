using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    public GameObject treasure;
    public GameObject treasureOpenButton;
    void Start()
    {
        treasureOpenButton.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            treasureOpenButton.SetActive (true);
        }
    }
    public void WhenButtonClicked()
    {
        treasure.SetActive (false);
    }
}
