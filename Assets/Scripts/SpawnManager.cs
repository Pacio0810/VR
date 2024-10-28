using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SpawnPlayerAtLocation;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SpawnPlayerAtLocation;
    }

    private void SpawnPlayerAtLocation(Scene ActiveScene, LoadSceneMode Mode)
    {
        if (sceneName != ActiveScene.name)
        {
            return;
        }
        
        if (PlayerManager.Instance != null)
        {
                PlayerManager.Instance.OnSceneLoaded(transform);
        }
        
    }
}
