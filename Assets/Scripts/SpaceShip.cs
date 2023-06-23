using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotateSpeed = 2f;

    private void Update()
    {
        // Move up and down
        Vector3 moveDir = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            moveDir = transform.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir = -transform.up;
        }

        transform.localPosition += moveDir * moveSpeed * Time.deltaTime;

        // Rotate (left and right)

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, rotateSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -rotateSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MeshCollider>())
        {
            Destroy(transform.gameObject);
        }
    }
}
