using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation_list : MonoBehaviour {

    [SerializeField]
    GameObject active0, active1;

    public void zhuangtai(string value)
    {
        active0.SetActive(false);
        active1.SetActive(false);
        switch (value)
        {
            case "未激活":
                active0.SetActive(true);
                break;
            default:
                active1.SetActive(true);
                break;

        }
    }
}
