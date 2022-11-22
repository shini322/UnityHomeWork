using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _waitSeconds;
    [SerializeField] private Transform[] _wayPoints;

    private const float MinTargetDistance = 0.001f;
    
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
        WaitForSeconds _waitForSeconds = new WaitForSeconds(_waitSeconds);

        while (Vector3.Distance(transform.position, targetPosition) > MinTargetDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
            yield return null;
        }

        yield return _waitForSeconds;
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