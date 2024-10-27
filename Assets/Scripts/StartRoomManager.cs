using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartRoomManager : MonoBehaviour
{
    [Header("Torch Settings")]
    [SerializeField] private UnityEvent AllFireOn;
    public int TorchCountInRoom;

    private int fireCounter = 0;
    
    public void TorchFireObjectOn()
    {
        fireCounter++;
        Debug.Log(fireCounter);
        if (fireCounter >= TorchCountInRoom)
        {
            AllFireOn.Invoke();
        }
    }

    public void TorchFireObjectOff()
    {
        fireCounter--;
    }
}
