using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySwitch : MonoBehaviour
{
    public GameObject inventoryAppear;
    private bool inventoryActived = false; // Khởi tạo giá trị ban đầu

    void Start()
    {
        inventoryAppear.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            inventoryActived = !inventoryActived; // Đảo trạng thái bật/tắt
            inventoryAppear.SetActive(inventoryActived);
        }
    }
}
