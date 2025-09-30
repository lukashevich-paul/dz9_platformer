using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    public readonly int Walk = Animator.StringToHash(nameof(Walk));
    public readonly int Jump = Animator.StringToHash(nameof(Jump));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetWalking(bool isWalking)
    {
        _animator.SetBool(Walk, isWalking);
    }

    public void SetJumping(bool isJumping)
    {
        _animator.SetBool(Jump, isJumping);
    }
}
