using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private PlayerHealthController _playerHealthController;
    [SerializeField] private float _damage;

    public float Damage => _damage;

    public void MakeDamage()
    {
        _playerHealthController.GetDamage(this);
    }
}
