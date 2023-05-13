using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 资源管理器
/// </summary>
public class ResourceMgr
{
    /// <summary>
    /// 加载精灵图
    /// </summary>
    /// <param name="name">精灵名</param>
    /// <returns></returns>
    public Sprite LoadSprite(string name)
    {
        if (m_spritesDic.ContainsKey(name))
            return m_spritesDic[name];
        var obj = Resources.Load<GameObject>("Sprite/" + name);

        var sprite = obj.GetComponent<SpriteRenderer>().sprite;
        m_spritesDic[name] = sprite;
        return sprite;
    }

    /// <summary>
    /// 加载界面预设
    /// </summary>
    /// <param name="name">界面名</param>
    /// <returns></returns>
    public GameObject LoadPanel(string name)
    {
        GameObject prefab = null;
        if (m_panelsDic.ContainsKey(name))
            prefab = m_panelsDic[name];
        else
        {
            prefab = Resources.Load<GameObject>("Panel/" + name);
            m_panelsDic[name] = prefab;
        }
        return prefab;
    }

    /// <summary>
    /// 精灵资源
    /// </summary>
    private Dictionary<string, Sprite> m_spritesDic = new Dictionary<string, Sprite>();
    /// <summary>
    /// 界面资源
    /// </summary>
    private Dictionary<string, GameObject> m_panelsDic = new Dictionary<string, GameObject>();

    /// <summary>
    /// 单例模式
    /// </summary>
    private static ResourceMgr s_instance;
    public static ResourceMgr Instance
    {
        get
        {
            if (null == s_instance)
                s_instance = new ResourceMgr();
            return s_instance;
        }
    }
}
