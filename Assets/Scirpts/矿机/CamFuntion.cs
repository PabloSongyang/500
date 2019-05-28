using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CamFuntion : MonoBehaviour {

    [SerializeField]
    Image Maximage;


    public void fangda(Image min)
    {
        Maximage.sprite = min.sprite;
    }

    [SerializeField]
    Button clickfuntion;

    [SerializeField]
    UnityEvent suc, fal;
    public void buttonsuc()
    {
        clickfuntion.onClick.AddListener(delegate { suc.Invoke(); });
    }
    public void buttonfal()
    {
        clickfuntion.onClick.AddListener(delegate { fal.Invoke(); });
    }
}
