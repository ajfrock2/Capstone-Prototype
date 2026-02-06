using UnityEngine;

/// <summary>
/// Controls flashlight on/off state, light component, and battery. Attach to Player with a child Light.
/// </summary>
[RequireComponent(typeof(FlashlightBattery))]
public class FlashlightController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    [Tooltip("The Light component (Spot or Point). Assign in Inspector or will use GetComponentInChildren.")]
    private Light _flashlight;

    [SerializeField]
    [Tooltip("AudioSource for on/off and low battery sounds. Optional.")]
    private AudioSource _audioSource;

    [Header("Audio Clips (optional)")]
    [SerializeField]
    [Tooltip("Sound when flashlight turns on")]
    private AudioClip _onSound;

    [SerializeField]
    [Tooltip("Sound when flashlight turns off")]
    private AudioClip _offSound;

    [SerializeField]
    [Tooltip("Sound when battery is low")]
    private AudioClip _lowBatterySound;

    private FlashlightBattery _battery;
    private bool _isOn;

    public bool IsOn => _isOn;

    private void Awake()
    {
        _battery = GetComponent<FlashlightBattery>();
        if (_flashlight == null)
            _flashlight = GetComponentInChildren<Light>();
        if (_audioSource == null)
            _audioSource = GetComponent<AudioSource>();

        _flashlight.enabled = false;
        _isOn = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Toggle();

        if (_isOn)
        {
            _battery.Deplete(Time.deltaTime);
            if (_battery.CurrentBatteryPercent <= 0f)
                TurnOff();
            else if (_battery.IsLowBattery && !_battery.HasPlayedLowBatteryWarning)
                PlayLowBatterySound();
        }
        else
        {
            _battery.Recharge(Time.deltaTime);
            _battery.ResetLowBatteryWarning();
        }
    }

    public void Toggle()
    {
        if (_isOn)
            TurnOff();
        else
            TurnOn();
    }

    public void TurnOn()
    {
        if (!_battery.CanTurnOn)
            return;

        _isOn = true;
        if (_flashlight != null)
            _flashlight.enabled = true;
        PlaySound(_onSound);
    }

    public void TurnOff()
    {
        _isOn = false;
        if (_flashlight != null)
            _flashlight.enabled = false;
        PlaySound(_offSound);
        _battery.MarkLowBatteryWarningPlayed();
    }

    private void PlayLowBatterySound()
    {
        PlaySound(_lowBatterySound);
        _battery.MarkLowBatteryWarningPlayed();
    }

    private void PlaySound(AudioClip clip)
    {
        if (_audioSource != null && clip != null)
            _audioSource.PlayOneShot(clip);
    }
}
