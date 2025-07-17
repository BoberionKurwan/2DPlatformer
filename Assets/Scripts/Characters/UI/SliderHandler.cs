using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHandler : MonoBehaviour
{
    [SerializeField] private float _smoothSpeed = 0.5f;

    private Slider _slider;
    private Coroutine _coroutine;
    private float _targetValue;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.minValue = 0f;
        _slider.maxValue = 1f;
    }

    public void UpdateHealthSlider(float health, float maxHealth)
    {
        _targetValue = Mathf.Clamp01(health / maxHealth);
        _coroutine = StartCoroutine(SmoothUpdateValue());
    }

    private IEnumerator SmoothUpdateValue()
    {
        while (Mathf.Approximately(_slider.value, _targetValue) == false)
        {
            _slider.value = Mathf.MoveTowards(
                _slider.value,
                _targetValue,
                Time.deltaTime * _smoothSpeed
            );

            yield return null;
        }
    }
}