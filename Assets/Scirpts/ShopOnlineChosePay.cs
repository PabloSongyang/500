using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopOnlineChosePay : MonoBehaviour {

    [System.Serializable]
    public class type
    {
        public Toggle types;
        public string Value;
    }


    [SerializeField]
    type type1, type2;
    [SerializeField]
    string SaveValueName;
    private void OnEnable()
    {
        type1.types.isOn = true;
        type2.types.isOn = false;


        Static.Instance.AddValue(SaveValueName, type1.Value);

        type1.types.onValueChanged.RemoveAllListeners();
        type2.types.onValueChanged.RemoveAllListeners();

        type1.types.onValueChanged.AddListener(delegate (bool isOn) { ChosePay1(); });
        type2.types.onValueChanged.AddListener(delegate (bool isOn) { ChosePay2(); });
    }

    public void ChosePay1()
    {
        if (type1.types.isOn)
        {
            type2.types.isOn = false;
        }
            

        SetpayModel();


    }
    public void ChosePay2()
    {
        if (type2.types.isOn)
        {
            type1.types.isOn = false;
        }
            

        SetpayModel();
    }
   


    public void SetpayModel()
    {
        if (type1.types.isOn || type2.types.isOn )
        {
            if (type1.types.isOn)
                Static.Instance.AddValue(SaveValueName, type1.Value);

            if (type2.types.isOn)
                Static.Instance.AddValue(SaveValueName, type2.Value);

        }          
        else
            Static.Instance.AddValue(SaveValueName, "");

        Debug.Log(Static.Instance.GetValue(SaveValueName));
    }


}
