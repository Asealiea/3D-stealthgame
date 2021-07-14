using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    //chars trnaform
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _startCamera;

    private void Start()
    {
        transform.position = _startCamera.position;
        transform.rotation = _startCamera.rotation;
    }



    // Update is called once per frame
    void Update()
    {
        //lookat char
        transform.LookAt(_player);
    }
}
