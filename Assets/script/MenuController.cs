using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void OnStartClicked()
    {
        // 例如加载游戏场景（假设你的游戏场景叫 "GameScene"）
        SceneManager.LoadScene("SampleScene");
    }

    public void OnSettingsClicked()
    {
        // 例如打开设置面板（这里先用 Debug 输出）
        Debug.Log("Settings clicked!");
        // 你也可以激活一个设置 UI 面板：settingsPanel.SetActive(true);
    }
}