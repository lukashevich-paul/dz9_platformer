using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{

    public const string Horizontal = "Horizontal";
    public const KeyCode JumpButton = KeyCode.Space;

    private bool _isJump;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(JumpButton))
            _isJump = true;
    }

    public bool GetIsJump()
    {
        bool localValue = _isJump;
        _isJump = false;
        return localValue;
    }
}
