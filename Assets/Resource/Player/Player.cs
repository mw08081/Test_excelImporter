using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    }
}
