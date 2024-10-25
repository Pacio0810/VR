using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] string SceneName;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SpawnPlayerAtLocation;
    }

    private void SpawnPlayerAtLocation(Scene ActiveScene, LoadSceneMode mode)
    {
        Debug.Log(ActiveScene.name);
        if (SceneName == ActiveScene.name)
        {
            if (PlayerManager.Instance != null)
            {
                PlayerManager.Instance.OnSceneLoaded(transform);
            }
        }
    }
}
