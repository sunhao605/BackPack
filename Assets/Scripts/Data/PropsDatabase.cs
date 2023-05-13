using System.Collections.Generic;
using UnityEngine;
using LitJson;

/// <summary>
/// 道具数据库
/// </summary>
public class PropsDatabase 
{
    /// <summary>
    /// 从本地读取数据
    /// </summary>
    /// <returns></returns>
    public static Dictionary<int, int> LoadData()
    {
        PlayerPrefs.SetString("props", "{}");
        var jsonStr = PlayerPrefs.GetString("props", "{}");
        Debug.Log("LoadData: \n" + jsonStr);
        var result = JsonMapper.ToObject<Dictionary<string, int>>(jsonStr);
        Dictionary<int, int> data = new Dictionary<int, int>();
        foreach (var item in result)
        {
            data[int.Parse(item.Key)] = item.Value;
        }
        return data;
    }

    /// <summary>
    /// 写入数据到本地
    /// </summary>
    /// <param name="data"></param>
    public static void SaveData(Dictionary<int, int> data)
    {
        var jsonStr = JsonMapper.ToJson(data);
        PlayerPrefs.SetString("props", jsonStr);
    }
}
