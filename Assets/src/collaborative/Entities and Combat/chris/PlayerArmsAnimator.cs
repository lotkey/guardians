using UnityEngine;

public class PlayerArmsAnimator : MonoBehaviour
{
    public WeaponIconType weaponType;
    private Player player;
    public Animator animator = null;
    private bool playHurt = false;
    private bool playAttackAnimation = false;

    private string currentState = "Sword_Idle";
    private string SWORD_IDLE = "Sword_Idle";
    private string SWORD_HURT = "Sword_Hurt";
    private string SWORD_ATTACK = "Sword_Attack";
    private string SWORD_WALK = "Sword_Walk";

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        player = Player.GetPlayer();
        if (animator != null)
        {
            if (!(playHurt || playAttackAnimation))
            {
                if (player.movement.IsMoving())
                {
                    switch (weaponType)
                    {
                        case (WeaponIconType.SWORD):
                            ChangeAnimationState(SWORD_WALK);
                            break;
                        default:
                            break;
                    }
                }
                else if (!player.movement.IsMoving())
                {
                    switch (weaponType)
                    {
                        case(WeaponIconType.SWORD):
                            ChangeAnimationState(SWORD_IDLE);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    public void PlayHurtAnimation()
    {
        playHurt = true;
        switch (weaponType)
        {
            case (WeaponIconType.SWORD):
                ChangeAnimationState(SWORD_HURT);
                break;
            default:
                break;
        }
        CancelInvoke("StopHurtAnimation");
        Invoke("StopHurtAnimation", .25f);
    }

    public void PlayAttackAnimation()
    {
        playAttackAnimation = true;
        switch (weaponType)
        {
            case (WeaponIconType.SWORD):
                ChangeAnimationState(SWORD_ATTACK);
                break;
            default:
                break;
        }
        CancelInvoke("StopAttackAnimation");
        Invoke("StopAttackAnimation", animator.GetCurrentAnimatorStateInfo(0).length);
    }

    private void StopHurtAnimation()
    {
        playHurt = false;
        switch (weaponType)
        {
            case (WeaponIconType.SWORD):
                ChangeAnimationState(SWORD_IDLE);
                break;
            default:
                break;
        }
    }

    private void StopAttackAnimation()
    {
        playAttackAnimation = false;
        switch (weaponType)
        {
            case (WeaponIconType.SWORD):
                ChangeAnimationState(SWORD_IDLE);
                break;
            default:
                break;
        }
    }

    public void SwitchWeapon(WeaponIconType weaponIconType)
    {
        this.weaponType = weaponIconType;
    }

    private void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
        {
            return;
        }
        else
        {
            animator.Play(newState);
            currentState = newState;
        }
    }
}