using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InsertCodeKeypad : MonoBehaviour
{
    public int KeypadLimitPassword = 4;
    public string PasswordValue = "";
    [SerializeField]
    private TextMeshPro PasswordText;
    private int CodeInsertCount = 0;
    private string CurrentPasswordText = "";


    private AudioSource AudioSource;
    [SerializeField]
    public AudioClip WrongPasswordAudio;
    [SerializeField]
    public AudioClip CorrectPasswordAudio;
    [SerializeField]
    public AudioClip AddCodeAudio;

    private bool CantInsertCode = true;


    [SerializeField]
    Animator ObjAnimator;
    string BoolName = "Open";

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CodeInsertCount == KeypadLimitPassword)
        {
            if (CurrentPasswordText == PasswordValue)
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
        if (CodeInsertCount >= KeypadLimitPassword)
        {
            return;
        }
        PasswordText.color = Color.white;
        CurrentPasswordText = CurrentPasswordText + value.ToString();
        PasswordText.text = CurrentPasswordText;
        PlayAudio(AddCodeAudio);
        CodeInsertCount++;
    }

    public IEnumerator WrongPassword()
    {
        CantInsertCode = false;
        CodeInsertCount = 0;
        PlayAudio(WrongPasswordAudio);
        PasswordText.color = Color.red;
        yield return new WaitForSeconds(1);
        ResetPassword();
    }

    public IEnumerator CorrectPassword()
    {
        CantInsertCode = false;
        CodeInsertCount = 0;
        PasswordText.color = Color.green;
        PlayAudio(CorrectPasswordAudio);
        yield return new WaitForSeconds(1);
        ToggleDoorOpen();
        ResetPassword();
    }

    void ResetPassword()
    {
        CantInsertCode = true;
        CurrentPasswordText = "";
        PasswordText.text = CurrentPasswordText;
    }

    void PlayAudio(AudioClip audioClip)
    {
        AudioSource.clip = audioClip;
        AudioSource.Play();
    }

    public void ToggleDoorOpen()
    {
        bool isOpen = ObjAnimator.GetBool(BoolName);
        ObjAnimator.SetBool(BoolName, !isOpen);
    }
}
