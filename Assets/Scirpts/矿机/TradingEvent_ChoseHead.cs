using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradingEvent_ChoseHead : MonoBehaviour {
    [SerializeField]
    Image head;

    public void ChoseHead(string obj)
    {
        Debug.Log(obj);
        TradingPage.Instance.ChoseHead(obj,head);
    }
	
}
