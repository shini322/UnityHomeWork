using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<CoinsManager>(out CoinsManager coinsManager))
        {
            coinsManager.AddCoin();
            Destroy(gameObject);
        }
    }
}
