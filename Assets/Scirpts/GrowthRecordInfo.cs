using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowthRecordInfo : MonoBehaviour {
    [SerializeField]
    GameObject Plan_1, Plan_2, Plan_3, Plan_4;
    void OnEnable()
    {

    }

    public void PlanChange(int i)
    {
        switch (i)
        {
            case 1:
                Plan_1.SetActive(true);
                Plan_2.SetActive(false);
                Plan_3.SetActive(false);
                Plan_4.SetActive(false);
                break;
            case 2:
                Plan_1.SetActive(false);
                Plan_2.SetActive(true);
                Plan_3.SetActive(false);
                Plan_4.SetActive(false);
                break;
            case 3:
                Plan_1.SetActive(false);
                Plan_2.SetActive(false);
                Plan_3.SetActive(true);
                Plan_4.SetActive(false);
                break;
            case 4:
                Plan_1.SetActive(false);
                Plan_2.SetActive(false);
                Plan_3.SetActive(false);
                Plan_4.SetActive(true);
                break;

        }
    }

}
