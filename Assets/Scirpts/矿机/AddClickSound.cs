using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddClickSound : MonoBehaviour {
    [SerializeField]
    GameObject SoundObj;
    public static AddClickSound Instance;
    // Use this for initialization
    private void Start()
    {
        Instance = this;
    }

    public void ButtonAddSound()
    {
        Instantiate(SoundObj);
    }
}
