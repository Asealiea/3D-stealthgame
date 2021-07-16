using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCardTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _grabCardCS;
    [SerializeField] private GameObject _guardsCard;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _grabCardCS.SetActive(true);
            _guardsCard.SetActive(false);
            GameManager.Instance.HasCard = true;
        }
    }
}
