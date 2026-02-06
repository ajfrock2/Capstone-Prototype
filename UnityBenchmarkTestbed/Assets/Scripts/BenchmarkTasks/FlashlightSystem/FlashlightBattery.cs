using UnityEngine;

/// <summary>
/// Manages battery level for the flashlight. Depletes when active, recharges when inactive.
/// </summary>
public class FlashlightBattery : MonoBehaviour
{
    [Header("Battery Settings")]
    [SerializeField]
    [Range(0f, 100f)]
    [Tooltip("Starting battery percentage (0-100)")]
    private float _startingBatteryPercent = 100f;

    [SerializeField]
    [Range(0.1f, 50f)]
    [Tooltip("Battery drain per second when flashlight is on")]
    private float _depletionRatePerSecond = 5f;

    [SerializeField]
    [Range(0.1f, 50f)]
    [Tooltip("Battery recharge per second when flashlight is off")]
    private float _rechargeRatePerSecond = 10f;

    [SerializeField]
    [Range(0f, 30f)]
    [Tooltip("Minimum battery % required to turn flashlight on")]
    private float _minimumBatteryToTurnOn = 5f;

    [SerializeField]
    [Range(0f, 50f)]
    [Tooltip("Battery % at which low battery warning plays")]
    private float _lowBatteryThreshold = 20f;

    private float _currentBatteryPercent;
    private bool _hasPlayedLowBatteryWarning;

    /// <summary>
    /// Current battery level as percentage (0-100).
    /// </summary>
    public float CurrentBatteryPercent => _currentBatteryPercent;

    /// <summary>
    /// Whether the battery has enough charge to turn the flashlight on.
    /// </summary>
    public bool CanTurnOn => _currentBatteryPercent >= _minimumBatteryToTurnOn;

    /// <summary>
    /// Whether the battery is below the low battery threshold.
    /// </summary>
    public bool IsLowBattery => _currentBatteryPercent <= _lowBatteryThreshold;

    /// <summary>
    /// Whether the low battery warning has already been played this depletion cycle.
    /// </summary>
    public bool HasPlayedLowBatteryWarning => _hasPlayedLowBatteryWarning;

    public void MarkLowBatteryWarningPlayed() => _hasPlayedLowBatteryWarning = true;

    public void ResetLowBatteryWarning() => _hasPlayedLowBatteryWarning = false;

    private void Awake()
    {
        _currentBatteryPercent = Mathf.Clamp(_startingBatteryPercent, 0f, 100f);
    }

    /// <summary>
    /// Call each frame when flashlight is on. Returns updated battery percent.
    /// </summary>
    public float Deplete(float deltaTime)
    {
        _currentBatteryPercent = Mathf.Max(0f, _currentBatteryPercent - _depletionRatePerSecond * deltaTime);
        if (_currentBatteryPercent <= _lowBatteryThreshold)
            _hasPlayedLowBatteryWarning = true;
        return _currentBatteryPercent;
    }

    /// <summary>
    /// Call each frame when flashlight is off. Returns updated battery percent.
    /// </summary>
    public float Recharge(float deltaTime)
    {
        _currentBatteryPercent = Mathf.Min(100f, _currentBatteryPercent + _rechargeRatePerSecond * deltaTime);
        if (_currentBatteryPercent > _lowBatteryThreshold)
            _hasPlayedLowBatteryWarning = false;
        return _currentBatteryPercent;
    }
}
