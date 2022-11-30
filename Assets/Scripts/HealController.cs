using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HealController : MonoBehaviour
{
    [SerializeField] private PlayerHealthController _playerHealthController;
    [SerializeField] private Button _button;
    [SerializeField] private float _heal;

    private event UnityAction _buttonClick
    {
        add => _button.onClick.AddListener(value);
        remove => _button.onClick.RemoveListener(value);
    }

    public float Heal => _heal;

    private void Start()
    {
        _buttonClick += MakeHeal;
    }

    private void OnDestroy()
    {
        _buttonClick -= MakeHeal;
    }

    public void MakeHeal()
    {
        _playerHealthController.MakeHeal(this);
    }
}
