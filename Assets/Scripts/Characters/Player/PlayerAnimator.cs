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

    public void WalkingStart()
    {
        _animator.SetBool(Walk, true);
    }

    public void WalkingStop()
    {
        _animator.SetBool(Walk, false);
    }

    public void JumpingStart()
    {
        _animator.SetBool(Jump, true);
    }

    public void JumpingStop()
    {
        _animator.SetBool(Jump, false);
    }
}
