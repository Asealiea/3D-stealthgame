using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private Animator _anim;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MeshRenderer render = GetComponent<MeshRenderer>();
            Color colour = new Color(0.6f, 0.1f, 0.1f, 0.3f);
            render.material.SetColor("_TintColor", colour);
           
            _anim.enabled = false;
            StartCoroutine(Caught());

           
            // turn off the animator on the camera
           
            //change color tink to red

          /*  GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
            foreach (var guard in guards)
            {
                Animator anim = guard.GetComponent<Animator>();
                anim.SetTrigger("Captured");
            } */
        }
    }

    IEnumerator Caught()
    {
        yield return new WaitForSeconds(0.5f);
        _gameOver.SetActive(true);
        AudioManager.Instance.StopMusic();
    }
}