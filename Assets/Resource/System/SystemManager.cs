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
    [SerializeField] SpellManager spellManager;
    public SpellManager SpellManager
    {
        get
        {
            return spellManager;
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
