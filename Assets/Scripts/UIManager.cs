using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [HideInInspector] public UIManager Instance {get; private set;}
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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

    public void LoadScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void ToggleActiveState(GameObject ObjectToToggle)
    {
        bool isActive = ObjectToToggle.activeInHierarchy;
        ObjectToToggle.SetActive(!isActive);
    }
}
