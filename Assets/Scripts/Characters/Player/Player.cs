using System;
using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private Mover _mover;
    private Flipper _flipper;
    private GroundDetector _groundDetector;
    private Jumper _jumper;
    private PlayerAnimator _playerAnimator;
    private float _previousDirection = 0;
    private Health _health;
    private Wallet _wallet;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _flipper = GetComponent<Flipper>();
        _groundDetector = GetComponent<GroundDetector>();
        _jumper = GetComponent<Jumper>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _health = GetComponent<Health>();
        _wallet = GetComponent<Wallet>();
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

            _previousDirection = _inputReader.Direction;
        }

        _playerAnimator.Moving(Math.Abs(_inputReader.Direction));

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
            _jumper.Jump();

        if (_groundDetector.IsGround == false)
            _playerAnimator.JumpingStart();
        else
            _playerAnimator.JumpingStop();

        if (_inputReader.GetIsCure() && _wallet.Health > 0)
        {
            _wallet.DecreaseHealth();
            print(_wallet.ToString());

            _health.TakeCure();
        }
    }
}
