using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradingPage : MonoBehaviour {
    public static TradingPage Instance;

    [SerializeField]
    HttpModel GuaMais,Sells;

    [SerializeField]
    ChoseIamge choseHead;
	// Use this for initialization
	void Start () {
        Instance = this;
	}

    public void GuaMai(Trading_Attribute trading)
    {
        Static.Instance.AddValue("trading_id", trading.id.text);
        GuaMais.Get();
    }
    public void Sell(Trading_Attribute trading)
    {
        Static.Instance.AddValue("trading_id", trading.id.text);
        Sells.Get();
    }

    public void ChoseHead(string head_id,Image head)
    {
        head.sprite = choseHead.SetFriendHead(int.Parse(head_id));
    }

}
