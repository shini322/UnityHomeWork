using System.Collections;
using UnityEngine;
using Random = System.Random;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private Transform[] _spawnerPoints;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _timeOutSpawn;

    private Random _random = new Random();
    private WaitForSeconds _waitForSeconds;
    private Coroutine _spawnCoroutine;
    
    private void Start()
    {
        Debug.DebugBreak();
        Init(_prefab);
        _waitForSeconds = new WaitForSeconds(_timeOutSpawn);
        _spawnCoroutine = StartCoroutine(SpawnEnemy());
    }

    private void OnDestroy()
    {
        StopCoroutine(_spawnCoroutine);
    }

    private Transform GetRandomSpawnPoint()
    {
        int randomIndex = _random.Next(0, _spawnerPoints.Length);
        return _spawnerPoints[randomIndex];
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (TryGetActiveGameObject(out GameObject enemy))
            {
                enemy.transform.position = GetRandomSpawnPoint().transform.position;
                enemy.SetActive(true);
            }

            yield return _waitForSeconds;
        }
    }
}
