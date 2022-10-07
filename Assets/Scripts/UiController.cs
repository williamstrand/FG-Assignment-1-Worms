using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UiController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] Slider _movementLeftSlider;

    [Header("Charge Bar")]
    [SerializeField] Slider _chargeSlider;

    [Header("Mode Visual")]
    [SerializeField] Image _aimModeImage;
    [SerializeField] Image _moveModeImage;

    [Header("Current Weapon")]
    [SerializeField] Image _currentWeaponImage;
    [SerializeField] GameObject _currentWeaponVisual;


    void OnEnable()
    {
        Character.OnMovementRemainingChange.AddListener(UpdateMovementLeftBar);
        GameController.OnActiveCharacterChange.AddListener(UpdateActiveCharacter);
        WeaponsController.OnChargeChange.AddListener(UpdateChargeMeter);
        MovementController.OnMove.AddListener(UpdateMovementLeftBar);
        Character.OnModeChange.AddListener(UpdateCurrentModeVisual);
        WeaponsController.OnWeaponChange.AddListener(UpdateActiveWeapon);
        GameController.OnGameOver.AddListener(GameOver);
    }

    void OnDisable()
    {
        Character.OnMovementRemainingChange.RemoveListener(UpdateMovementLeftBar);
        GameController.OnActiveCharacterChange.RemoveListener(UpdateActiveCharacter);
        WeaponsController.OnChargeChange.RemoveListener(UpdateChargeMeter);
        MovementController.OnMove.RemoveListener(UpdateMovementLeftBar);
        Character.OnModeChange.RemoveListener(UpdateCurrentModeVisual);
        WeaponsController.OnWeaponChange.RemoveListener(UpdateActiveWeapon);
        GameController.OnGameOver.RemoveListener(GameOver);

    }

    /// <summary>
    /// Updates all information regarding the current active character.
    /// </summary>
    /// <param name="character">the new active character.</param>
    void UpdateActiveCharacter(Character character)
    {
        UpdateMovementLeftBar(1, 1);
        UpdateChargeMeter(0, 1);
    }

    /// <summary>
    /// Updates the movement left bar.
    /// </summary>
    /// <param name="value">the amount of movement left.</param>
    /// <param name="maxValue">the max amount of movement left.</param>
    void UpdateMovementLeftBar(float value, float maxValue)
    {
        _movementLeftSlider.value = value / maxValue;
    }

    /// <summary>
    /// Updates the charge bar.
    /// </summary>
    /// <param name="charge">the amount of charge.</param>
    /// <param name="maxCharge">the max amount of charge.</param>
    void UpdateChargeMeter(float charge, float maxCharge)
    {
        _chargeSlider.value = charge / maxCharge;
    }

    /// <summary>
    /// Updates all information about the active weapon.
    /// </summary>
    /// <param name="weapon"></param>
    void UpdateActiveWeapon(Weapon weapon)
    {
        switch(weapon.Type)
        {
            case Weapon.WeaponType.Default:
                _chargeSlider.gameObject.SetActive(false);
                break;

            case Weapon.WeaponType.Charge:
                _chargeSlider.gameObject.SetActive(true);
                break;
        }

        _currentWeaponImage.sprite = weapon.WeaponSprite;
    }

    /// <summary>
    /// Updates the current mode visuals.
    /// </summary>
    /// <param name="mode">the current mode.</param>
    void UpdateCurrentModeVisual(Character.Mode mode)
    {
        _aimModeImage.color = new Color(1, 1, 1, .5f);
        _moveModeImage.color = new Color(1, 1, 1, .5f);

        switch(mode)
        {
            case Character.Mode.Aim:
                _aimModeImage.color = new Color(0, 0, 0, 1);
                _currentWeaponVisual.SetActive(true);
                break;

            case Character.Mode.Move:
                _moveModeImage.color = new Color(0, 0, 0, 1);
                _chargeSlider.gameObject.SetActive(false);
                _currentWeaponVisual.SetActive(false);
                break;
        }
    }

    void GameOver(GameController.Team winner)
    {
        DisableUi();
    }

    /// <summary>
    /// Disables the ui.
    /// </summary>
    void DisableUi()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Enables the ui.
    /// </summary>
    void EnableUi()
    {
        gameObject.SetActive(true);
    }
}
