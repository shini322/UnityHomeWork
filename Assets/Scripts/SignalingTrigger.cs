using UnityEngine;
using UnityEngine.Events;
public class SignalingTrigger : MonoBehaviour
{
    private UnityEvent<bool> _playerSignalTriggered = new UnityEvent<bool>();
    private bool _isSignalingWork;
    
    public event UnityAction<bool> PlayerSignalTriggered
    {
        add => _playerSignalTriggered.AddListener(value);
        remove => _playerSignalTriggered.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            ChangeSignalingState(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            ChangeSignalingState(false);
        }
    }
    
    private void ChangeSignalingState(bool isSignalingWork)
    {
        _isSignalingWork = isSignalingWork;
        _playerSignalTriggered?.Invoke(_isSignalingWork);
    }
}
