using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePage : MonoBehaviour {

    public static HomePage Instance;

    [SerializeField]
    HomePagePrompt Prompt;
    [SerializeField]
    HttpModel Make_Buy;
    // Use this for initialization
    void Start () {
        Instance = this;
	}

    public void GouMai(KJ_Attribute Kj)
    {
        Static.Instance.AddValue("KJ_id",Kj.id.text);
        Prompt.prompt.text = "是否花费"+Kj.price.text+"葡提币购买？";
        Prompt.MakeSure.onClick.RemoveAllListeners();
        Prompt.MakeSure.onClick.AddListener(delegate {
            Make_Buy.Get();
        });
        Prompt.transform.gameObject.SetActive(true);
    }
}
