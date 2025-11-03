using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";
    public const KeyCode JumpButton = KeyCode.Space;
    public const KeyCode CureButton = KeyCode.H;
    public const KeyCode FirstAbilityButton = KeyCode.V;

    private bool _isJump;
    private bool _isCure;
    private bool _isFirstAbility;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(JumpButton))
            _isJump = true;

        if (Input.GetKeyDown(CureButton))
            _isCure = true;

        if (Input.GetKeyDown(FirstAbilityButton))
            _isFirstAbility = true;
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

    public bool GetIsFirstAbility()
    {
        bool localValue = _isFirstAbility;
        _isFirstAbility = false;
        return localValue;
    }
}
