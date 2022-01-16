using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float yValue = 0.02f;
    [SerializeField] float speedAmt;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!GameManager.canPlay)
        {
            return;
        }

        float xValue = Input.GetAxisRaw("Horizontal")*Time.deltaTime*speedAmt;
        float zValue = Input.GetAxisRaw("Vertical")*Time.deltaTime*speedAmt;

        Vector3 direction = new Vector3(xValue, yValue, zValue);
        //transform.Translate(xValue, yValue, zValue);
        if(xValue!=0 || zValue != 0)
        {
            //rb.MovePosition(rb.position+direction);
            rb.drag = 0;
            rb.AddForce(direction);
        }
        else
        {
            rb.drag = 10f;
        }
        

    }
}
