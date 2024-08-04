using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;  // Tên cảnh bạn muốn chuyển đến

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnTMPClick);
        }
    }

    public void OnTMPClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
