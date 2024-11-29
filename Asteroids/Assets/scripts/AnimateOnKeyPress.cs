using UnityEngine;

public class AnimateOnKeyPress : MonoBehaviour
{
    private Animator animator;
    public KeyCode triggerKey = KeyCode.W;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            animator.SetTrigger("PlayAnimation");
        }
    }
}
