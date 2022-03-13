using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class skillDataEntity
{
    public int index;
    public string spellName;
    public float coolDown;
}

[ExcelAsset]
public class skiilData : ScriptableObject
{
    public List<skillDataEntity> Spell; // Replace 'EntityType' to an actual type that is serializable.

}
