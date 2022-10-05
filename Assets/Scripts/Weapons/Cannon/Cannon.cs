using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Weapon
{
    [SerializeField] CannonProjectile _projectilePrefab;
    [SerializeField] Transform _shootPoint;

    public override GameObject Fire(float charge)
    {
        var projectile = Instantiate(_projectilePrefab, _shootPoint.position, Quaternion.identity);
        projectile.Fire(_shootPoint.up, charge);

        return projectile.gameObject;
    }
}
