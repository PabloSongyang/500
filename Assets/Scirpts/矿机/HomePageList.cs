using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class KJ_Attribute
{
    public Text id;
    public Text name;
    public Text num;
    public Text arithmetic;
    public Text cycle;
    public Text price;
}

public class HomePageList : MonoBehaviour
{
    
    [SerializeField]
    KJ_Attribute kj;
    [SerializeField]
    Button GouMaiButton;


   
    // Use this for initialization
    void Start () {
        GouMaiButton.onClick.AddListener(delegate {
            HomePage.Instance.GouMai(kj);
        });

    }
}
