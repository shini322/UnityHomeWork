using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            playerController.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
