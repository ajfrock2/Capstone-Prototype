using UnityEngine;
using UnityEngine.UI;

namespace BenchmarkTasks.FlashlightSystem
{
    /// <summary>
    /// Updates the battery UI (Image fill or Slider) from BatteryManager.
    /// </summary>
    public class FlashlightUI : MonoBehaviour
    {
        [Header("UI References (assign one)")]
        [SerializeField]
        [Tooltip("Image with Image Type set to Filled. Fill Amount = battery level.")]
        private Image batteryFillImage;

        [SerializeField]
        [Tooltip("Slider. Value = battery level (0-1).")]
        private Slider batterySlider;

        [SerializeField]
        [Tooltip("Text showing percentage. Overrides Image/Slider if set.")]
        private Text batteryText;

        [Header("Optional")]
        [SerializeField]
        [Tooltip("BatteryManager to read from. Auto-found if null.")]
        private BatteryManager batteryManager;

        private void Awake()
        {
            if (batteryManager == null)
            {
                batteryManager = FindObjectOfType<BatteryManager>();
            }
        }

        private void Update()
        {
            if (batteryManager == null) return;

            float level = batteryManager.CurrentLevel;

            if (batteryText != null)
            {
                batteryText.text = $"{Mathf.RoundToInt(level * 100)}%";
            }
            else if (batteryFillImage != null)
            {
                batteryFillImage.fillAmount = level;
            }
            else if (batterySlider != null)
            {
                batterySlider.value = level;
            }
        }
    }
}
