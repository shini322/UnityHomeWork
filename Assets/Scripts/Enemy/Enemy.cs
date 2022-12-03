using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damage; 
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            player.ApplyDamage(_damage);
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
