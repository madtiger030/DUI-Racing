using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private bool LeftRight = true;
    [SerializeField] private bool BackForth = false;
    [SerializeField] private bool UpDown = false;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float distance = 2.0f;
    Vector3 newPosition;
    private Vector3 startPosition; 
    void Start()
    {


        startPosition = gameObject.transform.position;
        Debug.Log(startPosition);
    }

    void Update()
    {
       
        float delta = Mathf.PingPong(Time.time * speed, distance);

        if(LeftRight == true)
        {
            newPosition = startPosition + Vector3.right * delta;
        }
        if(BackForth == true)
        {
            newPosition = startPosition + Vector3.forward * delta;
        }
        if (UpDown == true)
        {
           newPosition = startPosition + Vector3.up * delta;
        }
       

        if (newPosition != null)
        {
            transform.position = newPosition;
        }
        
    }
}
