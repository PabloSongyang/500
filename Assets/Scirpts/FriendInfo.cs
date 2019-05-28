using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendInfo : MonoBehaviour {

	[SerializeField]
	Text Totoal;
	[SerializeField]
	Text ZhiTuiTotoal;

    [SerializeField]
    Transform GouMaiYiJian, YiJian;
    public void SetZhTui()
	{
		ZhiTuiTotoal.text=Static.Instance.GetValue ("tj_num");
		Totoal.text = Static.Instance.GetValue ("td_num");
        SetStart();

    }

    public void SetStart()
    {
        switch (Static.Instance.GetValue("yjflag"))
        {
            case "0":
                GouMaiYiJian.gameObject.SetActive(true);
                YiJian.gameObject.SetActive(false);
                break;
            case "1":
                GouMaiYiJian.gameObject.SetActive(false);
                YiJian.gameObject.SetActive(true);
                break;
        }
        // Static.Instance.SaveFriend.Clear();
        //htp.Get();
        //htp2.Get();
        //ListFriendlist ();
    }
}
