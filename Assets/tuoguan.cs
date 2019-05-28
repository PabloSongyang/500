using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tuoguan : MonoBehaviour {

    [SerializeField]
    Toggle Switch;

    [SerializeField]
    Sprite close, open;
    [SerializeField]
    Image switch_panel;

    [SerializeField]
    GameObject obj;


    [SerializeField]
    HttpModel http;

    bool Lock = false;

    public void OnStartReset()
    {
        string value;
        Lock = true;
        value = Static.Instance.GetValue("tgflag");

        if (value == "0")
            close_funtion();
        else
            open_funtion();
    }

    public void click()
    {
        if (Lock)
            return;
        if (Switch.isOn)
        {
            open_funtion();
            Static.Instance.AddValue("tgflag","1");
            http.Get();
        }
        else
        {
            close_funtion();
            Static.Instance.AddValue("tgflag", "0");
            http.Get();
        }


    }

    public void open_funtion()
    {
        switch_panel.sprite = open;
        obj.SetActive(true);
        Switch.isOn = true;
        Lock = false;
    }

    public void close_funtion()
    {
        switch_panel.sprite = close;
        obj.SetActive(false);
        Switch.isOn = false;
        Lock = false;
    }
}
