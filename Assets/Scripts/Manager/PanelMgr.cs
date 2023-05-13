using UnityEngine;

public class PanelMgr 
{
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="canvas"></param>
    public void Init(Canvas canvas)
    {
        m_canvasTrans = canvas.transform;
    }

    /// <summary>
    /// 显示界面
    /// </summary>
    /// <param name="panelName"></param>
    /// <returns></returns>
    public GameObject ShowPanel(string panelName)
    {
        var prefab = ResourceMgr.Instance.LoadPanel(panelName);
        var obj = Object.Instantiate(prefab);
        obj.transform.SetParent(m_canvasTrans, false);
        return obj;
    }


    /// <summary>
    /// 缓存Canvas
    /// </summary>
    private Transform m_canvasTrans;

    private static PanelMgr s_instance;
    public static PanelMgr Instance
    {
        get
        {
            if (null == s_instance)
                s_instance = new PanelMgr();
            return s_instance;
        }
    }
}

/// <summary>
/// 界面名称
/// </summary>
public class PanelName
{
    public const string BackpackPanel = "BackpackPanel";
    public const string PlazaPanel = "PlazaPanel";
    public const string TipsUi = "TipsUi";

}