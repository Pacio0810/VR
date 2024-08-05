using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MeteorPistol : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particles;

    public LayerMask LayerMask;
    public Transform ShootSource;
    public float distance = 10;

    private bool RayActivate = false;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());
    }

    public void StartShoot()
    {
        particles.Play();
        RayActivate = true;
    }

    public void StopShoot() 
    {
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        RayActivate = false;
    }

    private void Update()
    {
        if (RayActivate)
        {
            RaycastCheck();
        }
    }

    private void RaycastCheck()
    {
        RaycastHit hit;
        if(Physics.Raycast(ShootSource.position, ShootSource.forward, out hit, distance, LayerMask))
        {
            hit.transform.gameObject.SendMessage("Breake", SendMessageOptions.DontRequireReceiver);
        }
    }
}
