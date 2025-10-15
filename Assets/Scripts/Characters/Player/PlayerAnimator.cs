using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    public readonly int WalkSpeed = Animator.StringToHash(nameof(WalkSpeed));
    public readonly int Jump = Animator.StringToHash(nameof(Jump));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move(float xVelocity)
    {
        _animator.SetFloat(WalkSpeed, xVelocity);
    }

    public void JumpStart()
    {
        _animator.SetBool(Jump, true);
    }

    public void JumpStop()
    {
        _animator.SetBool(Jump, false);
    }
}
