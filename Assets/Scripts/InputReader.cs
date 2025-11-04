using UnityEngine;
using UnityEngine.SceneManagement;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";
    public const KeyCode JumpButton = KeyCode.Space;
    public const KeyCode CureButton = KeyCode.H;
    public const KeyCode FirstAbilityButton = KeyCode.V;
    public const KeyCode RestartSceneButton = KeyCode.R;

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

        if (Input.GetKeyDown(RestartSceneButton))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
