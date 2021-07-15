using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameOver.SetActive(true);
            other.gameObject.SetActive(false);
            GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
            foreach (var guard in guards)
            {
                Animator anim = guard.GetComponent<Animator>();
                anim.SetTrigger("Captured");
            }
        }
    }
}