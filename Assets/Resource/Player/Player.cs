using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshPro tmp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log(SystemManager.Instance.SkiilDataDb.Spell[0].spellName + " " + SystemManager.Instance.SkiilDataDb.Spell[0].coolDown);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log(SystemManager.Instance.SkiilDataDb.Spell[1].spellName + " " + SystemManager.Instance.SkiilDataDb.Spell[1].coolDown);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log(SystemManager.Instance.SkiilDataDb.Spell[2].spellName + " " + SystemManager.Instance.SkiilDataDb.Spell[2].coolDown);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log(SystemManager.Instance.SpellManager.spellDatas[0].name + " " + SystemManager.Instance.SpellManager.spellDatas[0].coolDown);
            Debug.Log(SystemManager.Instance.SpellManager.spellDatas[1].name + " " + SystemManager.Instance.SpellManager.spellDatas[1].coolDown);
            Debug.Log(SystemManager.Instance.SpellManager.spellDatas[2].name + " " + SystemManager.Instance.SpellManager.spellDatas[2].coolDown);

            tmp.text = SystemManager.Instance.SpellManager.spellDatas[0].name + " " + SystemManager.Instance.SpellManager.spellDatas[0].coolDown;
        }
    }
}
