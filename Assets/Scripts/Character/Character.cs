using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public static UnityEvent<Mode> OnModeChange = new UnityEvent<Mode>();
    public static UnityEvent<float, float> OnMovementRemainingChange = new UnityEvent<float, float>();
    public static UnityEvent<Character> OnDeath = new UnityEvent<Character>();

    [HideInInspector]public UnityEvent OnSetActive = new UnityEvent();
    [HideInInspector]public UnityEvent OnSetInactive = new UnityEvent();
    
    [Header("UI Elements")]
    [SerializeField] Canvas _canvas;
    [SerializeField] TextMeshProUGUI _nameUi;
    [SerializeField] Slider _hpSlider;

    public enum Mode
    {
        Move,
        Aim
    }

    [Space]
    public Mode CurrentMode;
    public bool IsDead;

    Controls _controls;
    Rigidbody _rigidbody;

    public GameController.Team Team;
    public bool IsMyTurn = false;

    MovementController _movementController;
    WeaponsController _weaponsController;

    [Space]
    [SerializeField] int _maxHp;
    int _currentHp;

    #region Initialization

    void Awake()
    {
        _movementController = GetComponent<MovementController>();
        _weaponsController = GetComponent<WeaponsController>();
        _rigidbody = GetComponent<Rigidbody>();

        InitControls();
    }

    void OnEnable()
    {
        WeaponsController.OnWeaponFired.AddListener(OnWeaponFired);
    }

    void OnDisable()
    {
        WeaponsController.OnWeaponFired.RemoveListener(OnWeaponFired);
    }

    /// <summary>
    /// Initializes the controls.
    /// </summary>
    void InitControls()
    {
        _controls = new Controls();

        _controls.Game.ModeChange.performed += _ => SetMode((Mode)(((int)CurrentMode + 1) % 2));
        _controls.Game.EndTurn.performed += _ => GameController.Instance.NextCharacter();

        _controls.Game.Move.performed += direction => _movementController.InputDirection = direction.ReadValue<Vector2>();
        _controls.Game.Jump.performed += _ => _movementController.Jump();

        _controls.Game.FireDown.performed += _ => _weaponsController.OnFireButtonDown();
        _controls.Game.FireUp.performed   += _ => _weaponsController.OnFireButtonUp();
        _controls.Game.Move.performed += direction => _weaponsController.AimDirection = direction.ReadValue<Vector2>().y;
        _controls.Game.SwitchWeapon.performed += _ => _weaponsController.SwitchWeapon();

        _controls.Enable();
    }

    void Start()
    {
        _currentHp = _maxHp;
        _nameUi.text = name;
        _hpSlider.value = 1;
        IsDead = false;
    }

    #endregion

    void LateUpdate()
    {
        _canvas.transform.LookAt(Camera.main.transform, Vector3.up);
    }

    /// <summary>
    /// Set character active.
    /// </summary>
    public void SetActive()
    {
        IsMyTurn = true;
        SetMode(Mode.Move);
        _controls.Enable();
        _canvas.enabled = false;
        OnSetActive?.Invoke();
    }

    /// <summary>
    /// Set character inactive.
    /// </summary>
    public void SetInactive()
    {
        IsMyTurn = false;
        _controls.Disable();
        _canvas.enabled = true;
        SetMode(Mode.Move);
        OnSetInactive?.Invoke();
    }

    #region Mode Change


    /// <summary>
    /// Set the mode.
    /// </summary>
    /// <param name="mode">the mode to change to.</param>
    void SetMode(Mode mode)
    {
        CurrentMode = mode;
        _movementController.ModeChange(mode);
        _weaponsController.ModeChange(mode);
        OnModeChange?.Invoke(mode); 
    }

    void OnWeaponFired()
    {
        _controls.Disable();
    }

    #endregion

    #region Taking Damage

    /// <summary>
    /// Damage the character.
    /// </summary>
    /// <param name="damage">the amount of damage.</param>
    /// <param name="origin">the origin of the damage.</param>
    /// <param name="knockbackForce">the force of the knockback.</param>
    public void Damage(int damage, Vector3 origin, float knockbackForce)
    {
        _currentHp -= damage;

        _hpSlider.value = (float)_currentHp / (float)_maxHp;

        if(_currentHp <= 0)
        {
            Kill();
        }

        var knockbackDirection = (transform.position - origin).normalized;

        _rigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
    }

    /// <summary>
    /// Kills the character.
    /// </summary>
    public void Kill()
    {
        gameObject.SetActive(false);
        _controls.Disable();
        IsDead = true;

        OnDeath?.Invoke(this);
    }

    #endregion
}
