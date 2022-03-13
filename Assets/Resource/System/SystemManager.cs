using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    static SystemManager instance;
    public static SystemManager Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField] skiilData skiilDataDb;
    public skiilData SkiilDataDb
    {
        get
        {
            return skiilDataDb;
        }
    }

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        
    }
}
