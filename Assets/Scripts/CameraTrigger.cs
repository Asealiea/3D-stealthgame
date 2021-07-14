using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{

    [SerializeField] private Transform _cameras;

    //check for trigger of player
    //update main camera to apporiate angle

    //check trigger
    //debug.log trigger activted
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Camera.main.transform.position = _cameras.position;
            Camera.main.transform.rotation = _cameras.rotation;
        }
    }
}
