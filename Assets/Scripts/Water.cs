using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelperFunctions;

public class Water : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.tag != "Player") return;

        col.GetComponent<Character>().Kill();
    }
}
