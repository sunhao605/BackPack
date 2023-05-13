using System.Collections.Generic;
using UnityEngine;
using LitJson;


public class PropCfg
{
    /// <summary>
    /// 读取配置表
    /// </summary>
    public void LoadCfg()
    {
        var cfgJson = Resources.Load<TextAsset>("PropCfg");
        var cfg = JsonMapper.ToObject<List<PropCfgItem>>(cfgJson.text);
        foreach(var cfgItem in cfg)
        {
            m_cfgDic[cfgItem.id] = cfgItem;
        }
    }

    /// <summary>
    /// 通过道具id获取道具配置
    /// </summary>
    /// <param name="id">道具id</param>
    /// <returns></returns>
    public PropCfgItem GetCfg(int id)
    {
        if (m_cfgDic.ContainsKey(id))
            return m_cfgDic[id];
        return null;
    }

    /// <summary>
    /// 配置表
    /// </summary>
    private Dictionary<int, PropCfgItem> m_cfgDic = new Dictionary<int, PropCfgItem>();

    /// <summary>
    /// 单例模式
    /// </summary>
    private static PropCfg s_instance;
    public static PropCfg Instance
    {
        get
        {
            if (null == s_instance)
                s_instance = new PropCfg();
            return s_instance;
        }
    }
}

/// <summary>
/// 道具配置数据结构
/// </summary>
public class PropCfgItem
{
    public int id;
    public string name;
    public string sprite;
    public string desc;
}