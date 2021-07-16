using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager:: Instance is null");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }



    public bool HasCard { get; set; }
    [SerializeField] private PlayableDirector introCutscene;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            introCutscene.time = 55.5f;
        }

    }


}
