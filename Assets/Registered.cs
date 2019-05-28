using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registered : MonoBehaviour {
    [SerializeField]
    Toggle Switch;

    [SerializeField]
    HttpModel http;

    private void OnEnable()
    {
        Switch.isOn = false;
    }

    public void click()
    {
        if (Switch.isOn)
            http.Get();
        else
        {
            ShowOrHit._Instance.Worning.gameObject.SetActive(true);
            ShowOrHit._Instance.msg.text = "同意风险警告后操作";
        }
    }
}
