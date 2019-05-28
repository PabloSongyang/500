using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class My_YHJList : MonoBehaviour {

    [SerializeField]
    Image sprit;



    public void LoadImage(string obj)
    {
        if (obj != null)
        {
            StartCoroutine(loadtexture(obj));
        }
        
    }


    IEnumerator loadtexture(string obj)
    {
        WWW www = new WWW(obj);
        yield return www;
        if (www != null && string.IsNullOrEmpty(www.error))
        {
            Sprite sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero);
            sprit.sprite = sprite;

        }
    }
}
