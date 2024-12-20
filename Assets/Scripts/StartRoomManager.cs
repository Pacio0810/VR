using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class StartRoomManager : MonoBehaviour
{
    [Header("Torch Settings")]
    public GameObject[] TorchInFirstRoom;
    [SerializeField] private UnityEvent AllFireOn;
    
    private int fireCounter = 0;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TorchFireObjectOn()
    {
        fireCounter++;
        if (fireCounter >= TorchInFirstRoom.Length)
        {
            audioSource.Play();
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
