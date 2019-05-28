using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckTanHao : MonoBehaviour {

	Text myTEXT;
	public GameObject Loga;
	// Use this for initialization
	void Awake()
    {
        myTEXT = gameObject.GetComponent<Text>();
		myTEXT.text="0.0";

	}
	void Start () 
	{
	}
	// Update is called once per frame
	void Update () 
	{
		
		if (float.Parse (myTEXT.text)==0.0f)
			Loga.SetActive (false);
		else
			Loga.SetActive (true);
	}
}
