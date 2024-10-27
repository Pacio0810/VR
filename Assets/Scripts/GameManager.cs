using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject InteractionManager;

    GameManager instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(Player);
            DontDestroyOnLoad(InteractionManager);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
