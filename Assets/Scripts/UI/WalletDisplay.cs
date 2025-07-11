using TMPro;
using UnityEngine;

public class WalletDisplay : MonoBehaviour
{
    [SerializeField] private FruitWallet _wallet;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        _wallet.FruitCountChanged += UpdateDisplayCount;
        UpdateDisplayCount(_wallet.GetCurrentCount());
    }

    private void OnDestroy()
    {
        _wallet.FruitCountChanged -= UpdateDisplayCount;
    }

    private void UpdateDisplayCount(int count)
    {
        _text.text = $"Fruit count: {count}";
    }
}
