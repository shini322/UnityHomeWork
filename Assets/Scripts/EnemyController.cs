using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _waitSeconds;
    [SerializeField] private Transform[] _wayPoints;

    private Coroutine _patrolCoroutine;

    private void Start()
    {
        _patrolCoroutine = StartCoroutine(PatrolChangeWayPont());
    }

    private void OnDestroy()
    {
        StopCoroutine(_patrolCoroutine);
    }

    private IEnumerator PatrolMovement(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
            yield return null;
        }
        
        yield return new WaitForSeconds(_waitSeconds);
    }

    private IEnumerator PatrolChangeWayPont()
    {
        for (int i = 0; i < _wayPoints.Length; i++)
        {
            int pointIndex = i;

            if (i == _wayPoints.Length - 1)
            {
                i = -1;
            }

            yield return StartCoroutine(PatrolMovement(_wayPoints[pointIndex].position));
        }
    }
}