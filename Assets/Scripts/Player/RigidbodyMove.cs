using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMove : MonoBehaviour
{
    private const string Run = "Run";
    private const string Speed = "PlayerSpeed";

    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _speed = 5f;
    [SerializeField] private Transform _rotationPoint;
    [SerializeField] private float _smoothness = 10f;
    [SerializeField] private AnimationCurve _curve;


    private Rigidbody _rigidbody;
    private Player _player;

    private Vector2 _moveInput;

    private bool _isActionState;
    private bool _wasPressed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _moveInput = _joystick.Value;

        if (_rigidbody.velocity != Vector3.zero)
        {
            _rotationPoint.rotation = Quaternion.Lerp(_rotationPoint.rotation, Quaternion.LookRotation(_rigidbody.velocity, Vector3.up), _smoothness * Time.deltaTime);
        }

        Keyframe keyframe = new Keyframe(Time.time, _rotationPoint.eulerAngles.y);
        _curve.AddKey(keyframe);

        if (_isActionState)
        {
            if (_wasPressed != _joystick.IsPressed)
            {
                _animator.SetBool(Run, _joystick.IsPressed);
                _wasPressed = _joystick.IsPressed;
            }
        }
        else
        {
            _animator.SetBool(Run, false);
        }
    }

    private void FixedUpdate()
    {
        if (_isActionState)
        {
            _rigidbody.velocity = new Vector3(_moveInput.x, 0f, _moveInput.y) * _speed * _player.SpeedMultiplier;
        }

        Vector3 localVelocity = transform.InverseTransformVector(_rigidbody.velocity);
        float speed = localVelocity.magnitude / _speed;

        _animator.SetFloat(Speed, speed * _player.SpeedMultiplier);
    }

    public void SetActionStateAvailability(bool isActionState)
    {
        _isActionState = isActionState;

        if (isActionState)
        {
            _wasPressed = false;
        }
    }
}
