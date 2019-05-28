using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookingOrder : MonoBehaviour {

    [SerializeField]
    Dropdown value;
    private void OnEnable()
    {
        Static.Instance.AddValue("pdflag", (value.value + 4).ToString());
    }


    public void Getpdflag(Dropdown value)
    {
        Static.Instance.AddValue("pdflag",(value.value+4).ToString());
    }
}
