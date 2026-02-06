using UnityEngine;

namespace BenchmarkTasks.FlashlightSystem
{
    /// <summary>
    /// Handles F key input, toggles flashlight light, and triggers audio/Debug.Log feedback.
    /// Coordinates with BatteryManager for min-level check and auto-off.
    /// </summary>
    [RequireComponent(typeof(Light))]
    [RequireComponent(typeof(AudioSource))]
    public class FlashlightController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        [Tooltip("The light component to toggle. Auto-assigned if null.")]
        private Light flashlightLight;

        [SerializeField]
        [Tooltip("AudioSource for on/off sounds. Auto-assigned if null.")]
        private AudioSource audioSource;

        [SerializeField]
        [Tooltip("Battery manager. Auto-assigned if null.")]
        private BatteryManager batteryManager;

        [Header("Optional Audio Clips (Debug.Log if null)")]
        [SerializeField]
        [Tooltip("Sound when flashlight turns on.")]
        private AudioClip onClip;

        [SerializeField]
        [Tooltip("Sound when flashlight turns off.")]
        private AudioClip offClip;

        private bool _isOn;

        private void Awake()
        {
            if (flashlightLight == null) flashlightLight = GetComponent<Light>();
            if (audioSource == null) audioSource = GetComponent<AudioSource>();
            if (batteryManager == null) batteryManager = GetComponent<BatteryManager>();

            _isOn = false;
            if (flashlightLight != null)
            {
                flashlightLight.enabled = false;
            }
            if (batteryManager != null)
            {
                batteryManager.SetFlashlightActive(false);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                TryToggle();
            }

            if (_isOn && batteryManager != null && batteryManager.IsEmpty)
            {
                TurnOff();
            }
        }

        private void TryToggle()
        {
            if (_isOn)
            {
                TurnOff();
            }
            else
            {
                if (batteryManager != null && !batteryManager.CanTurnOn)
                {
                    return;
                }
                TurnOn();
            }
        }

        private void TurnOn()
        {
            _isOn = true;
            if (flashlightLight != null) flashlightLight.enabled = true;
            if (batteryManager != null) batteryManager.SetFlashlightActive(true);

            if (audioSource != null && onClip != null)
            {
                audioSource.PlayOneShot(onClip);
            }
            else
            {
                Debug.Log("Flashlight turned on");
            }
        }

        private void TurnOff()
        {
            _isOn = false;
            if (flashlightLight != null) flashlightLight.enabled = false;
            if (batteryManager != null) batteryManager.SetFlashlightActive(false);

            if (audioSource != null && offClip != null)
            {
                audioSource.PlayOneShot(offClip);
            }
            else
            {
                Debug.Log("Flashlight turned off");
            }
        }
    }
}
