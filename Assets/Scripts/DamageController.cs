using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DamageController : MonoBehaviour
{
    [SerializeField] private PlayerHealthController _playerHealthController;
    [SerializeField] private Button _button;
    [SerializeField] private float _damage;
    
    private event UnityAction _buttonClick
    {
        add => _button.onClick.AddListener(value);
        remove => _button.onClick.RemoveListener(value);
    }

    public float Damage => _damage;
    
    private void Start()
    {
        _buttonClick += MakeDamage;
    }
    
    private void OnDestroy()
    {
        _buttonClick -= MakeDamage;
    }

    public void MakeDamage()
    {
        _playerHealthController.MakeDamage(this);
    }
}
