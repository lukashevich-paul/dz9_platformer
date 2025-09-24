using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Mover _mover;
    private Flipper _flipper;
    private GroundDetector _ground;
    private Jumper _jumper;
    private Animator _animator;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _flipper = GetComponent<Flipper>();
        _ground = GetComponent<GroundDetector>();
        _jumper = GetComponent<Jumper>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _mover.Move(_inputReader.Direction);
            _flipper.Flip(_inputReader.Direction);
            _animator.SetBool("walk", true);
        }
        else
        {
            _animator.SetBool("walk", false);
        }

        if (_ground.IsGround)
        {
            if (_inputReader.GetIsJump())
            {
                _jumper.Jump();
            }

            _animator.SetBool("jump", false);
        }
        else
        {
            _animator.SetBool("jump", true);
        }
    }
}
