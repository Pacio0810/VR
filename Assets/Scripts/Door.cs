using UnityEngine;

public class Door : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ToggleDoor()
    {
        bool value = animator.GetBool("Open");
        animator.SetBool("Open", !value);
    }
}
