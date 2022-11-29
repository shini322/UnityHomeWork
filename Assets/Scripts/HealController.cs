using UnityEngine;

public class HealController : MonoBehaviour
{
    [SerializeField] private PlayerHealthController _playerHealthController;
    [SerializeField] private float _heal;

    public float Heal => _heal;

    public void MakeHeal()
    {
        _playerHealthController.GetHeal(this);
    }
}
