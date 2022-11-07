using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    public void SpawnEnemy()
    {
        Instantiate(_enemy, transform.position, Quaternion.identity);
    }
}
