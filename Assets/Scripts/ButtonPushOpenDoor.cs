using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPushOpenDoor : MonoBehaviour
{
    [SerializeField]
    Animator Animator;
    string BoolName = "Open";

    void Start()
    {
        //GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ToggleDoorOpen());
    }

    public void ToggleDoorOpen()
    {
        bool isOpen = Animator.GetBool(BoolName);
        Animator.SetBool(BoolName, !isOpen);
    }
}
