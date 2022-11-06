using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
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
    private bool _isSignalingWork;
    private float _signalingPower;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer.color = _standardColor;
    }

    private void OnEnable()
    {
        _signalingTrigger.PlayerSignalTriggered += OnChangeSignalingState;
    }

    public void Update()
    {
        ChangeSignalingPower();
        ChangeAudioPower();
        ChangeColor();
    }

    private void OnDisable()
    {
        _signalingTrigger.PlayerSignalTriggered -= OnChangeSignalingState;
    }

    private void OnChangeSignalingState(bool isSignalingWork)
    {
        _isSignalingWork = isSignalingWork;
    }

    private void ChangeSignalingPower()
    {
        if (_isSignalingWork && _signalingPower < MaxSignalingValue)
        {
            _signalingPower = Mathf.MoveTowards(_signalingPower, MaxSignalingValue, _speedChange * Time.deltaTime);
        }
        if(!_isSignalingWork && _signalingPower > MinSignalingValue)
        {
            _signalingPower = Mathf.MoveTowards(_signalingPower, MinSignalingValue, _speedChange * Time.deltaTime);
        }
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
}
