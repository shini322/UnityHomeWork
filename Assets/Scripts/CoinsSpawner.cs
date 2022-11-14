using System.Collections;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private int _spawnPeriod;
    [SerializeField] private Coin _coin;

    private Coroutine _spawnCoinsCoroutine;

    private void Start()
    {
        StartSpawn();
    }

    private void OnDestroy()
    {
        StopSpawn();
    }

    private void StartSpawn()
    {
        _spawnCoinsCoroutine = StartCoroutine(Spawn());
    }
    
    private void StopSpawn()
    {
        StopCoroutine(_spawnCoinsCoroutine);
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(_coin, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(_spawnPeriod);
        }
    }
}
