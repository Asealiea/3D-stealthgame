using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _winCS;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.HasCard)
        {
            _winCS.SetActive(true);
        }
    }
}
