using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Trading_Attribute
{
    public Text id;
    public Text name;
    public Text num;
    public Text unit;
    public Text total;
    public Text volume;
    public Text price;
}
public enum type
{
    GuaMai,
    Sell
}
public class TradingPageList : MonoBehaviour {

    [SerializeField]
    Trading_Attribute trading;
    [SerializeField]
    Button Event;

    [SerializeField]
    type ChoseType;
    // Use this for initialization
    void Start () {
        Event.onClick.AddListener(delegate {
            if (ChoseType == type.GuaMai)
                TradingPage.Instance.GuaMai(trading);
            if (ChoseType == type.Sell)
                TradingPage.Instance.Sell(trading);
        });
	}
	
	
}
