using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPanel : MonoBehaviour {

    [SerializeField]
    Text Integer;


    public void GetInt(InputField num)
    {
        Integer.text = "X"+Mathf.Floor(float.Parse(num.text)/1000).ToString();
    }

}
