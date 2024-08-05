using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySwitch : MonoBehaviour
{
    public GameObject inventoryAppear;
    private bool inventoryActived;
    void Start()
    {
        inventoryAppear.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && inventoryActived)
        {
            inventoryAppear.SetActive(false);
            inventoryActived = false;
        }
        else if (Input.GetKeyDown(KeyCode.G) && !inventoryActived)
        {
            inventoryAppear.SetActive(true);
            inventoryActived = true;
        }
    }
}
