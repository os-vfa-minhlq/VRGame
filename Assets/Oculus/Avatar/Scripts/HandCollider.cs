using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollider : MonoBehaviour
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
        if(other.gameObject.GetComponent<HandCollider>() != null)
        {
            Debug.Log(this.transform.tag + " something hit hand");
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            oldpos = newpos = transform.position;
        }
    }

}
