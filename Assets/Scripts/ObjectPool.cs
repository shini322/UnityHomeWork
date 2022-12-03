using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int _containerSize;

    private List<GameObject> _gameObjects = new List<GameObject>();

    protected void Init(GameObject prefab)
    {
        for (int i = 0; i < _containerSize; i++)
        {
            GameObject createdPrefab = Instantiate(prefab, transform);
            createdPrefab.SetActive(false);
            _gameObjects.Add(createdPrefab);
        }
    }

    protected bool TryGetActiveGameObject(out GameObject gameObject)
    {
        gameObject = _gameObjects.FirstOrDefault(gameObject => !gameObject.activeSelf);
        return gameObject != null;
    }
}
