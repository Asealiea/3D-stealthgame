using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [SerializeField] private List <Transform> _waypoints;
    [SerializeField] private int _curentTarget;
    private NavMeshAgent _agent;
    private bool _reverse;
    private bool _breather;
    private Animator _anim;
    private bool _coinTossed = false;
    private Vector3 _coinPos;


    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.Log("GuardAI:: Animator is null");
        }
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null )
        {
            Debug.Log("GuardAI:: NavMeshAgent is null");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (_waypoints.Count > 0 && _waypoints[_curentTarget] != null && !_coinTossed)
        {
            if (_waypoints.Count <= 1)
            {
                _anim.SetBool("Walking", false);
                return;
            }

            _agent.SetDestination(_waypoints[_curentTarget].position);
            float distance = Vector3.Distance(transform.position,_waypoints[_curentTarget].position);
            if (distance < 1 && !_breather)
            {
                //when target reached, wait for a couple seconds before moving on.
                if (_anim != null)
                    _anim.SetBool("Walking", false);                
                _breather = true;
                StartCoroutine(WaitForBreather());

            }
        }
        else
        {
            float distance = Vector3.Distance(transform.position, _coinPos);
            if (distance < 2f) 
            {
                _anim.SetTrigger("Alert");
                StartCoroutine(CoinDistractionCoolDown());
            }
        }

    }

    IEnumerator WaitForBreather()
    {
        //yield return new WaitForSeconds(Random.Range(2f, 5f));
        if (!_reverse)
        {
            _curentTarget++;
            if (_curentTarget == _waypoints.Count)
            {
                _curentTarget--;
                yield return new WaitForSeconds(Random.Range(2f, 5f));
                _reverse = true;
            }
        }
        else
        {
            _curentTarget--;
            if (_curentTarget < 0)
            {
                _curentTarget++;
                yield return new WaitForSeconds(Random.Range(2f, 5f));
                _reverse = false;
            }
        }
        if (_anim != null)
        _anim.SetBool("Walking", true);                
        _breather = false;
    }

    public void GuardsMoveOut(Vector3 pos)
    {
        _agent.SetDestination(pos);
        _anim.SetBool("Walking", true);
        _coinTossed = true;
        _coinPos = pos;                
    }

    IEnumerator CoinDistractionCoolDown()
    {
        yield return new WaitForSeconds(5f);
        _coinTossed = false;
       // _curentTarget = 0;
        _agent.SetDestination(_waypoints[0].position);
        yield break;
    }
}
