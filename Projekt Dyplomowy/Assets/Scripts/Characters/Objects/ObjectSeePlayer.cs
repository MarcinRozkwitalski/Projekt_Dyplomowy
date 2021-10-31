using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSeePlayer : MonoBehaviour
{

   public bool youCanUseMe = true;

    public void useObject()
    {
        youCanUseMe = false;
    }
}
