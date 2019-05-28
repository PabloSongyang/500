using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class wwwform
{
    public string key;
    public Text value;
}


public class Camera_Contral : MonoBehaviour {

    [SerializeField]
    AndroidPhoto android;
    [SerializeField]
    IOSPhoto ios;


    [SerializeField]
    public string url;

    public wwwform[] others;




    public void OpenPhoto()
    {
#if UNITY_ANDROID
        android.contral_ = this;
        android.OpenPhoto();


#elif UNITY_IPHONE
        ios.contral_ = this;
        ios.OpenPhoto();
#endif
    }

    public void OpenCamera()
    {
#if UNITY_ANDROID
        android.contral_ = this;
        android.OpenCamera();
#elif UNITY_IPHONE
        ios.contral_ = this;
        ios.OpenCamera();
#endif
    }


    public UnityEvent Suc, Fal;


    [SerializeField]
    Image[] sprit;



    public void LoadImage(Text obj)
    {
        if (obj.text != null)
        {
            StartCoroutine(loadtexture(obj.text));
        }

    }
    public void LoadImage(string obj)
    {
        if (obj != null)
        {
            StartCoroutine(loadtexture(obj));
        }

    }
    [SerializeField]
    UnityEvent imgsuc,imgfal;
    [SerializeField]
    Sprite default_image;

    IEnumerator loadtexture(string obj)
    {
        Debug.Log(obj);

        foreach (Image i in sprit)
            i.sprite = default_image;

        WWW www = new WWW(obj);
        yield return www;
        if (www.error != null)
        {
            Debug.Log(www.error);
            imgfal.Invoke();
        }
        if (www != null && string.IsNullOrEmpty(www.error))
        {
            Sprite sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero);
            foreach(Image i in sprit)
            i.sprite = sprite;

            imgsuc.Invoke();

        }
    }



}
