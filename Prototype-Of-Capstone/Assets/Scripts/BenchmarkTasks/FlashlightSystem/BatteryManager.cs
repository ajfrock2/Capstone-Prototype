using UnityEngine;

namespace BenchmarkTasks.FlashlightSystem
{
    /// <summary>
    /// Manages battery level: depletion when flashlight is on, recharge when off.
    /// Exposes level for UI and provides min-level check for turning on.
    /// </summary>
    public class BatteryManager : MonoBehaviour
    {
        [Header("Rates (per second, 0-1 scale)")]
        [SerializeField]
        [Range(0.01f, 0.5f)]
        [Tooltip("Battery drains this much per second when flashlight is on.")]
        private float depletionRate = 0.15f;

        [SerializeField]
        [Range(0.01f, 0.5f)]
        [Tooltip("Battery recharges this much per second when flashlight is off.")]
        private float rechargeRate = 0.1f;

        [Header("Thresholds")]
        [SerializeField]
        [Range(0.01f, 0.5f)]
        [Tooltip("Below this level, low battery warning triggers.")]
        private float lowBatteryThreshold = 0.2f;

        [SerializeField]
        [Range(0.01f, 0.2f)]
        [Tooltip("Flashlight cannot turn on until battery is above this level.")]
        private float minBatteryToTurnOn = 0.05f;

        [Header("State")]
        [SerializeField]
        [Range(0f, 1f)]
        [Tooltip("Starting battery level (0-1).")]
        private float startingBatteryLevel = 1f;

        private float _currentLevel;
        private bool _isFlashlightActive;
        private bool _hasLowBatteryWarned;

        /// <summary>
        /// Current battery level (0-1). Read-only.
        /// </summary>
        public float CurrentLevel => _currentLevel;

        /// <summary>
        /// Whether the battery is high enough to allow turning the flashlight on.
        /// </summary>
        public bool CanTurnOn => _currentLevel > minBatteryToTurnOn;

        private void Awake()
        {
            _currentLevel = Mathf.Clamp01(startingBatteryLevel);
            _hasLowBatteryWarned = _currentLevel <= lowBatteryThreshold;
        }

        private void Update()
        {
            if (_isFlashlightActive)
            {
                _currentLevel -= depletionRate * Time.deltaTime;
                if (_currentLevel <= 0f)
                {
                    _currentLevel = 0f;
                }
            }
            else
            {
                _currentLevel += rechargeRate * Time.deltaTime;
                if (_currentLevel >= 1f)
                {
                    _currentLevel = 1f;
                    _hasLowBatteryWarned = false;
                }
            }

            CheckLowBatteryWarning();
        }

        private void CheckLowBatteryWarning()
        {
            if (_currentLevel <= lowBatteryThreshold && _isFlashlightActive)
            {
                if (!_hasLowBatteryWarned)
                {
                    _hasLowBatteryWarned = true;
                    Debug.Log("Low battery warning");
                }
            }
            else if (_currentLevel > lowBatteryThreshold)
            {
                _hasLowBatteryWarned = false;
            }
        }

        /// <summary>
        /// Call this when the flashlight is toggled on or off.
        /// </summary>
        public void SetFlashlightActive(bool active)
        {
            _isFlashlightActive = active;
        }

        /// <summary>
        /// Returns true if battery has reached zero.
        /// </summary>
        public bool IsEmpty => _currentLevel <= 0f;
    }
}
