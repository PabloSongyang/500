using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TheStatisticalFigure : MonoBehaviour {

    [SerializeField]
    Image Niu,Xiong;
    bool Niubool, Xiongbool;
    [SerializeField]
    Text Type;
    private void Awake()
    {
        ResetXiaZhu();
    }
    private void Start()
    {

    }
   
    private void Update()
    {
    }


    public void SetNiuBool()
    {
        Niubool = true;
        Xiongbool = false;
        Niu.color = new Color(1,1,1,1);
        Xiong.color = new Color(1, 1, 1, 0.3f);
        SetType();
    }
    public void SetXiongBool()
    {
        Xiongbool = true;
        Niubool = false;
        Xiong.color = new Color(1, 1, 1, 1);
        Niu.color = new Color(1, 1, 1, 0.3f);
        SetType();
    }
    void SetType()
    {
        if (Niubool || Xiongbool)
        {
            if (Niubool)
                Type.text = "1";
            else
                Type.text = "0";
        }
    }

    public void ResetXiaZhu()
    {
        Xiong.color = new Color(1, 1, 1, 0.3f);
        Niu.color = new Color(1, 1, 1, 1);
        Type.text = "1";
    }


}



