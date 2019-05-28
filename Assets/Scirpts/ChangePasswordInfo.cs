using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePasswordInfo : MonoBehaviour {

	[SerializeField]
	HttpModel htp;

	[SerializeField]
	InputField newpassword_,newpassword,password;

	[SerializeField]
	Text eorro;
    [SerializeField]
    Transform Tishi;

	void OnEnable()
	{
		newpassword.text = null;
		newpassword_.text = null;
		password.text = null;
	}

	public void ButtonClick()
	{
		if (newpassword.text != newpassword_.text) 
		{
			eorro.text = "输入的两次新密码不一致";
            Tishi.gameObject.SetActive(true);

        }
		else
			htp.Get();
	}
}
