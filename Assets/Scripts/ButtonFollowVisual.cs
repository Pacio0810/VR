using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollowVisual : MonoBehaviour
{
    public Vector3 LocalAxis;
    public Transform VisualTarget;
    private Transform PokeAttachTransform;
    private Vector3 Offset;
    private Vector3 InizialLocalPosition;
    public float ResetSpeed = 5;
    public float followAngleThresold = 45;

    private XRBaseInteractable interactable;
    private bool IsFollowing;

    private bool IsFreeze;
    // Start is called before the first frame update
    void Start()
    {
        InizialLocalPosition = VisualTarget.localPosition;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.hoverEntered.AddListener(Follow);
        interactable.hoverExited.AddListener(Reset);
        interactable.selectEntered.AddListener(Freeze);
    }

    public void Follow(BaseInteractionEventArgs Hover)
    {
        if (Hover.interactableObject is XRPokeInteractor)
        {
            XRPokeInteractor Interactor = (XRPokeInteractor)Hover.interactableObject;
            
            PokeAttachTransform = Interactor.attachTransform;
            Offset = VisualTarget.position - PokeAttachTransform.position;

            float pokeAngle = Vector3.Angle(Offset, VisualTarget.TransformDirection(LocalAxis));
            if(pokeAngle < followAngleThresold)
            {
                IsFollowing = true;
                IsFreeze = false;
            }    
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFreeze)
        {
            return;
        }

        if (IsFollowing)
        {
            Vector3 localTargetposition = VisualTarget.InverseTransformPoint(PokeAttachTransform.position + Offset);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetposition, LocalAxis);
            VisualTarget.position = VisualTarget.TransformPoint(constrainedLocalTargetPosition);
        }
        else
        {
            VisualTarget.localPosition = Vector3.Lerp(VisualTarget.localPosition, InizialLocalPosition, Time.deltaTime * ResetSpeed);
        }
    }

    public void Reset(BaseInteractionEventArgs Hover)
    {
        if (Hover.interactableObject is XRPokeInteractor)
        {
            IsFollowing = false;
            IsFreeze = false;
        }
    }

    public void Freeze(BaseInteractionEventArgs Hover)
    {
        if (Hover.interactableObject is XRPokeInteractor)
        {
            IsFreeze = true;
        }
    }

}
