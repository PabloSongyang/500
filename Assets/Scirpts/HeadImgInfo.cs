using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadImgInfo : MonoBehaviour {
    [SerializeField]
    AndroidPhoto AndroidDevice;
    [SerializeField]
    IOSPhoto IOSDevice;

    private void Start()
    {
#if UNITY_ANDROID
        AndroidDevice.Initialization();
#elif UNITY_IPHONE
        IOSDevice.Initialization();
#endif
    }

    void OnDestroy()
    {
#if UNITY_ANDROID

#elif UNITY_IPHONE
        IOSDevice.DestroyFuntion();
#endif
    }


    public void OpenCamera()
    {
#if UNITY_ANDROID
        AndroidDevice.OpenCamera();
#elif UNITY_IPHONE
         IOSDevice.OpenCamera();
#endif

    }
    public void OpenPhoto()
    {
#if UNITY_ANDROID
        AndroidDevice.OpenPhoto();
#elif UNITY_IPHONE
         IOSDevice.OpenPhoto();
#endif
    }

    public void SaveHeadImg()
    {
#if UNITY_ANDROID
        AndroidDevice.SavePhotoButton();
#elif UNITY_IPHONE
        IOSDevice.SavePhotoButton();
#endif
    }

    public void ResetCam()
    {
#if UNITY_ANDROID
        AndroidDevice.CamReset();
#elif UNITY_IPHONE
         IOSDevice.CamReset();
#endif
    }
}
