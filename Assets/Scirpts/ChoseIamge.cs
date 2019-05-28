using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChoseIamge : MonoBehaviour {

	public Image tEX01;
	public Image tEX02;
	public GameObject choseHead;

	public void SetNub(int Nub)
	{
		Static.Instance.AddValue ("img",Nub.ToString());
		tEX01.sprite = transform.GetChild (Nub-1).GetComponent<Image> ().sprite;
		tEX02.sprite = tEX01.sprite;
		choseHead.SetActive (false);
	}

	public void Get()
	{
		int Nubget = 0;
		if(Static.Instance.GetValue ("img")!=string.Empty)
			Nubget= int.Parse (Static.Instance.GetValue ("img"));
		Debug.Log (Nubget);
		if (Nubget != 0) 
		{
			if (transform.GetChild (Nubget - 1) != null) {
				tEX01.sprite = transform.GetChild (Nubget - 1).GetComponent<Image> ().sprite;
				tEX02.sprite = tEX01.sprite;
			} else
				Debug.LogError ("没有找到头像");
		}
		if (BusinessInfoHelper.Instance !=  null) 
		{
			BusinessInfoHelper.Instance.isDone = true;
		}
	}


    public Sprite SetFriendHead(int headNum)
    {
        Sprite head = null;
        if (headNum != 0)
        {
            if (transform.GetChild(headNum - 1) != null)
            {
                head = transform.GetChild(headNum - 1).GetComponent<Image>().sprite;
            }
            else
                Debug.LogError("没有找到头像");
        }
        else
            Debug.LogError("头像编号错误");

        return head;
    }

}
