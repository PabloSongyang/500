using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class BAS_manager : MonoBehaviour {

    [SerializeField]
    BAS_list precast;
    [SerializeField]
    Transform father;


    public void setBAS_list(BAS_list list)
    {
        precast = list;
    }


    public void Getjson(JsonData json)
    {
        Debug.Log(JsonMapper.ToJson(json));
        List<JsonData> listjson = new List<JsonData>();

        JsonData data = json["data"];

        for (int i = 0; i < data.Count; i++)
        {
            listjson.Add(data[i]);
        }
        Cleangglist();
        foreach (JsonData i in listjson)
        {
            GameObject newobj = Instantiate(precast.gameObject);
            newobj.transform.parent = father;
            newobj.transform.localScale = new Vector3(1, 1, 1);
            newobj.GetComponent<BAS_list>().json = i;
            newobj.GetComponent<BAS_list>().Update_data();
            newobj.SetActive(true);
        }
    }
    public void Cleangglist()
    {
        for (int i = 0; i < father.childCount; i++)
        {
            Destroy(father.GetChild(i).gameObject);
        }
       
    }

}
