using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    public Vector3? Destination = null;
    private float Speed = 10;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = 0;
        rb.isKinematic = true;
        rb.mass = 1;
    }
    private void Update()
    {
        if (Destination == null) return;
        else
        {
            Vector3 dest = Destination.Value;
            dest = new Vector3(dest.x, 0, dest.z);
            Debug.DrawLine(transform.position, dest);

            float distanceToDestination = Vector3.Distance(transform.position, dest);
            if (distanceToDestination <= 0.75f)
            {
                Destroy(gameObject, 1f);
            }
            else
            {
                Vector3 targetDir = dest - transform.position;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, transform.up, Time.deltaTime * Speed, 0.0f);
                //transform.rotation = Quaternion.LookRotation(newDir);
                transform.position = Vector3.MoveTowards(transform.position, dest, Time.deltaTime * Speed);
                //rb.MovePosition(transform.position + transform.up * Time.fixedDeltaTime * Speed);
                //rb.velocity = transform.up * distanceToDestination * Speed;
            }
            
            
        }
    }

}
