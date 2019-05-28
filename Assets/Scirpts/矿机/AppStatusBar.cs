using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AppStatusBar : MonoBehaviour
{
    [Tooltip("状态栏是否显示状态及通知")]
    public bool statusBar;
    [Tooltip("状态栏样式")]
    public AndroidStatusBar.States states = AndroidStatusBar.States.Visible;
    // Use this for initialization
    void Awake()
    {
#if UNITY_ANDROID
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidStatusBar.dimmed = !statusBar;
            //当AndroidStatusBar.dimmed=false时，状态栏显示所有状态及通知图标
            //当AndroidStatusBar.dimmed=true时，状态栏仅电量和时间，不显示其他状态及通知

            ////显示状态栏，占用屏幕最上方的一部分像素
            //AndroidStatusBar.statusBarState = AndroidStatusBar.States.Visible;

            ////悬浮显示状态栏，不占用屏幕像素
            //AndroidStatusBar.statusBarState = AndroidStatusBar.States.VisibleOverContent;

            ////透明悬浮显示状态栏，不占用屏幕像素
            AndroidStatusBar.statusBarState = AndroidStatusBar.States.TranslucentOverContent;

            ////隐藏状态栏
            //AndroidStatusBar.statusBarState = AndroidStatusBar.States.Hidden;

            //AndroidStatusBar.statusBarState = states;
        }
#endif
    }

    private void Start()
    {
        ShowBar();
    }

    public void HideBar()
    {
#if UNITY_ANDROID
        AndroidStatusBar.statusBarState = AndroidStatusBar.States.Hidden;
#elif UNITY_IPHONE
        //PlayerSettings.statusBarHidden = true;
#endif
    }

    public void ShowBar()
    {
#if UNITY_ANDROID
        AndroidStatusBar.statusBarState = AndroidStatusBar.States.TranslucentOverContent;
#elif UNITY_IPHONE
        //PlayerSettings.statusBarHidden = false;
#endif
    }
}