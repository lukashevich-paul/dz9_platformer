using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";

    private bool _isJump;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(KeyCode.Space))
            _isJump = true;
    }

    public bool GetIsJump()
    {
        bool localValue = _isJump;
        _isJump = false;
        return localValue;
    }
}
