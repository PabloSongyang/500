using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;
using LitJson;
using System;

public class IOSPhoto : MonoBehaviour
{
    //public HttpImage GetRaw;
    byte[] SaveHeadImg = null;
    // Use this for initialization

    [SerializeField]
    Image[] head;



    public Camera_Contral contral_;
    public string url;
    public void Initialization()
	{
		if (IOSAlbumCamera.Instance)
		{
			IOSAlbumCamera.Instance.CallBack_PickImage_With_Base64 += callback_PickImage_With_Base64;
			IOSAlbumCamera.Instance.CallBack_ImageSavedToAlbum += callback_imageSavedToAlbum;
		}
	}

	public void DestroyFuntion()
	{
		if (IOSAlbumCamera.Instance)
		{
			IOSAlbumCamera.Instance.CallBack_PickImage_With_Base64 -= callback_PickImage_With_Base64;
			IOSAlbumCamera.Instance.CallBack_ImageSavedToAlbum -= callback_imageSavedToAlbum;
		}
	}
	
	public void OpenPhoto()
	{
		IOSAlbumCamera.iosOpenPhotoLibrary (true);
	}

	void onclick_album()
	{
		IOSAlbumCamera.iosOpenPhotoAlbums (true);
	}

	public void OpenCamera()
	{
		IOSAlbumCamera.iosOpenCamera (true);
	}

	//void onclick_saveToAlbum()
	//{
	//	string path = Application.persistentDataPath + "/lzhscreenshot.png";
	//	Debug.Log (path);

	//	byte[] bytes = (rawImage.texture as Texture2D).EncodeToPNG ();
	//	System.IO.File.WriteAllBytes (path, bytes);

	//	IOSAlbumCamera.iosSaveImageToPhotosAlbum (path);

	//}

	void callback_PickImage_With_Base64(string base64)
	{
		Texture2D tex = IOSAlbumCamera.Base64StringToTexture2D (base64);
       
        SendImage(tex);
    }

    public void SendImage(Texture2D img)
    {
        float X = 0;
        float Y = 0;
        if (img.width > img.height)
        {
            X = 1024;
            Y = ((float)(img.height) / (float)img.width) * 1024;
        }
        else
        {
            Y = 1024;
            X = ((float)(img.width) / (float)img.height) * 1024;
        }
        Texture2D newtext = texture2DTexture(img, System.Convert.ToInt32(X), System.Convert.ToInt32(Y));
        string base64String = System.Convert.ToBase64String(newtext.EncodeToJPG());

        StartCoroutine(UploadTexture(base64String, Static.Instance.URL + contral_.url, contral_.others));
    }

    public Texture2D texture2DTexture(Texture2D tex, int swidth, int sheght)
    {
        Texture2D res = new Texture2D(swidth, sheght, TextureFormat.ARGB32, false);
        for (int i = 0; i < res.height; i++)
        {
            for (int j = 0; j < res.width; j++)
            {
                Color newcolor = tex.GetPixelBilinear((float)j / (float)res.width, (float)i / (float)res.height);
                res.SetPixel(j, i, newcolor);
            }
        }
        res.Apply();
        return res;
    }


    void callback_imageSavedToAlbum(string msg)
	{
		//txt_saveTip.text = msg;
	}

    public void SavePhotoButton()
    {
        StopAllCoroutines();
        if (SaveHeadImg != null && SaveHeadImg.Length != 0)
        {
            //GetRaw.SendIamge(SaveHeadImg);
        }
       
    }

    public void CamReset()
    {
        StopAllCoroutines();
        SaveHeadImg = null;
    }

    private GameObject ShowLoad;
    private GameObject ShowError;
    private void Start()
    {
        ShowLoad = ShowOrHit._Instance.HttpLoading.gameObject;
        ShowError = ShowOrHit._Instance.Worning.gameObject;
#if UNITY_IPHONE
        Initialization();
#endif
    }


    IEnumerator UploadTexture(string GetTex, string urla, wwwform[] other)
    {
        if (ShowLoad != null)
            ShowLoad.SetActive(true);
        //MessageManager._Instantiate.Show("上传开始");
        string url = urla;

        WWWForm form = new WWWForm();
        EncryptDecipherTool.Md5 aa = new EncryptDecipherTool.Md5();
        aa = EncryptDecipherTool.UserMd5Obj();
        form.AddField("huiyuan_id", Static.Instance.GetValue("huiyuan_id"));
        form.AddField("img_url", GetTex);
        form.AddField("token", aa.token);
        form.AddField("time", aa.time);
        foreach (wwwform i in other)
        {
            form.AddField(i.key, i.value.text);
        }

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        www.timeout = 5;
        Debug.Log(url);
        //  MessageManager._Instantiate.AddLockNub();
        //WWW www = new WWW(url, form);
        yield return www.Send();

        if (www.isError)
        //if (www.error != null)
        {
            ShowError.SetActive(true);
            ShowError.GetComponentInChildren<Text>().text = www.error;
        }
        else
        {
            if (www.responseCode == 200)
            {  //string jsondata = System.Text.Encoding.UTF8.GetString(www.bytes);
                string jsondata = www.downloadHandler.text;
                jsondata = jsondata.Remove(0, 0);
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
                string code = jd.Keys.Contains("code") ? jd["code"].ToString() : "";
                string msg = jd.Keys.Contains("msg") ? jd["msg"].ToString() : "";





                if (code == "2")
                {
                    ShowError.SetActive(true);
                    ShowError.GetComponentInChildren<Text>().text = "异地登录重新登录";
                }
                if (code == "1")
                {
                    ShowError.SetActive(true);
                    ShowError.GetComponentInChildren<Text>().text = msg;
                    contral_.Suc.Invoke();
                }
                else if (code == "0")
                {
                    ShowError.SetActive(true);
                    ShowError.GetComponentInChildren<Text>().text = msg;
                    contral_.Fal.Invoke();
                }
            }
            else
            {
                ShowError.SetActive(true);
                ShowError.GetComponentInChildren<Text>().text = "error code" + www.responseCode.ToString();
            }




        }


        ShowLoad.SetActive(false);
    }
}
