using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using HelperFunctions;
using UnityEngine.Events;

public class WeaponsController : MonoBehaviour
{
    public static UnityEvent<float, float> OnChargeChange = new UnityEvent<float, float>();
    public static UnityEvent OnWeaponFired = new UnityEvent();
    public static UnityEvent<Weapon> OnWeaponChange = new UnityEvent<Weapon>();

    [Header("References")]
    public Character Character;

    [Space]
    [SerializeField] Weapon[] _weapons;

    [Header("Aim")]
    [SerializeField] float _rotationSpeed;

    int _activeWeaponIndex = 0;
    bool _canShoot;
    bool _inAimMode = false;
    public float AimDirection;
    bool _hasAttacked = false;
    GameObject _firedProjectile;

    [Header("Charging")]
    [SerializeField] float _maxCharge;
    [SerializeField] float _minCharge;
    [SerializeField] float _chargeRate;
    bool _charging;
    float _currentCharge;

    #region Initialization

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

    void Awake()
    {
        Character = GetComponent<Character>();
    }

    #endregion

    void FixedUpdate()
    {
        if(!Character.IsMyTurn) return;

        AimWeapon(AimDirection);

        if(_charging) Charge();
    }

    void Update()
    {
        if (!Character.IsMyTurn) return;

        CheckIfTurnIsOver();
    }


    #region Weapon Control
    
    /// <summary>
    /// Goes to next character if turn is over.
    /// </summary>
    void CheckIfTurnIsOver()
    {
        if (_firedProjectile || !_hasAttacked) return;

        StartCoroutine(HelpFunctions.InvokeAfterDelay(() => GameController.Instance.NextCharacter(), 1));
        _hasAttacked = false;
    }

    /// <summary>
    /// Switches to the next weapon.
    /// </summary>
    public void SwitchWeapon()
    {
        if(!_inAimMode) return;

        _weapons[_activeWeaponIndex].gameObject.SetActive(false);

        _activeWeaponIndex += 1;
        _activeWeaponIndex = _activeWeaponIndex % _weapons.Length;

        _weapons[_activeWeaponIndex].gameObject.SetActive(true);
        OnWeaponChange?.Invoke(_weapons[_activeWeaponIndex]);
    }

    /// <summary>
    /// Change the aim of the weapon.
    /// </summary>
    /// <param name="direction">the direction to change the aim in.</param>
    void AimWeapon(float direction)
    {
        if(!_inAimMode) return;

        _weapons[_activeWeaponIndex].transform.RotateAround(transform.position, transform.right, _rotationSpeed * direction);
    }

    /// <summary>
    /// Fires the currently selected weapon.
    /// </summary>
    public void Fire(float charge = 0)
    {
        if(!_canShoot) return;

        if(!_inAimMode) return;

        if(_hasAttacked) return;

        _firedProjectile = _weapons[_activeWeaponIndex].Fire(charge);
        _hasAttacked = true;
        OnWeaponFired?.Invoke();
    }

    /// <summary>
    /// Starts charge or fires the weapon depending on weapon type.
    /// </summary>
    public void OnFireButtonDown()
    {
        switch (_weapons[_activeWeaponIndex].Type)
        {
            case Weapon.WeaponType.Default:
                Fire();
                break;

            case Weapon.WeaponType.Charge:
                StartCharge();
                break;
            
            default:
                break;
        }
    }

    /// <summary>
    /// Ends charge if weapon is a charge type weapon.
    /// </summary>
    public void OnFireButtonUp()
    {
        switch (_weapons[_activeWeaponIndex].Type)
        {
            case Weapon.WeaponType.Default:

                break;

            case Weapon.WeaponType.Charge:
                EndCharge();
                break;
            
            default:
                break;
        }
    }

    #endregion

    /// <summary>
    /// Set character active.
    /// </summary>
    void SetActive()
    {
        _canShoot = true;
        _charging = false;
    }

    /// <summary>
    /// Set character inactive.
    /// </summary>
    void SetInactive()
    {
        _canShoot = false;
    }

    /// <summary>
    /// Switch between modes.
    /// </summary>
    /// <param name="mode">the mode to change to.</param>
    public void ModeChange(Character.Mode mode)
    {
        _inAimMode = mode == Character.Mode.Aim;
        _weapons[_activeWeaponIndex].gameObject.SetActive(mode == Character.Mode.Aim && Character.IsMyTurn);
        OnWeaponChange?.Invoke(_weapons[_activeWeaponIndex]);
    }

    #region Charging

    /// <summary>
    /// Start charging a shot.
    /// </summary>
    void StartCharge()
    {
        if(!Character.IsMyTurn) return;

        if(!_inAimMode) return;

        _charging = true;
        _currentCharge = _minCharge;
    }

    /// <summary>
    /// Charge a shot.
    /// </summary>
    void Charge()
    {
        // Debug.Log(Character.CurrentMode);
        if(Character.CurrentMode == Character.Mode.Move)
        {
            _charging = false;
            _currentCharge = 0;
            OnChargeChange?.Invoke(0, 1);
        }

        _currentCharge = Mathf.Min((_currentCharge + _chargeRate * Time.fixedDeltaTime), _maxCharge);
        OnChargeChange?.Invoke(_currentCharge - _minCharge, _maxCharge - _minCharge);
    }

    /// <summary>
    /// Stops charging and fires the weapon with the stored charge.
    /// </summary>
    void EndCharge()
    {
        if(!Character.IsMyTurn) return;

        if(!_charging) return;

        _charging = false;
        var charge = _currentCharge / _maxCharge;
        Fire(charge);
    }

    #endregion
}
