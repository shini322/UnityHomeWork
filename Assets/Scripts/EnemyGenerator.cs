using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _timeInterval;
    
    private EnemySpawner[] _enemySpawners;

    private void Start()
    {
        _enemySpawners = GetComponentsInChildren<EnemySpawner>();
        StartCoroutine(SpawnEnemy());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < _enemySpawners.Length; i++)
        {
            _enemySpawners[i].SpawnEnemy();
            
            if (i == _enemySpawners.Length - 1)
            {
                i = -1;
            }
        
            yield return new WaitForSeconds(_timeInterval);
        }
    }
}
