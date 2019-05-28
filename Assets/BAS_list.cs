using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
using System.Text.RegularExpressions;

[System.Serializable]
public class Information
{
    public Text offer_id;
    public Text creat_time;
    public Text zhuangtai;
    public Text pp_money;
    public Text txflag;
    public Text money;
    public Text name;

    public JsonData order;
}
[System.Serializable]
public class Matching
{
    public Text order_accept_id;
    public Text id;
    public Text zhuangtai;
    public Text direction;
    public Text creat_time;
    public Text dkr_name;
    public Text dkr_tj_name;
    public Text bank;
    public Text bank_zh;
    public Text bank_card;
    public Text username;
    public Text zfb;
    public Text skr_name;
    public Text skr_tj_name;
    public Text dk_time;
    public Text img;
}



public class BAS_list : MonoBehaviour {

    public JsonData json;
   

    [SerializeField]
    Information self;

    [SerializeField]
    BAS_Second_list precast;

    [SerializeField]
    Transform father;


    [SerializeField]
    Sprite FXJL;
    [SerializeField]
    Image image;

    [SerializeField]
    Image button_image;
    [SerializeField]
    Sprite zt1;

    bool type = false;
    public void Update_data()
    {
        try
        {
            self.offer_id.text = Regex.Unescape(JsonMapper.ToJson(json["offer_id"]).Replace("\"", ""));
            type = true;
        }
        catch
        {
            self.offer_id.text = Regex.Unescape(JsonMapper.ToJson(json["accept_id"]).Replace("\"", ""));
            type = false;

        }
        self.creat_time.text = Regex.Unescape(JsonMapper.ToJson(json["creat_time"]).Replace("\"", ""));
        self.zhuangtai.text = Regex.Unescape(JsonMapper.ToJson(json["zhuangtai"]).Replace("\"", ""));
        self.pp_money.text = Regex.Unescape(JsonMapper.ToJson(json["pp_money"]).Replace("\"", ""));
        if (Regex.Unescape(JsonMapper.ToJson(json["txflag"]).Replace("\"", ""))=="1")
        {
            image.sprite = FXJL;
        }
        self.money.text = Regex.Unescape(JsonMapper.ToJson(json["money"]).Replace("\"", ""));
        self.name.text = Regex.Unescape(JsonMapper.ToJson(json["name"]).Replace("\"", ""));
        self.order = json["order"];

        if (self.zhuangtai.text == "已完成")
        {
            button_image.sprite = zt1;
        }


        List<JsonData> listjson = new List<JsonData>();
        JsonData data = self.order;

        for (int i = 0; i < data.Count; i++)
        {
            listjson.Add(data[i]);
        }
        foreach (JsonData i in listjson)
        {
            GameObject newobj = Instantiate(precast.gameObject);
            newobj.transform.parent = father;
            //newobj.gameObject.GetComponent<Buy_list_funtion>().father = this.transform;
            newobj.transform.localScale = new Vector3(1, 1, 1);
            newobj.GetComponent<BAS_Second_list>().json = i;
            newobj.GetComponent<BAS_Second_list>().type = type;
            newobj.GetComponent<BAS_Second_list>().Update_data();
            newobj.SetActive(true);
        }

    }

}
