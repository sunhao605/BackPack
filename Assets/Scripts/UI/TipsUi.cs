using UnityEngine;
using UnityEngine.UI;

public class TipsUi : MonoBehaviour
{
    public Text tipsText;

    /// <summary>
    /// 显示提示语
    /// </summary>
    /// <param name="text"></param>
    public static void Show(string text)
    {
        var obj = PanelMgr.Instance.ShowPanel(PanelName.TipsUi);
        var bhv = obj.GetComponent<TipsUi>();
        bhv.tipsText.text = text;
    }


    /// <summary>
    /// 动画结束，销毁自己
    /// </summary>
    public void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
}
