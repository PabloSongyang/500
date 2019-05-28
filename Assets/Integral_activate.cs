using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Integral_activate : MonoBehaviour {

    [SerializeField]
    Transform have, no;

    [SerializeField]
    Transform father;

    public void reset()
    {
        if (father.childCount == 0)
        {
            Transform newobj = Instantiate(no.gameObject).transform;
            newobj.parent = father;
            newobj.gameObject.SetActive(true);
            newobj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
        else
        {
            Transform newobj = Instantiate(have.gameObject).transform;
            newobj.parent = father;
            newobj.gameObject.SetActive(true);
            newobj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }
}
