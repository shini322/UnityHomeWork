using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private bool isDead = false;
    private UnityEvent<float> _healthWasChanged = new UnityEvent<float>();

    public float MaxHealth => _maxHealth;
    public float Health { get; private set; }

    public event UnityAction<float> HealthWasChanged
    {
        add => _healthWasChanged.AddListener(value);
        remove => _healthWasChanged.RemoveListener(value);
    }

    public void Awake()
    {
        Health = MaxHealth;
    }

    public void GetDamage(DamageController damageController)
    {
        if (isDead)
        {
            return;
        }

        float calculatedHealth = damageController.Damage > Health ? 0 : Health - damageController.Damage;
        Health = calculatedHealth;

        if (Health == 0)
        {
            isDead = true;
        }
        
        _healthWasChanged.Invoke(Health);
    }

    public void GetHeal(HealController healController)
    {
        if (isDead)
        {
            return;
        }

        float healedHealth = healController.Heal + Health;
        float calculatedHealth = healedHealth > MaxHealth ? MaxHealth : healedHealth;

        if (calculatedHealth != Health)
        {
            Health = calculatedHealth;
            _healthWasChanged.Invoke(Health);
        }
    }
}
