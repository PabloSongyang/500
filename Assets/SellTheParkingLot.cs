using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellTheParkingLot : MonoBehaviour {

    public void SetBank(Text text)
    {
        text.text = Static.Instance.GetValue("bank") + "(" + Static.Instance.GetValue("bank_card") +")";
    }

    [SerializeField]
    Dropdown value;

    [SerializeField]
    Text waning;
    private void OnEnable()
    {
        Static.Instance.AddValue("txflag", (value.value).ToString());
        if (value.value == 0)
        {
            waning.text = "";
        }
        if (value.value == 1)
        {
            waning.text = "奖励提现总额的50%不得小于上一次提现总额的50%";
        }
    }


    public void Gettxflag(Dropdown value)
    {
        Static.Instance.AddValue("txflag", (value.value).ToString());
        if (value.value == 0)
        {
            waning.text = "";
        }
        if (value.value == 1)
        {
            waning.text = "奖励提现总额的50%不得小于上一次提现总额的50%";
        }
    }
}
