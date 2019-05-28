using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddressInfo : MonoBehaviour {

	[SerializeField]
	Text eorro;

	[SerializeField]
	InputField newaddress;

	void OnEnable()
	{
		newaddress.text = null;
		eorro.text = null;
	}
}
