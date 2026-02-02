using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Debugging : MonoBehaviour
{

    private string logPath;
    
    void Start()
    {
        // 获取日志文件路径（在EXE同级目录）
        logPath = Application.dataPath + "/../debug_log.txt";
        
        // 清空并开始记录
        File.WriteAllText(logPath, "=== 游戏启动 ===\n");
        File.AppendAllText(logPath, $"时间: {System.DateTime.Now}\n");
        
        // 查找主角
        GameObject player = GameObject.Find("Player"); // 改成你的主角名称
        bool foundPlayer = player != null;
        
        File.AppendAllText(logPath, $"找到主角: {foundPlayer}\n");
        
        if (foundPlayer)
        {
            File.AppendAllText(logPath, $"主角激活状态: {player.activeSelf}\n");
            File.AppendAllText(logPath, $"在层级中激活: {player.activeInHierarchy}\n");
            
            SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
            File.AppendAllText(logPath, $"有SpriteRenderer: {sr != null}\n");
            if (sr != null)
            {
                File.AppendAllText(logPath, $"Sprite名称: {sr.sprite?.name ?? "null"}\n");
                File.AppendAllText(logPath, $"Renderer启用: {sr.enabled}\n");
                File.AppendAllText(logPath, $"材质: {sr.material?.name ?? "null"}\n");
            }
            
            // 检查父对象
            Transform parent = player.transform.parent;
            File.AppendAllText(logPath, $"有父对象: {parent != null}\n");
            if (parent != null)
                File.AppendAllText(logPath, $"父对象名称: {parent.name}, 激活: {parent.gameObject.activeSelf}\n");
        }
        
        File.AppendAllText(logPath, "=== 日志结束 ===\n");
        
        Debug.Log($"日志已保存到: {logPath}");
    }
}
