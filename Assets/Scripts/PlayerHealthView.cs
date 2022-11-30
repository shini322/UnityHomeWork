using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
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

    private void OnDestroy()
    {
        _playerHealthController.HealthWasChanged -= StartChangeHealth;
    }

    private IEnumerator ChangeHealth(float health)
    {
        while (_slider.value != health)
        {
            Debug.Log(_speedChange * Time.deltaTime);
            _slider.value = Mathf.MoveTowards(_slider.value, health, _speedChange * Time.deltaTime);
            yield return null;
        }
    }

    private void StartChangeHealth(float health)
    {
        if (_changeHealthCoroutine != null)
        {
            StopCoroutine(_changeHealthCoroutine);
        }

        _changeHealthCoroutine = StartCoroutine(ChangeHealth(health));
    }
}
