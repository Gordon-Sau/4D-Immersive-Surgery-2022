using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class HMDInfoManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!XRSettings.isDeviceActive) {
            Debug.Log("Fail to load device");
        } else {
            Debug.Log("loaded device name: "+ XRSettings.loadedDeviceName);
        }
    }

}
