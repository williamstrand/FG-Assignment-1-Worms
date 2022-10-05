using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] Transform _shootPoint;
    [SerializeField] int _damage;
    [SerializeField] float _knockbackForce;
    [SerializeField] LineRenderer _lineRenderer;

    public override GameObject Fire(float charge)
    {
        var enemyHit = Physics.Raycast(_shootPoint.position, _shootPoint.forward, out var hit, 1000);
        if(enemyHit)
        {
            var positions = new Vector3[] {_shootPoint.position, hit.point};
            _lineRenderer.SetPositions(positions);
            _lineRenderer.enabled = true;
            StartCoroutine(nameof(LineShrink));
        }
        else
        {
            var positions = new Vector3[] {_shootPoint.position, _shootPoint.position + _shootPoint.forward * 1000};
            _lineRenderer.SetPositions(positions);
            _lineRenderer.enabled = true;
            StartCoroutine(nameof(LineShrink));
            return null;
        }

        if(hit.transform.tag != "Player") return null;

        hit.transform.GetComponent<Character>().Damage(_damage, transform.position, _knockbackForce);

        return null;
    }

    /// <summary>
    /// Plays the line shrink animation.
    /// </summary>
    IEnumerator LineShrink()
    {
        yield return new WaitForSeconds(.5f);

        var lerp = 0f;
        while(lerp < 1)
        {
            lerp += Time.fixedDeltaTime * 3;
            _lineRenderer.widthMultiplier = Mathf.Lerp(.2f, 0, lerp);
            yield return null;
        }

        _lineRenderer.enabled = false;
    }
}
