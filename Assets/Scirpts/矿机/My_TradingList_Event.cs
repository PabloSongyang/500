using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class My_TradingList_Event : MonoBehaviour {
    [SerializeField]
    Text person_sell,person_buy;
    [SerializeField]
    GameObject event_sell, event_buy;

    public void trading_trading(string obj)
    {
        person_buy.gameObject.SetActive(false);
        person_sell.gameObject.SetActive(false);
        event_buy.gameObject.SetActive(false);
        event_sell.gameObject.SetActive(false);

        if (obj == "卖家")
        {
            person_sell.gameObject.SetActive(true);
            event_sell.gameObject.SetActive(true);
        }
        if (obj == "买家")
        {
            person_buy.gameObject.SetActive(true);
            event_buy.gameObject.SetActive(true);
        }

    }

    [SerializeField]
    GameObject Sell_ZT0, Sell_ZT1,Buy_ZT0,Buy_ZT1;

    public void zhuangtai(string obj)
    {
        Sell_ZT0.SetActive(false);
        Sell_ZT1.SetActive(false);
        Buy_ZT0.SetActive(false);
        Buy_ZT1.SetActive(false);

        if (obj == "0")
        {
            Sell_ZT0.SetActive(true);
            Buy_ZT0.SetActive(true);
        }
        if (obj == "1")
        {
            Sell_ZT1.SetActive(true);
            Buy_ZT1.SetActive(true);
        }
    }

    [SerializeField]
    GameObject ZT0, ZT1, ZT2;

    public void MMZhuangtai(string obj)
    {
        ZT0.SetActive(false);
        ZT1.SetActive(false);
        ZT2.SetActive(false);
        if (obj == "0")
        { ZT0.SetActive(true); }
        if (obj == "1")
        { ZT1.SetActive(true); }
        if (obj == "2")
        { ZT2.SetActive(true); }
    }
	

}
