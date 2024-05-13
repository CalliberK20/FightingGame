using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionHandler : MonoBehaviour
{
    public Transform target;
    public bool isFlip = false;

    private float sizeX;
    private void Start()
    {
        sizeX = Mathf.Abs(transform.localScale.x);
    }

    // Update is called once per frame
    void Update()
    {
        isFlip = transform.position.x > target.position.x ? true : false;

        if(isFlip)
            transform.localScale = new Vector3(-sizeX, transform.localScale.y, transform.localScale.z);
        else
            transform.localScale = new Vector3(sizeX, transform.localScale.y, transform.localScale.z);
    }
}
