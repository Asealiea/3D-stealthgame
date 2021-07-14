using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{

    [SerializeField] private GameObject _gameOverCutScene;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameOverCutScene.SetActive(true);
        }
    }
}
