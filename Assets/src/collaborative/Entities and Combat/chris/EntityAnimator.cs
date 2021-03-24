using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimator : MonoBehaviour
{
    public Entity entity;
    public Animator animator = null;
    private bool playHurt = false;
    private bool playMeleeAttackAnimation = false;
    private bool playRangedAttackAnimation = false;

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            if (playMeleeAttackAnimation)
            {
                animator.SetTrigger("MeleeAttack");
                playMeleeAttackAnimation = false;
            }
            else if (playRangedAttackAnimation)
            {
                animator.SetTrigger("RangedAttack");
                playRangedAttackAnimation = false;
            }
            else if (playHurt)
            {
                animator.SetTrigger("IsHurt");
                playHurt = false;
            }
            else
            {
                if (entity.movement.IsMoving())// && !wasMoving)
                {
                    animator.SetTrigger("IsWalking");
                }
                else if (!entity.movement.IsMoving())// && wasMoving)
                {
                    animator.SetTrigger("IsIdle");
                }
            }
        }
    }

    public void PlayHurtAnimation()
    {
        playHurt = true;
    }

    public void PlayMeleeAttackAnimation()
    {
        playMeleeAttackAnimation = true;
    }

    public void PlayRangedAttackAnimation()
    {
        playRangedAttackAnimation = true;
    }
}
