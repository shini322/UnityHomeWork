using TMPro;
using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _player.HealthChanged += OnPlayerHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnPlayerHealthChanged;
    }

    private void OnPlayerHealthChanged(float _health)
    {
        _text.text = _health.ToString();
    }
}
