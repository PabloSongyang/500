using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LitJson;
using UnityEngine.Events;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HttpModel : MonoBehaviour {

	public TypeGo DataType;
	public NewMessageInfo Data;

	public UnityEvent Suc, Fal;

	public bool IsLock=false;
	//public InputField inputField;
	private GameObject ShowLoad;
	private GameObject ShowError;

    public bool CleanInput = true;

    public UnityEvent DoAction;
	public bool NoShow=false;

    int timeOut = 5;

	void Start()
	{
        ShowLoad = ShowOrHit._Instance.HttpLoading.gameObject; 
        ShowError = ShowOrHit._Instance.Worning.gameObject;
		IsLock = Static.Instance.Lock;
	}

	public void Get()
	{
		Data.BackData.Clear ();
		//加密
		//EncryptDecipherTool.GetList(Data.SendData,Islock);
		message=null;
		message += "?"; 
		if(IsLock)
			message +=EncryptDecipherTool.UserMd5 ();
        if (ShowLoad != null)
            ShowLoad.SetActive(true);
        //if (ShowError != null)
        //    ShowError.SetActive(false);
		switch(DataType)
		{
		case TypeGo.GetTypeA:
			StopAllCoroutines();
			StartCoroutine ("GetMessageA");
		break;
		case TypeGo.GetTypeB:
			StopAllCoroutines();
			StartCoroutine ("GetMessageB");
		break;
		case TypeGo.GetTypeC:
			StopAllCoroutines();
			StartCoroutine ("GetMessageC");
		break;
            case TypeGo.GetTypeD:
                StopAllCoroutines();
                StartCoroutine("GetMessageD");

                break;
        }
	}
		
	IEnumerator GetMessageA()
	{
		string url=Static.Instance.URL+Data.URL;
		if (Data.SendData.Length > 0) 
		{
			foreach (DataValue child in Data.SendData)
			{
				message += "&" + child.Name + "=" +child.GetString();		        
			}      
		}
		message=EncryptDecipherTool.GetListOld(message,IsLock);	
		url = url + message;
        url = Uri.EscapeUriString(url);
        Debug.Log (url);
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.timeout = timeOut;
        
        //WWW www = new WWW(url);
        //yield return www;
        yield return www.Send();
        if (www.isError)
        //if (www.error != null)
		{
			Data.ShowMessage="error code = " + www.error;
            if (ShowError != null && !NoShow)
            {
                ShowError.SetActive(true);
                ShowError.GetComponentInChildren<Text>().text = www.error;
            }
                
			DoAction.Invoke ();
		}
		else
		{
            if (www.responseCode == 200)
            {  //string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes);
                string jsondata = www.downloadHandler.text;
                jsondata = jsondata.Remove(0, Data.CutCount);
                Data.ShowMessage = jsondata;
                //CreateFile(Application.streamingAssetsPath, "json.txt", jsondata);
                Static.Instance.DeleteFile(Application.persistentDataPath, "json.txt");
                Static.Instance.CreateFile(Application.persistentDataPath, "json.txt", jsondata);
                ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "json.txt");
                String sr = null;
                foreach (string str in infoall)
                {
                    sr += str;
                    Debug.Log(str);
                }



                JsonData jd = JsonMapper.ToObject(sr);
                Data.GetBase.code = jd.Keys.Contains("code") ? jd["code"].ToString() : "";
                Data.GetBase.result = jd.Keys.Contains("result") ? jd["result"].ToString() : "";
                Data.GetBase.msg = jd.Keys.Contains("msg") ? jd["msg"].ToString() : "";
                Data.GetBase.url = jd.Keys.Contains("url") ? jd["url"].ToString() : "";
                foreach (Value i in Data.GetBase.otherValue)
                {
                    try
                    {
                        if (i.valueText != null)
                            i.valueText.text = jd.Keys.Contains(i.valueName) ? jd[i.valueName].ToString() : "";
                        if (i.isSave)
                            Static.Instance.AddValue(i.valueName, jd.Keys.Contains(i.valueName) ? jd[i.valueName].ToString() : "");
                    }
                    catch
                    {
                        
                    }
                }

                if (Data.GetBase.msgInputtext != null)
                    Data.GetBase.msgInputtext.text = System.Math.Floor(float.Parse(Data.GetBase.msg)).ToString();
                if (Data.GetBase.codetext != null)
                    Data.GetBase.codetext.text = Data.GetBase.code;
                if (Data.GetBase.resulttext != null)
                    Data.GetBase.resulttext.text = Data.GetBase.result;
                if (Data.GetBase.msgtext != null)
                    Data.GetBase.msgtext.text = Data.GetBase.msg;
                if (Data.GetBase.urltext != null)
                    Data.GetBase.urltext.text = Data.GetBase.url;


                


                if (Data.GetBase.code == "2")
                {
                    ShowError.SetActive(true);
                    ShowError.GetComponentInChildren<Text>().text = Data.GetBase.msg;
                }
                if (Data.GetBase.code == "1")
                {
                    Suc.Invoke();
                    if (Data.SendData.Length > 0 && CleanInput)
                    {
                        foreach (DataValue child in Data.SendData)
                        {
                            if (child.SetInputField)
                                child.SetInputField.text = null;
                        }
                    }
                }
                    
                else if (Data.GetBase.code == "0")
                    Fal.Invoke();

                if (BusinessInfoHelper.Instance != null)
                {
                    BusinessInfoHelper.Instance.isDone = true;
                }
            }
            else
            {
                Data.ShowMessage = "error code = " + www.responseCode;
                if (ShowError != null && !NoShow)
                {
                    ShowError.SetActive(true);
                    ShowError.GetComponentInChildren<Text>().text = "error code"+ www.responseCode.ToString();
                }
            }
                



        }
               

        ShowLoad.SetActive(false);
	}


	IEnumerator GetMessageB()
	{
		string url=Static.Instance.URL+Data.URL;

		if (Data.SendData.Length > 0)
		{
			foreach (DataValue child in Data.SendData)
			{
				message += "&" + child.Name + "=" +child.GetString();		        
			}        
		}
		message=EncryptDecipherTool.GetListOld(message,IsLock);
		url = url + message;
		url = Uri.EscapeUriString(url);
		Debug.Log (url);
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.timeout = timeOut;
        //WWW www = new WWW(url);
        //yield return www;
        yield return www.Send();
        if (www.isError)
        {
            Data.ShowMessage = "error code = " + www.error;
            if (ShowError != null && !NoShow)
            {
                ShowError.SetActive(true);
                ShowError.GetComponentInChildren<Text>().text = www.error;
            }
        }
        else
        {
            if (www.responseCode == 200)
            {  //string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes);
                string jsondata = www.downloadHandler.text;

                jsondata = jsondata.Remove(0, Data.CutCount);
                int a = 0;
                //CreateFile(Application.streamingAssetsPath, "json.txt", jsondata);
                Static.Instance.DeleteFile(Application.persistentDataPath, "json.txt");
                Static.Instance.CreateFile(Application.persistentDataPath, "json.txt", jsondata);
                ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "json.txt");
                String sr = null;
                foreach (string str in infoall)
                {
                    sr += str;
                }
                JsonData jd = JsonMapper.ToObject(sr);
                Data.ShowMessage = jsondata;
                Debug.Log(jsondata);
                Data.GetBase.code = jd.Keys.Contains("code") ? jd["code"].ToString() : "";
                Data.GetBase.result = jd.Keys.Contains("result") ? jd["result"].ToString() : "";
                Data.GetBase.msg = jd.Keys.Contains("msg") ? jd["msg"].ToString() : "";

                foreach (Value i in Data.GetBase.otherValue)
                {
                    if (i.valueText != null)
                        i.valueText.text = jd.Keys.Contains(i.valueName) ? jd[i.valueName].ToString() : "";
                    if (i.isSave)
                        Static.Instance.AddValue(i.valueName, jd.Keys.Contains(i.valueName) ? jd[i.valueName].ToString() : "");
                }

                if (Data.GetBase.msgInputtext != null)
                    Data.GetBase.msgInputtext.text = System.Math.Floor(float.Parse(Data.GetBase.msg)).ToString();
                if (Data.GetBase.msgtext != null)
                    Data.GetBase.msgtext.text = Data.GetBase.msg;
                if (Data.GetBase.code == "1")
                {
                    List<string> Savename = new List<string>();
                    Dictionary<string, string> SaveMessage = new Dictionary<string, string>();

                    foreach (Transform child in Data.MyListMessage.FatherObj)
                    {
                        Destroy(child.gameObject);
                    }

                    Data.MyListMessage.SetVaule(jd[Data.DataName]);

                    if (Data.Action)
                    {
                        Data.GetData(SaveMessage);
                    }

                    //StartCoroutine(ListCountDelate(Findfather(Data.MyListMessage.FatherObj).GetComponent<ContentSizeFitter>()));
                }

                if (Data.GetBase.code == "2")
                {
                    ShowError.SetActive(true);
                    ShowError.GetComponentInChildren<Text>().text = Data.GetBase.msg;
                }
                if (Data.GetBase.code == "1")
                {
                    Suc.Invoke();
                    if (Data.SendData.Length > 0 && CleanInput)
                    {
                        foreach (DataValue child in Data.SendData)
                        {
                            if (child.SetInputField)
                                child.SetInputField.text = null;
                        }
                    }
                }
                else
                    Fal.Invoke();
                if (BusinessInfoHelper.Instance != null)
                {
                    BusinessInfoHelper.Instance.isDone = true;
                }

            }           
            else
            {
                Data.ShowMessage = "error code = " + www.responseCode;
                if (ShowError != null && !NoShow)
                {
                    ShowError.SetActive(true);
                    ShowError.GetComponentInChildren<Text>().text = "error code" + www.responseCode.ToString();
                }
            }


        }
        ShowLoad.SetActive(false);
	}

    public Transform Findfather(Transform obj)
    {
        Transform father = obj;
        try
        {
            if (obj.parent.GetComponent<ContentSizeFitter>() != null)
            {
                father = obj.parent;

                return Findfather(father);
            }
            else
                return father;
        }
        catch
        {
            return null;
        }
       
    }

    public void delate()
    {
        if(Findfather(Data.MyListMessage.FatherObj))
        StartCoroutine(ListCountDelate(Findfather(Data.MyListMessage.FatherObj).GetComponent<ContentSizeFitter>()));
    }

    IEnumerator ListCountDelate(ContentSizeFitter obj)
    {
        obj.enabled = false;
        yield return new WaitForSeconds(0.1f);
        obj.enabled = true;
        obj.gameObject.GetComponent<VerticalLayoutGroup>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        obj.gameObject.GetComponent<VerticalLayoutGroup>().enabled = true;
        Debug.Log(obj.gameObject.name);
    }



	string message=null;
	IEnumerator GetMessageC()
	{
		string url=Static.Instance.URL+Data.URL;
		if (Data.SendData.Length > 0)
		{
			foreach (DataValue child in Data.SendData)
			{
				message += "&" + child.Name + "=" +child.GetString();		        
			}        
		}
		message=EncryptDecipherTool.GetListOld(message,IsLock);
		url = url + message;
		url = Uri.EscapeUriString(url);
		Debug.Log (url);
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.timeout = timeOut;
        //WWW www = new WWW(url);
        //yield return www;
        yield return www.Send();
        if (www.isError)
        {
            Data.ShowMessage = "error code = " + www.error;
            if (ShowError != null && !NoShow)
            {
                ShowError.SetActive(true);
                ShowError.GetComponentInChildren<Text>().text = www.error;
            }
        }
        else
        {
            if (www.responseCode == 200)
            {  //string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes);
                string jsondata = www.downloadHandler.text;
                jsondata = jsondata.Remove(0, Data.CutCount);
                int a = 0;
                //CreateFile(Application.streamingAssetsPath, "json.txt", jsondata);
                Static.Instance.DeleteFile(Application.persistentDataPath, "json.txt");
                Static.Instance.CreateFile(Application.persistentDataPath, "json.txt", jsondata);
                ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "json.txt");
                String sr = null;
                foreach (string str in infoall)
                {
                    sr += str;
                }
                JsonData jd = JsonMapper.ToObject(sr);
                Data.ShowMessage = jsondata;
                Debug.Log(jsondata);
                Data.GetBase.code = jd.Keys.Contains("code") ? jd["code"].ToString() : "";
                Data.GetBase.result = jd.Keys.Contains("result") ? jd["result"].ToString() : "";
                Data.GetBase.msg = jd.Keys.Contains("msg") ? jd["msg"].ToString() : "";

                foreach (Value i in Data.GetBase.otherValue)
                {

                    if (i.valueText != null)
                        i.valueText.text = jd.Keys.Contains(i.valueName) ? jd[i.valueName].ToString() : "";
                    if (i.isSave)
                        Static.Instance.AddValue(i.valueName, jd.Keys.Contains(i.valueName) ? jd[i.valueName].ToString() : "");
                }

                if (Data.GetBase.msgInputtext != null)
                    Data.GetBase.msgInputtext.text = System.Math.Floor(float.Parse(Data.GetBase.msg)).ToString();
                if (Data.GetBase.codetext != null)
                    Data.GetBase.codetext.text = Data.GetBase.code;
                if (Data.GetBase.resulttext != null)
                    Data.GetBase.resulttext.text = Data.GetBase.result;
                if (Data.GetBase.msgtext != null)
                    Data.GetBase.msgtext.text = Data.GetBase.msg;
                if (Data.GetBase.urltext != null)
                    Data.GetBase.urltext.text = Data.GetBase.url;



                if (Data.GetBase.code == "1")
                {
                    List<string> Savename = new List<string>();
                    Dictionary<string, string> SaveMessage = new Dictionary<string, string>();

                    foreach (GameObject child in Data.MyListMessage.AllObj)
                        Destroy(child);
                    //Debug.Log (jd[Data.DataName]["name"]);

                    Data.MyListMessage.SetValueSingle(jd[Data.DataName]);


                    if (Data.Action)
                    {
                        Data.GetData(SaveMessage);
                    }
                }

                if (Data.GetBase.code == "2")
                {
                    ShowError.SetActive(true);
                    ShowError.GetComponentInChildren<Text>().text = Data.GetBase.msg;
                }
                if (Data.GetBase.code == "1")
                {
                    Suc.Invoke();
                    if (Data.SendData.Length > 0 && CleanInput)
                    {
                        foreach (DataValue child in Data.SendData)
                        {
                            if (child.SetInputField)
                                child.SetInputField.text = null;
                        }
                    }
                }
                else
                    Fal.Invoke();
                if (BusinessInfoHelper.Instance != null)
                {
                    BusinessInfoHelper.Instance.isDone = true;
                }
            }
            else
            {
                Data.ShowMessage = "error code = " + www.responseCode;
                if (ShowError != null && !NoShow)
                {
                    ShowError.SetActive(true);
                    ShowError.GetComponentInChildren<Text>().text = "error code" + www.responseCode.ToString();
                }
            }

        }
        ShowLoad.SetActive(false);
	}
    IEnumerator GetMessageD()
    {
        string url = Static.Instance.URL + Data.URL;
        if (Data.SendData.Length > 0)
        {
            foreach (DataValue child in Data.SendData)
            {
                message += "&" + child.Name + "=" + child.GetString();
            }
        }
        message = EncryptDecipherTool.GetListOld(message, IsLock);
        url = url + message;
        url = Uri.EscapeUriString(url);
        Debug.Log(url);
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.timeout = timeOut;
        //WWW www = new WWW(url);
        //yield return www;
        yield return www.Send();
        if (www.isError)
        {
            Data.ShowMessage = "error code = " + www.error;
            if (ShowError != null && !NoShow)
            {
                ShowError.SetActive(true);
                ShowError.GetComponentInChildren<Text>().text = www.error;
            }
        }
        else
        {
            if (www.responseCode == 200)
            {  //string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes);
                string jsondata = www.downloadHandler.text;
                jsondata = jsondata.Remove(0, Data.CutCount);
                int a = 0;
                //CreateFile(Application.streamingAssetsPath, "json.txt", jsondata);
                Static.Instance.DeleteFile(Application.persistentDataPath, "json.txt");
                Static.Instance.CreateFile(Application.persistentDataPath, "json.txt", jsondata);
                ArrayList infoall = Static.Instance.LoadFile(Application.persistentDataPath, "json.txt");
                String sr = null;
                foreach (string str in infoall)
                {
                    sr += str;
                }
                JsonData jd = JsonMapper.ToObject(sr);
                Data.ShowMessage = jsondata;
                Debug.Log(jsondata);
                Data.GetBase.code = jd.Keys.Contains("code") ? jd["code"].ToString() : "";
                Data.GetBase.result = jd.Keys.Contains("result") ? jd["result"].ToString() : "";
                Data.GetBase.msg = jd.Keys.Contains("msg") ? jd["msg"].ToString() : "";

                foreach (Value i in Data.GetBase.otherValue)
                {

                    if (i.valueText != null)
                        i.valueText.text = jd.Keys.Contains(i.valueName) ? jd[i.valueName].ToString() : "";
                    if (i.isSave)
                        Static.Instance.AddValue(i.valueName, jd.Keys.Contains(i.valueName) ? jd[i.valueName].ToString() : "");
                }

                if (Data.GetBase.msgInputtext != null)
                    Data.GetBase.msgInputtext.text = System.Math.Floor(float.Parse(Data.GetBase.msg)).ToString();
                if (Data.GetBase.code == "1")
                {
                    List<string> Savename = new List<string>();
                    Dictionary<string, string> SaveMessage = new Dictionary<string, string>();

                    Data.MyListMessage.SendData(jd);
                }

                if (Data.GetBase.code == "2")
                {
                    ShowError.SetActive(true);
                    ShowError.GetComponentInChildren<Text>().text = Data.GetBase.msg;
                }
                if (Data.GetBase.code == "1")
                {
                    Suc.Invoke();
                    if (Data.SendData.Length > 0 && CleanInput)
                    {
                        foreach (DataValue child in Data.SendData)
                        {
                            if (child.SetInputField)
                                child.SetInputField.text = null;
                        }
                    }
                }
                else
                    Fal.Invoke();
                if (BusinessInfoHelper.Instance != null)
                {
                    BusinessInfoHelper.Instance.isDone = true;
                }
            }
            else
            {
                Data.ShowMessage = "error code = " + www.responseCode;
                if (ShowError != null && !NoShow)
                {
                    ShowError.SetActive(true);
                    ShowError.GetComponentInChildren<Text>().text = "error code" + www.responseCode.ToString();
                }
            }

        }
        ShowLoad.SetActive(false);
    }
}
