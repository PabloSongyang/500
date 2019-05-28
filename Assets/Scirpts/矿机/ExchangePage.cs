using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExchangePage : MonoBehaviour {

    [SerializeField]
    InputField ptc_pt, ptc_ptc;

    public void pt_ptc_funtion(string value)
    {
        float proportion = float.Parse(Static.Instance.GetValue("pt_ptc_bl"))*0.01f;
        ptc_pt.text = (float.Parse(value) / proportion).ToString("F2");
    }

    public void pt_ptc_reversefuntion(string value)
    {
        float proportion = float.Parse(Static.Instance.GetValue("pt_ptc_bl"))*0.01f;
        ptc_ptc.text = (float.Parse(value) * proportion).ToString("F2");
    }
    [SerializeField]
    InputField pt_pt, pt_ptc;

    public void ptc_pt_funtion(string value)
    {
        float proportion = float.Parse(Static.Instance.GetValue("ptc_pt_bl"))*0.01f;
        pt_ptc.text = (float.Parse(value) / proportion).ToString("F2");
    }

    public void ptc_pt_reversefuntion(string value)
    {
        float proportion = float.Parse(Static.Instance.GetValue("ptc_pt_bl"))*0.01f;
        pt_pt.text = (float.Parse(value) * proportion).ToString("F2");
    }
}
