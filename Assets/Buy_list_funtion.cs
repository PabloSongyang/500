using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy_list_funtion : MonoBehaviour {

    bool swich1 = false;
    bool swich2 = false;

    [SerializeField]
    Transform swich1_obj;
    [SerializeField]
    Transform swich2_obj;

    [SerializeField]
    public Transform father;

    [SerializeField]
    Transform count;

    public void swich1_event()
    {
        swich1 = !swich1;
        swich1_obj.gameObject.SetActive(swich1);
        if (swich1 && swich1_obj.childCount > 0)
            count.gameObject.SetActive(true);
        else
        {
            count.gameObject.SetActive(false);
            if (swich1)
            {
                
                ShowOrHit._Instance.Worning.gameObject.SetActive(true);
                ShowOrHit._Instance.msg.text = "等待匹配中";
            }
           
        }
        StartCoroutine(delate());
        
    }
    public void swich2_event()
    {
        swich2 = !swich2;
        swich2_obj.gameObject.SetActive(swich2);
        if (swich2)
            this.gameObject.GetComponent<BAS_Second_list>().Set_img();
        StartCoroutine(delate());
    }

    IEnumerator delate()
    {
        father.GetComponent<ContentSizeFitter>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        father.GetComponent<ContentSizeFitter>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        father.GetComponent<ContentSizeFitter>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        father.GetComponent<ContentSizeFitter>().enabled = true;
    }
}
