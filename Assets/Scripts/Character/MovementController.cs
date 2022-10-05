using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementController : MonoBehaviour
{
    public static UnityEvent<float, float> OnMove = new UnityEvent<float, float>();

    [Header("References")]
    public Character Character;
    Rigidbody _rigidbody;

    [Header("Movement Parameters")]
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;
    [SerializeField] float _turnSpeed;
    [SerializeField] float _maxMoveDistance;
    Vector2 _lastPosition;
    public Vector2 InputDirection;
    bool _canMove;
    bool _movementDepleted;
    float _movementRemaining;

    [Header("Ground Check")]
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] Transform _groundCheck;

    #region Initialization

    void Awake()
    {
        Character = GetComponent<Character>();
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _movementRemaining = _maxMoveDistance;
    }

    void OnEnable()
    {
        Character.OnSetActive.AddListener(SetActive);
        Character.OnSetInactive.AddListener(SetInactive);
    }

    void OnDisable()
    {
        Character.OnSetActive.RemoveListener(SetActive);
        Character.OnSetInactive.RemoveListener(SetInactive);
    }

    #endregion

    void FixedUpdate()
    {
        if(!Character.IsMyTurn) return;

        Move(InputDirection.y);
        Rotate(InputDirection.x);
    }

    void Update()
    {
        if (!Character.IsMyTurn) return;

        CalculateDistanceMoved();
    }


    #region Movement
    
    /// <summary>
    /// Calculates the distance moved since the last time this method was called.
    /// </summary>
    void CalculateDistanceMoved()
    {
        if (_rigidbody.velocity.x == 0 && _rigidbody.velocity.z == 0) return;

        var distanceMoved = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), _lastPosition);
        _lastPosition = new Vector2(transform.position.x, transform.position.z);

        _movementRemaining -= distanceMoved;

        if (_movementRemaining <= 0)
        {
            _movementDepleted = true;
        }
        OnMove?.Invoke(_movementRemaining, _maxMoveDistance);
    }

    /// <summary>
    /// Moves the character in a direction.
    /// </summary>
    /// <param name="direction">the direction to move in.</param>
    void Move(float direction)
    {
        if(direction == 0) return;

        if(!_canMove) return;

        if(_movementDepleted) return;

        if(!IsGrounded()) return;

        _rigidbody.velocity = new Vector3(transform.forward.x * direction * _speed, _rigidbody.velocity.y, transform.forward.z * direction * _speed);
    }

    /// <summary>
    /// Rotate the character in a direction.
    /// </summary>
    /// <param name="direction">the direction to rotate in.</param>
    void Rotate(float direction)
    {
        if(!IsGrounded()) return;

        _rigidbody.rotation = Quaternion.LerpUnclamped(_rigidbody.rotation, _rigidbody.rotation * Quaternion.Euler(0, direction * _turnSpeed, 0), Time.fixedDeltaTime);
    }

    /// <summary>
    /// Makes the player jump.
    /// </summary>
    public void Jump()
    {
        if(!_canMove) return;

        if(_movementDepleted) return;

        if(!IsGrounded()) return;

        if(!Character.IsMyTurn) return;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.velocity = new Vector3(transform.forward.x * InputDirection.x, _jumpForce, transform.forward.z * InputDirection.y);
    }

    /// <summary>
    /// Checks if character is on the ground.
    /// </summary>
    /// <returns>a bool representing whether the character is grounded.</returns>
    public bool IsGrounded()
    {
        var ray = Physics.CheckSphere(_groundCheck.position, .4f, _groundLayer);
        return ray;
    }

    #endregion

    #region Event Methods

    /// <summary>
    /// Sets the character as active.
    /// </summary>
    void SetActive()
    {
        _canMove = true;
        _lastPosition = new Vector2(transform.position.x, transform.position.z);
        _movementRemaining = _maxMoveDistance;
        _movementDepleted = false;
    }

    /// <summary>
    /// Sets the character as inactive.
    /// </summary>
    void SetInactive()
    {
        _canMove = false;
    }

    /// <summary>
    /// Change mode.
    /// </summary>
    /// <param name="mode">the mode to change to.</param>
    public void ModeChange(Character.Mode mode)
    {
        _canMove = mode == Character.Mode.Move;
    }

    #endregion
}
