using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace HelperFunctions
{
    class HelpFunctions
    {
        public static IEnumerator InvokeAfterDelay(Action method, float time)
        {
            yield return new WaitForSeconds(time);

            method?.Invoke();
        }
    }
}