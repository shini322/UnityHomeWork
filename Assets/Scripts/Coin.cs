using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<CoinsManage>(out CoinsManage coinsManage))
        {
            coinsManage.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
