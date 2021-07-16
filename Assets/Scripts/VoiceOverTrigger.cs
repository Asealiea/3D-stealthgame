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
            AudioManager.Instance.PlayVoiceOver(_clip); 
           // AudioSource.PlayClipAtPoint(_clip, transform.position);
            _played = true;
        }
    }
}
