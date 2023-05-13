using System.Collections.Generic;

/// <summary>
/// 背包管理器
/// </summary>
public class BackPackMgr
{
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        // 从本地读取背包数据
        m_propsDic = PropsDatabase.LoadData();
    }

    /// <summary>
    /// 修改道具数量
    /// </summary>
    /// <param name="id">道具id</param>
    /// <param name="deltaCnt">数量变化值</param>
    public void ChangePropCnt(int id, int deltaCnt)
    {
        if (m_propsDic.ContainsKey(id))
        {
            m_propsDic[id] += deltaCnt;
        }
        else
        {
            m_propsDic[id] = deltaCnt;
        }
        if (m_propsDic[id] < 0)
        {
            m_propsDic[id] = 0;
        }
        // 写入数据到本地
        PropsDatabase.SaveData(m_propsDic);
        // 抛出事件
        EventDispatcher.Instance.DispatchEvent(EventNameDef.EVENT_UPDATE_PROP_CNT, id, m_propsDic[id]);
    }

    /// <summary>
    /// 背包道具数据缓存，key: id, value: cnt
    /// </summary>
    private Dictionary<int, int> m_propsDic = new Dictionary<int, int>();
    public Dictionary<int, int> propsDic
    {
        get { return m_propsDic; }
    }

    /// <summary>
    /// 单例模式
    /// </summary>
    private static BackPackMgr s_instance;
    public static BackPackMgr Instance
    {
        get
        {
            if (null == s_instance)
                s_instance = new BackPackMgr();
            return s_instance;
        }
    }
}