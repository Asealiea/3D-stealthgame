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
                _destination = hit.point;

                _agent.destination = hit.point;
            }
        }
        float _distance = Vector3.Distance(transform.position, _destination);
        
        if (_distance < 2.5f)
        {
            _anim.SetBool("Walking", false);
        }
    }

        


}