using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private PlayerHealthController _playerHealthController;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speedChange;

    private Coroutine _changeHealthCoroutine;
    
    private void Start()
    {
        _playerHealthController.HealthWasChanged += StartChangeHealth;
        _slider.value = _playerHealthController.Health;
        _slider.maxValue = _playerHealthController.MaxHealth;
    }

    private IEnumerator ChangeHealth(float health)
    {
        if (_changeHealthCoroutine != null)
        {
            StopCoroutine(_changeHealthCoroutine);
        }
        
        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _speedChange);
            yield return null;
        }
    }

    private void StartChangeHealth(float health)
    {
        _changeHealthCoroutine = StartCoroutine(ChangeHealth(health));
    }
}
