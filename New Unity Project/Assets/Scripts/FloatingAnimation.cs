using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    float _amplitude = 0.4f;
    private float _frequency = 3f;
    private bool _startAnimation = false;
    private float rotationSpeed = 10f;
    private Vector3 rotationAngle = new Vector3(0, 10, 0);

    private void OnEnable()
    {
        //Invoke(nameof(ActivateAnimation), 1f);
    }
    void Update()
    {
        /*if (!_startAnimation)
        
           return;*/
        /* 
         float x = transform.position.x;
         float y = Mathf.Sin((transform.position.y+Time.time)*_frequency)*_amplitude;
         float z = transform.position.z;
         transform.position = new Vector3(x, y, z);*/
        transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);

    }
    private void ActivateAnimation()
    {
        _startAnimation = true;
    }
}
