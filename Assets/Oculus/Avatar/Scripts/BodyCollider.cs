using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BodyCollider : MonoBehaviour
{
    public OvrAvatar owner = null;
    private Vector3 oldpos = default;
    private Vector3 newpos = default;
    private Rigidbody rigidBody = default;

    private void Start()
    {
        oldpos = transform.position;
        rigidBody = this.GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        newpos = transform.position;
        var media =  (newpos - oldpos);
        rigidBody.velocity = media /Time.deltaTime;
        oldpos = newpos;
        newpos = transform.position;
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag != this.transform.tag)
        {
            owner.TakeDamage(other.relativeVelocity.magnitude/2);
        }

        
    }

    

}
