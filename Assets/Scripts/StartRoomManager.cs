using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartRoomManager : MonoBehaviour
{
    [Header("Torch Settings")]
    public GameObject[] TorchInFirstRoom;
    [SerializeField] private UnityEvent AllFireOn;


    private int fireCounter = 0;
    
    public void TorchFireObjectOn()
    {
        fireCounter++;
        if (fireCounter >= TorchInFirstRoom.Length)
        {
            AllFireOn.Invoke();
            FirstMissionComplete();
        }
    }

    public void FirstMissionComplete()
    {
        for (int i = 0; i < TorchInFirstRoom.Length; i++)
        {
            TorchInFirstRoom[i].GetComponent<TorchInteraction>().enabled = false;
        }
    }

    public void TorchFireObjectOff()
    {
        fireCounter--;
    }
}
