using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneName = "Scene/Map 1";  // Đảm bảo tên khớp với tên trong Build Settings

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    public void OnButtonClick()
    {
        Debug.Log("Button clicked, loading scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
