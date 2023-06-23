using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour
{
    private Collider area;

    private void Start()
    {
        area = GetComponent<Collider>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<SpaceShip>())
        {
            Destroy(other.gameObject);
            Debug.Log("exit of area");
        }
        //Debug.Log("exit");
    }
}
