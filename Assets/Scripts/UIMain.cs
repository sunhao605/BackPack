using UnityEngine;

public class UIMain : MonoBehaviour
{
    public Canvas canvas;

    // 执行初始化
    private void Awake()
    {
        PropCfg.Instance.LoadCfg();
        BackPackMgr.Instance.Init();
        PanelMgr.Instance.Init(canvas);
    }


    void Start()
    {
        // 显示大厅界面
        PanelMgr.Instance.ShowPanel(PanelName.PlazaPanel);
    }
}