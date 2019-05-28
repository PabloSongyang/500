using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class My_DuiHuan : MonoBehaviour {

    [SerializeField]
    Dropdown list;

    // Use this for initialization
    void Start() {
        ValueChanges();
    }

    public void ValueChanges()
    {
            Static.Instance.AddValue("money_type", list.options[list.value].text);
        
    }
	
}
