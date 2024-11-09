using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InsertCodeKeypad : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private TextMeshPro passwordText;
    [SerializeField] int keypadLimitPassword = 4;
    [SerializeField] string PasswordValue = "";

    private int codeInsertCount = 0;
    private string currentPasswordText = "";

    [Header("AudioClip")]
    [SerializeField] public AudioClip WrongPasswordAudio;
    [SerializeField] public AudioClip CorrectPasswordAudio;
    [SerializeField] public AudioClip AddCodeAudio;

    private AudioSource AudioSource;
    private bool CantInsertCode = true;

    [SerializeField] private UnityEvent CorretPasswordEvent;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (codeInsertCount == keypadLimitPassword)
        {
            if (currentPasswordText == PasswordValue)
            {
                StartCoroutine(CorrectPassword());
                // open door
            }
            else
            {
                StartCoroutine(WrongPassword());
            }
        }
    }

    public void AddCodeToPassword(int value)
    {
        if(!CantInsertCode)
        {
            return;
        }
        if (codeInsertCount >= keypadLimitPassword)
        {
            return;
        }
        passwordText.color = Color.white;
        currentPasswordText = currentPasswordText + value.ToString();
        passwordText.text = currentPasswordText;
        PlayAudio(AddCodeAudio);
        codeInsertCount++;
    }

    public IEnumerator WrongPassword()
    {
        CantInsertCode = false;
        codeInsertCount = 0;
        PlayAudio(WrongPasswordAudio);
        passwordText.color = Color.red;
        yield return new WaitForSeconds(1);
        ResetPassword();
    }

    public IEnumerator CorrectPassword()
    {
        CantInsertCode = false;
        codeInsertCount = 0;
        passwordText.color = Color.green;
        PlayAudio(CorrectPasswordAudio);
        yield return new WaitForSeconds(1);
        CorretPasswordEvent.Invoke();
        ResetPassword();
    }

    void ResetPassword()
    {
        CantInsertCode = true;
        currentPasswordText = "";
        passwordText.text = currentPasswordText;
    }

    void PlayAudio(AudioClip audioClip)
    {
        AudioSource.clip = audioClip;
        AudioSource.Play();
    }
}
