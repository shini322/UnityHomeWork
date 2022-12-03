using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    public event UnityAction<float> HealthChanged;
    public event UnityAction WasDied;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    private void Die()
    {
        WasDied?.Invoke();
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
        
        HealthChanged?.Invoke(_health);
    }
}
