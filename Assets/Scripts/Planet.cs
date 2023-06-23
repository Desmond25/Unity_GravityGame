using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    //[SerializeField] private float gravConst = 0.667f;
    [SerializeField] private float gravStrength = 150f;
    //[SerializeField] private float maxForce = 100f;

    private HashSet<Rigidbody> affectedBodies = new HashSet<Rigidbody>();
    private Rigidbody componentRigidbody;

    private void Start()
    {
        componentRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            affectedBodies.Add(other.attachedRigidbody);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            affectedBodies.Remove(other.attachedRigidbody);
        }
    }

    private void FixedUpdate()
    {
        foreach (Rigidbody body in affectedBodies)
        {
            if (body)
            {
                Vector3 directionToPlanet = (transform.position - body.position).normalized;

                float distance = (transform.position - body.position).magnitude;
                //float strength = gravConst * body.mass * componentRigidbody.mass / (distance * distance);

                float force = gravStrength * componentRigidbody.mass / (distance * 5f) / 1.5f; //(distance * 2f);
                                                                                               //body.AddForce(directionToPlanet * force);
                body.velocity = directionToPlanet * force;

                //if (force < maxForce) 
                //  body.AddForce(directionToPlanet * force);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>())
        {
            affectedBodies.Remove(collision.gameObject.GetComponent<Rigidbody>());
            Destroy(collision.gameObject);
        }
    }
}
