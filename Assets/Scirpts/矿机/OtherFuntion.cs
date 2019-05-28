using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherFuntion : MonoBehaviour {

    [SerializeField]
    Transform _sdflag;


    public void sdflag(string obj)
    {
        if (Static.Instance.GetValue(obj) == "0")
        {
            _sdflag.gameObject.SetActive(true);
        }
        if (Static.Instance.GetValue(obj) == "1")
        {
            _sdflag.gameObject.SetActive(false);
        }
    }
}
