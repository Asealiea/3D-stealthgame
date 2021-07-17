using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepTriggers : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DarrenSteps steps = other.GetComponentInChildren<DarrenSteps>();
            steps.UpdateSteps(_clip);
        }
    }
}
