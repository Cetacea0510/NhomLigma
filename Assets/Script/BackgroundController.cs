using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{
    public bool isSwitched = false;
    public Image[] backgrounds; // Thay đổi từ các biến riêng lẻ thành một mảng
    public Animator animator;

    private int currentIndex = 0; // Chỉ số hình nền hiện tại

    void Start()
    {
        // Kiểm tra xem có đủ hình nền không
        if (backgrounds.Length != 5)
        {
            Debug.LogError("Phải có 5 hình nền được gán.");
        }
    }

    public void SwitchImage(Sprite sprite)
    {
        // Đặt hình nền mới vào hình nền hiện tại
        backgrounds[currentIndex].sprite = sprite;

        // Chọn hoạt ảnh tương ứng với hình nền hiện tại
        animator.SetTrigger("Switch" + (currentIndex + 1));

        // Cập nhật chỉ số hình nền
        currentIndex = (currentIndex + 1) % backgrounds.Length;
        if (animator != null)
        {
            animator.SetTrigger("Switch");
        }
        else
        {
            Debug.LogError("Animator is not assigned!");
        }
    }

    public void SetImage(Sprite sprite)
    {
        // Đặt hình nền mới vào hình nền hiện tại
        backgrounds[currentIndex].sprite = sprite;
    }
}
