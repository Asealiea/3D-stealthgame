using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{

    [SerializeField] private GameObject _gameOverCutScene;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _gameOverCutScene.SetActive(true);
            AudioManager.Instance.StopMusic();

            GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
            foreach (var guard in guards)
            {
                Animator anim = guard.GetComponent<Animator>();
                anim.SetTrigger("Captured");
            }

        }
    }
}
