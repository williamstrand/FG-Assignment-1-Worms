using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectile : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField] float _force;
    [SerializeField] ParticleSystem _explosionEffect;
    [SerializeField] LayerMask _characterLayer;
    [SerializeField] float _explosionRadius;
    [SerializeField] float _maxKnockbackForce;
    [SerializeField] int _maxDamage;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Fires the projectile.
    /// </summary>
    /// <param name="direction">the direction to fire the projectile in.</param>
    /// <param name="charge">the charge of the shot.</param>
    public void Fire(Vector3 direction, float charge)
    {
        _rigidbody.AddForce(direction * _force * charge, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision col)
    {
        gameObject.SetActive(false);
        var explosion = Instantiate(_explosionEffect, transform.position, Quaternion.identity);

        var hit = Physics.OverlapSphere(transform.position, _explosionRadius, _characterLayer);

        foreach (Collider character in hit)
        {
            var distanceMultiplier = 1 - Vector3.Distance(character.transform.position, transform.position) / _explosionRadius;
            character.GetComponent<Character>().Damage((int)(_maxDamage * distanceMultiplier), transform.position, _maxKnockbackForce * distanceMultiplier);
        }

        Destroy(gameObject);
    }
}
