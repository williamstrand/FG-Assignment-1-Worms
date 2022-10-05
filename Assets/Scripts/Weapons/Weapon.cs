using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Sprite WeaponSprite;

    public enum WeaponType
    {
        Default,
        Charge
    }

    public WeaponType Type;

    /// <summary>
    /// Fires the weapon.
    /// </summary>
    /// <param name="charge">the charge of the shot.</param>
    public abstract GameObject Fire(float charge = 0);
}
