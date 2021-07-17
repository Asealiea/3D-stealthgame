using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarrenSteps : MonoBehaviour
{

    [SerializeField] private AudioClip _typeOfSteps;




    public void SoftWalk()
    {
        AudioManager.Instance.PlaySfx(_typeOfSteps);
    }

    public void UpdateSteps(AudioClip ClipSteps)
    {
        _typeOfSteps = ClipSteps;
    }


}
