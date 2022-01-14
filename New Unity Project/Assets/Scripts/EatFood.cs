using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    private bool _canEat = default;
    public bool CanEat { get { return _canEat; } }
    private void OnEnable()
    {
        _canEat = true;
    }
    private void OnDisable()
    {
        _canEat = false;
    }
}
