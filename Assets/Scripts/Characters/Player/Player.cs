using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Mover _mover;
    private Flipper _flipper;
    private GroundDetector _groundDetector;
    private Jumper _jumper;
    private PlayerAnimator _playerAnimator;
    private float _previousDirection = 0;


    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _flipper = GetComponent<Flipper>();
        _groundDetector = GetComponent<GroundDetector>();
        _jumper = GetComponent<Jumper>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _mover.Move(_inputReader.Direction);

            if (_inputReader.Direction != _previousDirection)
            {
                _flipper.Flip(_inputReader.Direction);
            }

            _playerAnimator.WalkingStart();
            _previousDirection = _inputReader.Direction;
        }
        else
        {
            _playerAnimator.WalkingStop();
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
            _jumper.Jump();

        if (_groundDetector.IsGround == false)
            _playerAnimator.JumpingStart();
        else
            _playerAnimator.JumpingStop();
    }
}
