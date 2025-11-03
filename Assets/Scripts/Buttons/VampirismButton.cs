using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class VampirismButton : MonoBehaviour
{
    public const string RunLetter = "V";
    public const string ToStringFormat = "F0";

    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private TextMeshProUGUI _buttionText;

    private Button _button;
    private Image _buttonImage;
    private bool _isUpdateButton = false;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _buttonImage = GetComponent<Image>();
        _buttionText = _button.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Activate);
        _vampirism.StatusChange += UpdateView;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Activate);
        _vampirism.StatusChange -= UpdateView;
    }

    private void Update()
    {
        if (_isUpdateButton)
        {
            if (_vampirism.CurrentStatus == Vampirism.Statuses.Active)
            {
                _buttionText.text = _vampirism.ActiveSeconds.ToString(ToStringFormat);
                _buttonImage.color = Color.red;
            }
            else if (_vampirism.CurrentStatus == Vampirism.Statuses.Charge)
            {
                _buttonImage.color = Color.gray;
                _buttionText.text = _vampirism.ChargeSeconds.ToString(ToStringFormat);
            }
        }
        else
        {
            _buttonImage.color = Color.white;
            _buttionText.text = RunLetter;
        }
    }

    private void Activate()
    {
        _vampirism.gameObject.SetActive(true);
        _vampirism.Run();
    }

    private void UpdateView()
    {
        switch (_vampirism.CurrentStatus)
        {
            case Vampirism.Statuses.Active:
                _isUpdateButton = true;
                break;
            case Vampirism.Statuses.Charge:
                _isUpdateButton = true;
                break;
            default:
                _isUpdateButton = false;
                break;
        }
    }
}
