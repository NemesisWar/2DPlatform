using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePhysicsPlatform : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider2DParent;

    private void Awake()
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            _boxCollider2DParent.isTrigger = false;
        }
    }
}
