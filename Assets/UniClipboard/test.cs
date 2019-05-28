using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class test : MonoBehaviour {

    [SerializeField]
    Text abc;
    //[SerializeField]
    //Button Copy,Paste;
    //[SerializeField]
    //InputField ert;

    UnityEvent suc;
	// Use this for initialization
	void Start () {
        //Copy.onClick.AddListener(delegate {

        //    CopyToBoard();
        //});
        //Paste.onClick.AddListener(delegate {

        //    BoardToOut();
        //});
        ShowError = ShowOrHit._Instance.Worning.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    GameObject ShowError;


    public void CopyToBoard()
    {
        UniClipboard.SetText(abc.text);
        
        ShowError.SetActive(true);
        ShowError.GetComponentInChildren<Text>().text = "复制成功";
    }

    public string BoardToOut()
    {
        return UniClipboard.GetText();
    }
}
