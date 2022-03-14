using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpellData
{
    public string name;
    public float coolDown;
    public float range;
    public int targetting;
}

public class SpellManager : MonoBehaviour
{
    public List<SpellData> spellDatas = new List<SpellData>();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
