using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] private JaguarTrigger[] _points;

    private void OnEnable()
    {
        _points = GetComponentsInChildren<JaguarTrigger>();
        foreach(var point in _points)
        {
            point.Reached += AllPontsReached;
        }
    }

    private void OnDisable()
    {
        foreach (var point in _points)
        {
            point.Reached -= AllPontsReached;
        }
    }

    public void AllPontsReached()
    {
        foreach (var point in _points)
        {
            if (point.IsReached == false)
                return;

        }
        Debug.Log("Congradulation You Are Alcoholic!");
    }


}
