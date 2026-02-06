using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays battery level on a UI fill image or slider. Assign in Inspector.
/// </summary>
public class FlashlightUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    [Tooltip("Image with Image Type = Filled to show battery bar. Optional.")]
    private Image _batteryFillImage;

    [SerializeField]
    [Tooltip("Text to show battery percentage. Optional.")]
    private Text _batteryText;

    [SerializeField]
    [Tooltip("FlashlightController or object with FlashlightBattery. Will use FindObjectOfType if not set.")]
    private FlashlightBattery _battery;

    private void Awake()
    {
        if (_battery == null)
        {
            var controller = FindObjectOfType<FlashlightController>();
            if (controller != null)
                _battery = controller.GetComponent<FlashlightBattery>();
        }
    }

    private void Update()
    {
        if (_battery == null)
            return;

        float percent = _battery.CurrentBatteryPercent / 100f;

        if (_batteryFillImage != null && _batteryFillImage.type == Image.Type.Filled)
            _batteryFillImage.fillAmount = percent;

        if (_batteryText != null)
            _batteryText.text = $"{Mathf.RoundToInt(_battery.CurrentBatteryPercent)}%";
    }
}
