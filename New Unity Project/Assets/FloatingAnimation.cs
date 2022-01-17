using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    [SerializeField] float _amplitude = 1;
    [SerializeField]private float _frequency = 0.1f;
    private bool _startAnimation = false;

    private void OnEnable()
    {
        Invoke(nameof(ActivateAnimation), 1f);
    }
    void Update()
    {
        if (!_startAnimation)
        
            return;
        
        float x = transform.position.x;
        float y = Mathf.Sin(Time.time*_frequency)*_amplitude;
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
        
    }
    private void ActivateAnimation()
    {
        _startAnimation = true;
    }
}
