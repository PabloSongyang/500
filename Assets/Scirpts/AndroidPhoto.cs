using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
using LitJson;
using UnityEngine.Events;

public class AndroidPhoto : MonoBehaviour {

	//public HttpImage GetRaw;
	public GameObject SendObj;

    byte[] SaveHeadImg = null;

    [SerializeField]
    Image[] head;
    //打开相册	

    public Camera_Contral contral_;

	public void Initialization()
	{
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		jo.Call("SetName",SendObj.name);
	}

	public void OpenPhoto()
	{
        AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
        jo.Call("OpenGallery");
        //Laodtext();
    }

    //private Texture2D TextureToTexture2D(Texture texture)
    //{
    //    Texture2D texture2d = texture as Texture2D;
    //    UnityEditor.TextureImporter ti = (UnityEditor.TextureImporter)UnityEditor.TextureImporter.GetAtPath(UnityEditor.AssetDatabase.GetAssetPath(texture2d));
    //    //图片Read/Write Enable的开关
    //    ti.isReadable = true;
    //    UnityEditor.AssetDatabase.ImportAsset(UnityEditor.AssetDatabase.GetAssetPath(texture2d));
    //    return texture2d;
    //}

    //打开相机
    public void OpenCamera()
	{
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
		jo.Call("takephoto");       
	}


	public static Texture2D Base64StringToTexture2D(string base64)
	{
		Texture2D tex = new Texture2D (4, 4, TextureFormat.ARGB32, false);
		try
		{
			byte[] bytes = System.Convert.FromBase64String(base64);
			tex.LoadImage(bytes);
		}
		catch(System.Exception ex)
		{
			Debug.LogError(ex.Message);
		}
		return tex;
	}    


	public void GetImagePath(string imagePath)
	{ 
		if (imagePath == null)
			return;
		StartCoroutine("LoadImage",imagePath);
	}

	public void GetTakeImagePath(string imagePath)
	{
		if (imagePath == null)
			return;
		StartCoroutine("LoadImage",imagePath);
	}


	private IEnumerator LoadImage(string imagePath)
	{
        WWW www = new WWW ("file://"+imagePath);
		yield return www;
		if (www.error == null) 
		{
           
            SendImage(www.texture);
        }
		else
		{
			Debug.Log( www.error);
		}
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

        StartCoroutine(UploadTexture(base64String, Static.Instance.URL + contral_.url,contral_.others));
    }




    private Texture2D CutTexture(Texture2D resTexture)
    {
        int picWidth = resTexture.width;
        int picHeight = resTexture.width;
        int picPos_y = (resTexture.height - resTexture.width) / 2;
        int picPos_x = 0;
        Texture2D newTexture = new Texture2D(picWidth, picHeight);
        for (int m = picPos_y; m < picPos_y + picHeight; ++m)
        {
            for (int n = picPos_x; n < picPos_x + picWidth; ++n)
            {
                Color color = resTexture.GetPixel(n, resTexture.height - m);
                newTexture.SetPixel(n - picPos_x, picHeight - (m - picPos_y), color);
            }
        }
        newTexture.Apply();
        return newTexture;
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

    private Texture2D ScaleTexture (Texture2D source, int targetWidth, int targetHeight)
	{
		Texture2D result = new Texture2D (targetWidth, targetHeight, source.format, true);
		Color[] rpixels = result.GetPixels (0);
		float incX = ((float)1 / source.width) * ((float)source.width / targetWidth);
		float incY = ((float)1 / source.height) * ((float)source.height / targetHeight);
		for (int px = 0; px < rpixels.Length; px++) {
			rpixels [px] = source.GetPixelBilinear (incX * ((float)px % targetWidth), incY * ((float)Mathf.Floor (px / targetWidth)));
		}
		result.SetPixels (rpixels, 0);
		result.Apply ();
		return result;
	}


		
	private IEnumerator UpdataImage(Texture2D texture)
	{
		//mLog.text = mLog.text + "\n 开始转化为精灵";
		Sprite sprite = Sprite.Create(texture, new Rect(0,0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
		//mImage.sprite = sprite;
		//mLog.text = mLog.text + "\n 转换结束";
		yield return new WaitForSeconds(0.01f);
		Resources.UnloadUnusedAssets();
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

    public Texture2D tex;
    public void Laodtext()
    {
        float X = 0;
        float Y = 0;
        if (tex.width > tex.height)
        {
            X = 256.0f;
            Y = ((float)(tex.height) / (float)tex.width) * 256f;
        }
        else
        {
            Y = 256.0f;
            X = ((float)(tex.width) / (float)tex.height) * 256f;
        }
        //Color[] AA=tex.GetPixels();
        //tex.Resize(tex.width/4,tex.height/4,TextureFormat.ARGB32,false);
        //tex.SetPixels(AA);
        //tex.Apply();
        Texture2D newtext = texture2DTexture(tex, System.Convert.ToInt32(X), System.Convert.ToInt32(Y));
        Debug.Log(tex.width + "--" + tex.height);
        string base64String = System.Convert.ToBase64String(newtext.EncodeToPNG());
        //StartCoroutine(UploadTexture(base64String, Static.Instance.URL + "ajax_up_img.php",null));
        StartCoroutine(UploadTexture(base64String, Static.Instance.URL + contral_.url, contral_.others));
    }
    private GameObject ShowLoad;
    private GameObject ShowError;
    private void Start()
    {
        ShowLoad = ShowOrHit._Instance.HttpLoading.gameObject;
        ShowError = ShowOrHit._Instance.Worning.gameObject;
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
            form.AddField(i.key,i.value.text);
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
	
