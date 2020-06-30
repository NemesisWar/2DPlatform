using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishTrigger : MonoBehaviour
{
    [SerializeField] private JaguarTrigger[] _points;

    private void OnEnable()
    {
        _points = GetComponentsInChildren<JaguarTrigger>();
        foreach (var point in _points)
        {
            point.Reached += AllObjectsCollected;
        }
    }

    private void OnDisable()
    {
        foreach (var point in _points)
        {
            point.Reached -= AllObjectsCollected;
        }
    }

    public void AllObjectsCollected()
    {
        foreach (var point in _points)
        {
            if (point.IsReached == false)
                return;

        }
        Debug.Log("Congradulation You Are Alcoholic!");
    }


}
