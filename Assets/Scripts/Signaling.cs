using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    [SerializeField] private SignalingTrigger _signalingTrigger;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Color _standardColor;
    [SerializeField] private Color _signalingColor;
    [SerializeField] private float _speedChange;
    
    private const float MaxSignalingValue = 1;
    private const float MinSignalingValue = 0;
    private const float VolumeValueMultiply = 0.5f;

    private SpriteRenderer _spriteRenderer;
    private float _signalingPower;
    private Coroutine _changeSignalingPowerCoroutine;

    private void OnEnable()
    {
        _signalingTrigger.PlayerSignalTriggered += OnChangeSignalingState;
    }
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer.color = _standardColor;
    }

    private void OnDisable()
    {
        _signalingTrigger.PlayerSignalTriggered -= OnChangeSignalingState;
        StopAllCoroutines();
    }

    private void OnChangeSignalingState(bool isSignalingWork)
    {
        if (_changeSignalingPowerCoroutine != null)
        {
            StopCoroutine(_changeSignalingPowerCoroutine);
        }

        float moveTowardsTarget = isSignalingWork ? MaxSignalingValue : MinSignalingValue;
        _changeSignalingPowerCoroutine = StartCoroutine(ChangeSignalingPower(moveTowardsTarget));
    }

    private void ChangeAudioPower()
    {
        _audioSource.volume = _signalingPower * VolumeValueMultiply;
    
        if (!_audioSource.isPlaying && _signalingPower > 0)
        {
            _audioSource.Play();
        }
    
        if (_audioSource.isPlaying && _signalingPower <= 0)
        {
            _audioSource.Stop();
        }
    }

    private void ChangeColor()
    {
        _spriteRenderer.color = Color.Lerp(_standardColor, _signalingColor, _signalingPower);
    }

    private IEnumerator ChangeSignalingPower(float target)
    {
        while (_signalingPower != target)
        {
            _signalingPower = Mathf.MoveTowards(_signalingPower, target, _speedChange * Time.deltaTime);
            ChangeAudioPower();
            ChangeColor();
            yield return null;
        }
    }
}
