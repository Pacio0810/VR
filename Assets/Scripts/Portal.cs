using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private int sceneIndexOffset;

    private void OnTriggerEnter(Collider Other)
    {
        if(Other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndexOffset);   
        }
    }
}
