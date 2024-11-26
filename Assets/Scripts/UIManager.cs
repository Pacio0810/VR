using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Management;

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

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToggleActiveState(GameObject ObjectToToggle)
    {
        bool isActive = ObjectToToggle.activeInHierarchy;
        ObjectToToggle.SetActive(!isActive);
    }

    public void RecenterView()
    {
        var xrSubsystem = XRGeneralSettings.Instance?.Manager?.activeLoader?.GetLoadedSubsystem<XRInputSubsystem>();
        if (xrSubsystem != null)
        {
            xrSubsystem.TryRecenter();
        }
    }
}
