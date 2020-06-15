using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeJaguar : MonoBehaviour
{
    public void DestroyBank()
    {
        Destroy(gameObject, 0.5f);
    }
}
