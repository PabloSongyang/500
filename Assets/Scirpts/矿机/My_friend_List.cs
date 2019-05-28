using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class My_friend_List : MonoBehaviour {

    [SerializeField]
    Transform Count;
    [SerializeField]
    Transform InsObj;

    [SerializeField]
    Button Clickbutton;

    [SerializeField]
    Sprite open, close;
    [SerializeField]
    Image state;

    public bool _onclick
    {
        get { return OnClick; }
        set { OnClick = value;
            if (_onclick)
                state.sprite = open;
            else
                state.sprite = close;
        }
    }

    bool OnClick = false;


    private void Start()
    {
        _onclick = false;
        Clickbutton.onClick.AddListener(delegate { ClickFuntion(); });
    }


    [SerializeField]
    int cj = 0;
    [SerializeField]
    public RectTransform suojin;
    IEnumerator ListCountDelate(ContentSizeFitter obj)
    {
        yield return new WaitForSeconds(0.1f);
        obj.enabled = false;
        yield return new WaitForSeconds(0.1f);
        obj.enabled = true;
        this.GetComponent<HttpModel>().delate();

        this.GetComponent<HttpModel>().Suc.RemoveListener(delate);
    }

    void ClickFuntion()
    {
        if (cj == 3)
        {
            ShowOrHit._Instance.Worning.gameObject.SetActive(true);
            ShowOrHit._Instance.msg.text = "只能展开4级，若要继续向下查看，请在搜索栏中搜索该会员";
            return;
        }
        _onclick = !_onclick;

        

        if (!_onclick)
        {
            for (int i = 0;i< this.transform.parent.childCount;i++)
            {
                if (this.transform.parent.GetChild(i).name == this.transform.GetChild(0).GetComponent<Text>().text + "-" + "Child")
                {
                    Destroy(this.transform.parent.GetChild(i).gameObject);
                    delate();
                    return;
                }
            }
            
            return;
        }


        Click();
    }



    public void Click()
    {
        HttpModel http = this.GetComponent<HttpModel>();
        http.Data.MyListMessage.FatherObj = Instantiate();
        
        http.Data.MyListMessage.InsObj = ColorSet(InsObj.gameObject, http.Data.MyListMessage.FatherObj.gameObject);
        http.Suc.AddListener(delate);
        http.Get();
    }

    public void delate()
    {
        StartCoroutine(ListCountDelate(this.transform.parent.GetComponent<ContentSizeFitter>()));
    }

    public Transform Instantiate()
    {
        GameObject fatherobj = (GameObject)Instantiate(Count.gameObject);

        fatherobj.transform.parent = this.transform.parent;

        for (int i = 0; i < this.transform.parent.childCount; i++)
        {
            if (this.transform.parent.GetChild(i) == this.transform)
            {             
                fatherobj.transform.SetSiblingIndex(i);
                fatherobj.transform.name = this.transform.GetChild(0).GetComponent<Text>().text + "-" + "Child";
                fatherobj.SetActive(true);
            }
        }
        fatherobj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        return fatherobj.transform;
    }



    public GameObject ColorSet(GameObject obj,GameObject father)
    {
        string str = father.name;
        string[] strArray = str.Split('-');
        Debug.Log(strArray.Length);
        int ColorNum = strArray.Length;
        Color oldColor = obj.GetComponent<Image>().color;
        if (Static.Instance.td_list)
            Destroy(Static.Instance.td_list.gameObject);
        GameObject newobj = (GameObject)Instantiate(obj);
        Static.Instance.td_list = newobj;
        //newobj.GetComponent<Image>().color = new Color(oldColor.r - 0.1f*(ColorNum-1), oldColor.g - 0.1f * (ColorNum - 1), oldColor.b - 0.1f * (ColorNum - 1),oldColor.a);
        newobj.GetComponent<My_friend_List>().cj = this.cj + 1;
        newobj.GetComponent<My_friend_List>().suojin.sizeDelta = new Vector2(cj * 65,85);
        newobj.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        return newobj;
    }

}
