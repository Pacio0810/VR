using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void QuitApplication()
    {
        Application.Quit();
    }
}
