using UnityEngine;
using UnityEditor;
using System.IO;

public class PostTexture : AssetPostprocessor
{
    /// <summary>
    /// 监听图片导入，自动修改图片格式，并设置Packing Tag为所在文件夹名字
    /// </summary>
    /// <param name="texture"></param>
    void OnPostprocessTexture(Texture2D texture)
    {
        var dirName = Path.GetDirectoryName(assetPath);
        // 文件夹名字作为图集名字
        string atlasName = new DirectoryInfo(dirName).Name;
        TextureImporter textureImporter = assetImporter as TextureImporter;
        // 设置为Sprite（2D and UI）
        textureImporter.textureType = TextureImporterType.Sprite;
        // 设置设置Packing Tag为图集名字
        textureImporter.spritePackingTag = atlasName;
        // 不使用mipmap，否则图片可能会变模糊
        textureImporter.mipmapEnabled = false;
    }
}