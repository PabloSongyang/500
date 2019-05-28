using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getdeviceid : MonoBehaviour {
    [SerializeField]
    InputField deviceidtext;
	// Use this for initialization
	void Start () {
        //Static.Instance.AddData("biaoshi",DeviceID.Get());
        deviceidtext.text = DeviceID.Get();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
