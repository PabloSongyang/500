using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class GMType
{
    public Button type;
    public Sprite icon;
    public Sprite clickicon;
    bool isclick;
    public bool isClick
    {
        get { return isclick; }
        set { isclick = value; }
    }
    [HideInInspector]
    public UnityEvent typeClick;
    public UnityEvent otherEvent;
    public Button_Event[] EventList;
}

[System.Serializable]
public class Button_Event
{
    public UnityEvent Event;
    public Button EventButton;

    public void AddEvent()
    {
        EventButton.onClick.AddListener(delegate
        {
            Event.Invoke();
        });
    }
    public void RemoveEvnet()
    {
        EventButton.onClick.RemoveAllListeners();
    }
}

public class PopupWindowEvent : MonoBehaviour
{

    [SerializeField]
    GMType[] typelist;

    bool isEnable = false;

    [SerializeField]
    Transform AllWindow;
    List<Transform> allwindow = new List<Transform>();
    private void Start()
    {
        OnStart();
    }

    private void OnEnable()
    {
        if (!isEnable)
            return;
        ResetStart();
        Refresh();
    }

    void Refresh()
    {
        foreach (GMType i in typelist)
        {
            if (i.isClick)
            {
                if (i.type && i.clickicon)
                    i.type.image.sprite = i.clickicon;
                foreach (Button_Event j in i.EventList)
                    j.AddEvent();
                i.otherEvent.Invoke();
            }
            else
                if (i.type && i.icon)
                i.type.image.sprite = i.icon;
        }
    }

    

    private void ResetAll()
    {
        foreach (GMType i in typelist)
        {
            i.isClick = false;
            foreach (Button_Event j in i.EventList)
                j.RemoveEvnet();
        }
        foreach (Transform i in allwindow)
        {
            if (i != allwindow[0])
                i.gameObject.SetActive(false);
        }
    }

    private void ResetStart()
    {
        foreach (GMType i in typelist)
        {
            i.isClick = false;
            foreach (Button_Event j in i.EventList)
                j.RemoveEvnet();
        }
        foreach (Transform i in allwindow)
        {
            if(i != allwindow[0])
            i.gameObject.SetActive(false);
        }



        typelist[0].isClick = true;
    }
    private void OnStart()
    {
        foreach (GMType i in typelist)
        {
            i.typeClick.AddListener(delegate {
                OntypeClick(i);
            });
            i.type.onClick.AddListener(delegate {
                i.typeClick.Invoke();
            });
        }
        if(AllWindow)
        foreach (Transform i in AllWindow)
        {
            allwindow.Add(i);
        }

        ResetStart();
        Refresh();
        isEnable = true;
    }
    void OntypeClick(GMType obj)
    {
        StopAllCoroutines();
        ResetAll();
        obj.isClick = true;
        Refresh();
    }

    //[SerializeField]
    //Transform MoneyInput;
    //public void isMoney(bool tof)
    //{
    //    MoneyInput.gameObject.SetActive(tof);
    //}

    public void SetClickColor(Text value)
    {
        Transform FatherRect = value.transform.parent.parent;
        foreach (Transform i in FatherRect)
        {
            if (i.GetComponent<Button>())
                i.GetComponentInChildren<Text>().color = HexToColor("333333FF");
        }
        value.color = HexToColor("0081FFFF");
    }

    public Color HexToColor(string hex)
    {
        byte br = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte bg = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte bb = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        byte cc = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        float r = br / 255f;
        float g = bg / 255f;
        float b = bb / 255f;
        float a = cc / 255f;
        return new Color(r, g, b, a);
    }

    public void select_type(int i)
    {
        typelist[i - 1].type.onClick.Invoke();
    }
    
}



