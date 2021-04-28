using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Pause : MonoBehaviour
{
    public InputDeviceCharacteristics controller;
    private InputDevice targetDevice;

    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInitialize();
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButton) && menuButton) {
            SongManager.paused = true;
            
        }
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controller, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }
}
