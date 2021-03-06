using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    public Entity entity;
    public Animator animator;
    public Vector2 input, prevInput;
    public Vector2 facing, wasFacing;

    private void Start()
    {
        input = new Vector2(0, 0);
    }

    private void Update()
    {
        prevInput = input;
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if ((input.x != 0 || input.y != 0) && !(prevInput.x != 0 || prevInput.y != 0))
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", true);
        }
        else if ((input.x == 0 && input.y == 0) && !(prevInput.x == 0 && prevInput.y == 0))
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
        }
    }
}
