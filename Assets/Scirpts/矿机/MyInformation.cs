using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyInformation : MonoBehaviour {
    [System.Serializable]
    public class form
    {
        public GameObject obj;
        public Button ClickEvent;
        public HttpModel http;

        public void SetActive(bool ison)
        {
            if(obj)
            obj.SetActive(ison);
        }
        public void GetHttp()
        {
            if(http)
            http.Get();
        }
    }
    [SerializeField]
    ChoseIamge head;
    [SerializeField]
    Image Headimage;
    [SerializeField]
    form[] forms;

    // Use this for initialization
    void Start () {
        foreach (form i in forms)
        {
            i.ClickEvent.onClick.AddListener(delegate {
                i.SetActive(true);
                i.GetHttp();
            });
        }
	}

    public void SetHead(object obj)
    {
        Headimage.sprite = head.SetFriendHead(int.Parse(obj.ToString()));
    }
}
