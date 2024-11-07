using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticManager : MonoBehaviour
{
    public XRBaseController LeftController;
    public XRBaseController RightController;

    public float DefaultAmplitude = 0.5f;
    public float DefaultDuration = 0.5f;
    
    [HideInInspector] public HapticManager Instance{get; private set;}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void SendHaptics()
    {
        LeftController.SendHapticImpulse(DefaultAmplitude, DefaultDuration);        
        RightController.SendHapticImpulse(DefaultAmplitude, DefaultDuration);
    }

    public void SendHaptics(float Amplitude, float Duration)
    {
        LeftController.SendHapticImpulse(Amplitude, Duration);
        RightController.SendHapticImpulse(Amplitude, Duration);
    }

    public void SendHaptics(bool IsLeftController, float Amplitude,float Duration)
    {
        if (IsLeftController)
        {
            LeftController.SendHapticImpulse(Amplitude, Duration);
        }
        else
        {
            RightController.SendHapticImpulse(Amplitude, Duration);
        }
    }

    public static void SendHaptics(XRBaseController Controller, float Amplitude, float Duration)
    {
        Controller.SendHapticImpulse(Amplitude, Duration);
    }
}