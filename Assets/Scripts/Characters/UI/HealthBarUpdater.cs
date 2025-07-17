using UnityEngine;

public class HealthBarUpdater : MonoBehaviour
{
    [SerializeField] private SliderHandler _sliderHandler;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        _health.Changed += UpdateUI;
        UpdateUI();
    }

    private void OnDestroy()
    {
        _health.Changed -= UpdateUI;
    }

    public void UpdateUI()
    {
        _sliderHandler.UpdateHealthSlider(_health.Current, _health.Max);
    }
}
