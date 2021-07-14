using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    //chars trnaform
    [SerializeField] private Transform _player;

 

    // Update is called once per frame
    void Update()
    {
        //lookat char
        transform.LookAt(_player);
    }
}
