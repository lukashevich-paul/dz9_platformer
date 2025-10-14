using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";
    public const KeyCode JumpButton = KeyCode.Space;
    public const KeyCode CureButton = KeyCode.H;

    private bool _isJump;
    private bool _isCure;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(JumpButton))
            _isJump = true;

        if (Input.GetKeyDown(CureButton))
            _isCure = true;
    }

    public bool GetIsJump()
    {
        bool localValue = _isJump;
        _isJump = false;
        return localValue;
    }

    public bool GetIsCure()
    {
        bool localValue = _isCure;
        _isCure = false;
        return localValue;
    }
}
