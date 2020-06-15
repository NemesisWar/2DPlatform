using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JaguarTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _unityEvent = new UnityEvent();
    [SerializeField] public bool IsReached { get; private set; }

    public event UnityAction Reached
    {
        add => _unityEvent.AddListener(value);
        remove => _unityEvent.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsReached)
            return;

        if (collision.gameObject.GetComponent<Player>())
        {
            IsReached = true;
            _unityEvent.Invoke();
        }
    }
}
