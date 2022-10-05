using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation * Quaternion.Euler(0, _rotationSpeed, 0), Time.fixedDeltaTime);
    }
}
