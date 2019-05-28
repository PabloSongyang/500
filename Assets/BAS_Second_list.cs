using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class BAS_Second_list : MonoBehaviour {

    [SerializeField]
    Matching self;

    public JsonData json;

    public bool type = false;

    [SerializeField]
    Sprite zt1, zt2;
    public Image button_image;

    [SerializeField]
    GameObject[] fkzt;

    public void Set_img()
    {
        self.img.gameObject.SendMessage("LoadImage", self.img.text);
    }

    public void Update_data()
    {
        if(type)
            self.order_accept_id.text = Regex.Unescape(JsonMapper.ToJson(json["order_id"]).Replace("\"", ""))+"("+"匹配卖出订单"+Regex.Unescape(JsonMapper.ToJson(json["accept_id"]).Replace("\"", "")) + ")";
        else
            self.order_accept_id.text = Regex.Unescape(JsonMapper.ToJson(json["order_id"]).Replace("\"", "")) + "(" + "匹配买入订单" + Regex.Unescape(JsonMapper.ToJson(json["accept_id"]).Replace("\"", "")) + ")";

        self.id.text = Regex.Unescape(JsonMapper.ToJson(json["order_id"]).Replace("\"", ""));
        self.zhuangtai.text = Regex.Unescape(JsonMapper.ToJson(json["zhuangtai"]).Replace("\"", ""));
        if(type)
            self.direction.text = "您>"+Regex.Unescape(JsonMapper.ToJson(json["money"]).Replace("\"", ""))+">"+ Regex.Unescape(JsonMapper.ToJson(json["name"]).Replace("\"", ""));
        else
            self.direction.text = Regex.Unescape(JsonMapper.ToJson(json["name"]).Replace("\"", "") + ">" + Regex.Unescape(JsonMapper.ToJson(json["money"]).Replace("\"", "")) + ">" + "您");

        self.creat_time.text = "订单创建时间:"+Regex.Unescape(JsonMapper.ToJson(json["creat_time"]).Replace("\"", ""));
        self.dkr_name.text = Regex.Unescape(JsonMapper.ToJson(json["dkr_name"]).Replace("\"", ""));
        self.dkr_tj_name.text = Regex.Unescape(JsonMapper.ToJson(json["dkr_tj_name"]).Replace("\"", ""));
        self.bank.text = Regex.Unescape(JsonMapper.ToJson(json["bank"]).Replace("\"", ""));
        try
        {
            self.bank_zh.text = Regex.Unescape(JsonMapper.ToJson(json["bank_zh"]).Replace("\"", ""));
        }
        catch
        {
            self.bank_zh.text = "";
        }
        
        self.bank_card.text = Regex.Unescape(JsonMapper.ToJson(json["bank_card"]).Replace("\"", ""));
        self.username.text = Regex.Unescape(JsonMapper.ToJson(json["username"]).Replace("\"", ""));
        self.zfb.text = Regex.Unescape(JsonMapper.ToJson(json["zfb"]).Replace("\"", ""));
        self.dk_time.text = Regex.Unescape(JsonMapper.ToJson(json["dk_time"]).Replace("\"", ""));
        self.skr_name.text = Regex.Unescape(JsonMapper.ToJson(json["skr_name"]).Replace("\"", ""));
        self.skr_tj_name.text = Regex.Unescape(JsonMapper.ToJson(json["skr_tj_name"]).Replace("\"", ""));
        try
        {
            self.img.text = Regex.Unescape(JsonMapper.ToJson(json["img"]).Replace("\"", ""));
        }
        catch
        {
            self.img.text = null;
        }

        if (self.zhuangtai.text == "待确认")
        {
            button_image.sprite = zt1;
        }

        if (self.zhuangtai.text == "已完成")
        {
            foreach (GameObject i in fkzt)
            {
                i.SetActive(false);
            }
        }
        if (type)
            if (self.zhuangtai.text == "待确认")
            {
                foreach (GameObject i in fkzt)
                {
                    i.SetActive(false);
                }
            }

        if (self.zhuangtai.text == "已完成")
        {
            button_image.sprite = zt2;
        }

        //self.dk_time.text = Regex.Unescape(JsonMapper.ToJson(json["dk_time"]).Replace("\"", ""));

    }
}
