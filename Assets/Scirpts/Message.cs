using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour 
{
    [SerializeField]
    Transform Juan1, Juan2;

    private void OnEnable()
    {
		Static.Instance.UpdateAllObj();
        
    }

	public void UpdateAllMesage()
	{
		Static.Instance.UpdateAllObj();
	}

    public void JuanSwitch()
    {
        if (Static.Instance.GetValue("rcflag") == "1")
        {
            Juan1.gameObject.SetActive(true);
            Juan2.gameObject.SetActive(true);
        }
        if (Static.Instance.GetValue("rcflag") == "0")
        {
            Juan1.gameObject.SetActive(false);
            Juan2.gameObject.SetActive(false);
        }
    }

}
