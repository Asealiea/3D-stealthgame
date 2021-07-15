using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverTrigger : MonoBehaviour
{

    [SerializeField] private AudioClip _clip;
    private bool _played;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& !_played)
        {
            //play audio clip at point
            AudioSource.PlayClipAtPoint(_clip, transform.position);
            _played = true;
        }
    }
}
