using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

   //[SerializeField] private GameObject _coin;
        //reference to navmesh
    private NavMeshAgent _agent;
    private Animator _anim;
    private Vector3 _destination;
    private bool _hasCoin = true;
    [SerializeField] private GameObject _coin;
    [SerializeField] private AudioClip _coinSound;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        if (_anim == null)
        {
            Debug.LogError("Player:: Animator is null");
        }

        //get the navmesh component
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null)
        {
            Debug.LogError("Player:: NavMeshAgent is null");
        }
    }



    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                _anim.SetBool("Walking",true);
                _agent.destination = hit.point;
                _destination = hit.point;
            }
        }

        float _distance = Vector3.Distance(transform.position, _destination);
        
        if (_distance < 2.5f)
        {
            _anim.SetBool("Walking", false);
        }

        if (Input.GetMouseButtonDown(1) && _hasCoin)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Instantiate(_coin, hit.point, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_coinSound, hit.point);
                _anim.SetTrigger("Throwing");
                _hasCoin = false;
                CoinDistraction(hit.point);
            }

        }

    }

    private void CoinDistraction(Vector3 Coin)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        if (guards.Length != 0)
        {
            foreach (var g in guards)
            {
                GuardAI gAI = g.GetComponent<GuardAI>();
                gAI.GuardsMoveOut(Coin);
            }
        }
    }

        


}