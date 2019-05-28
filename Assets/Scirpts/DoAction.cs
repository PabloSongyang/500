using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DoAction : MonoBehaviour {

	public UnityEvent MyAction;
	public GameObject Wancheng;
	public GameObject ChuShou;
	public GameObject Ok;
	public GameObject QuXiao;
	public void DoActionGo(string Obj)
	{
		ChuShou.SetActive (false);
		Wancheng.SetActive (false);
		Ok.SetActive (false);
		QuXiao.SetActive (false);
		if (int.Parse (Obj) == 2)
            Ok.SetActive (true);
		if(int.Parse(Obj)==1)
			Wancheng.SetActive (true);
		if (int.Parse (Obj) == 0) 
		{
			//Ok.SetActive (true);
			QuXiao.SetActive (true);
		}
	}


    public GameObject YiQuXiao;
    public void DoActionZS(string Obj)
    {
        ChuShou.SetActive(false);
        Wancheng.SetActive(false);
        Ok.SetActive(false);
        QuXiao.SetActive(false);
        YiQuXiao.SetActive(false);
        if (int.Parse(Obj) == 0)
        {
            QuXiao.SetActive(true);
        }
        if (int.Parse(Obj) == 1)
            Wancheng.SetActive(true);
        if (int.Parse(Obj) == 2)
        {
            Ok.SetActive(true);
        }
        if (int.Parse(Obj) == 3)
        {
            YiQuXiao.SetActive(true);
        }
    }

    public void DoActionBZS(string Obj)
    {
        ChuShou.SetActive(false);
        Wancheng.SetActive(false);
        Ok.SetActive(false);
        QuXiao.SetActive(false);
        YiQuXiao.SetActive(false);
        if (int.Parse(Obj) == 0)
        {
            Ok.SetActive(true);
        }
        if (int.Parse(Obj) == 1)
            Wancheng.SetActive(true);
        if (int.Parse(Obj) == 2)
        {
            ChuShou.SetActive(true);
        }
        if (int.Parse(Obj) == 3)
        {
            YiQuXiao.SetActive(true);
        }
    }

    [SerializeField]
    GameObject WeiFH, QRSH;

    public void ShopJL(string Obj)
    {
        WeiFH.SetActive(false);
        QRSH.SetActive(false);

        if (int.Parse(Obj) == 0)
            WeiFH.SetActive(true);
        if (int.Parse(Obj) == 1)
            QRSH.SetActive(true);
    }
}
