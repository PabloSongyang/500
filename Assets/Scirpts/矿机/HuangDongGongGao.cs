using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HuangDongGongGao : MonoBehaviour {
    [SerializeField]
    Text count;
    [SerializeField]
    Image Father;
    List<string> countlist = new List<string>();

    [SerializeField]
    UnityEvent Http;

    string Message;
    string MessageSave;
    public string Message_
    {
        get
        {
            return Message;
        }
        set
        {
            MessageSave = Message;
            if (Message != value)
            {          
                Message = value;
                countlist.Add(Message);
                Reset();
            }
            else
                Message = MessageSave;
        }
    }
	// Use this for initialization
	void Start () {

        //InvokeRepeating("GetMessage", 0, 5);

        string value = "\"欢迎来到阿·里矿主\"";
        countlist.Add(value);


    }
    // Update is called once per frame
    void Update() {
        if (count.text != "")
            countMove();
        //else
        //    Father.color = new Color(0.7f,0.7f,0.7f,0);

    }
    private void Reset()
    {
        //countlist.RemoveAt(0);
        count.rectTransform.localPosition = new Vector3(Father.rectTransform.sizeDelta.x/2,0);
    }

    void countMove()
    {
        if (count.rectTransform.localPosition.x < -(Father.rectTransform.sizeDelta.x / 2 + count.rectTransform.sizeDelta.x))
        { 
            //count.text = countlist[0];
            Reset();
            //count.text = null;
        }
        else
        {
            //Father.color = new Color(0.7f, 0.7f, 0.7f, 1);
            count.rectTransform.Translate(-3, 0, 0);
        }
    }

    void GetMessage()
    {
        Http.Invoke();
        if(count.text!= null)
        Message_ = count.text;
    }
}
