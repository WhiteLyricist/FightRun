using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public static Action Won = delegate { };

    private void OnDestroy()
    {
        Won();
    }

}
