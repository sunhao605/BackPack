using UnityEngine;
using UnityEditor;
using System.IO;

public class MakeSpritePrefabs
{
    [MenuItem("Tools/MakeSpritePrefabs")]
    private static void Make()
    {
        // 创建 Assets/Resources/Sprite 文件夹，用来存放生成的精灵预设
        var prefabRootDir = Path.Combine(Application.dataPath, "Resources/Sprite");
        if (!Directory.Exists(prefabRootDir))
        {
            Directory.CreateDirectory(prefabRootDir);
        }

        // 遍历 Assets/Atlas 文件夹中的 png 图片
        var pngRootDir = Path.Combine(Application.dataPath, "Atlas");
        var pngFils = Directory.GetFiles(pngRootDir, "*.png", SearchOption.AllDirectories);
        foreach (string filePath in pngFils)
        {
            string assetPath = filePath.Substring(filePath.IndexOf("Assets"));
            Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
            GameObject go = new GameObject(sprite.name);
            go.AddComponent<SpriteRenderer>().sprite = sprite;

            var prefabPath = Path.Combine(prefabRootDir, sprite.name + ".prefab");
            prefabPath = prefabPath.Substring(prefabPath.IndexOf("Assets"));
            // 将 gameObject 保存为预设
            PrefabUtility.SaveAsPrefabAsset(go, prefabPath);
            GameObject.DestroyImmediate(go);
        }

        // 刷新目录
        AssetDatabase.Refresh();
    }
}
