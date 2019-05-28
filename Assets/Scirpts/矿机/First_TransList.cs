using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class First_TransList : MonoBehaviour {

    public void pp_type(string obj)
    {
        switch (obj)
        {
            case "0":
                this.GetComponent<Text>().text = "等待排单";
                break;
            case "1":
                this.GetComponent<Text>().text = "等待匹配";
                break;
            case "2":
                this.GetComponent<Text>().text = "部分匹配";
                break;
            case "3":
                this.GetComponent<Text>().text = "完全匹配";
                break;
            case "4":
                this.GetComponent<Text>().text = "已完成";
                break;
        }
    }
    public void wc_type(string obj)
    {
        switch (obj)
        {
            case "0":
                this.GetComponent<Text>().text = "未打款";
                break;
            case "1":
                this.GetComponent<Text>().text = "已付款";
                break;
            case "2":
                this.GetComponent<Text>().text = "待确认";
                break;
            case "3":
                this.GetComponent<Text>().text = "已完成";
                break;
            case "4":
                this.GetComponent<Text>().text = "撤销排单";
                break;
            case "5":
                this.GetComponent<Text>().text = "打款超时";
                break;
            case "6":
                this.GetComponent<Text>().text = "确认超时";
                break;
        }
    }
    [SerializeField]
    Transform zhuangtai0, zhuangtai12;
    public void zhuangtai(string obj)
    {
        if (obj == "未激活")
        {
            zhuangtai0.gameObject.SetActive(true);
            zhuangtai12.gameObject.SetActive(false);
        }
        else
        {
            zhuangtai0.gameObject.SetActive(false);
            zhuangtai12.gameObject.SetActive(true);
            zhuangtai12.GetComponent<Text>().text = obj;
        }
    }

    [SerializeField]
    Image buttonImage;
    public void CanOpenList(string obj)
    {
        if (obj != "0")
            return;

        this.transform.parent.GetComponent<Button>().interactable = false;
        buttonImage.gameObject.SetActive(false);

    }
}
