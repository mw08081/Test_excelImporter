## 스크립터블 오브젝트
```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct S_SkillData
{
    public string Id { get; private set; }                 //?? ID
    public bool IsActive { get; private set; }             //??? ??? ?? 
    public bool IsNonTargeting { get; private set; }       //??? ?? 
    public int ElecConsume { get; private set; }           //?? ??? 
    public int ElecTransfer { get; private set; }          //?? ?? ?? 
    public float CoolTime { get; private set; }            //?? ???
    public string RangeId { get; private set; }            //?? ??? ??? ?? ID
    public string EffectId { get; private set; }           //?? ??? ??? ?? ID
    public string UseAnimationId { get; private set; }     //?? ????? ??? ?? ID
    public string NameStringId { get; private set; }       //?? ?? ??? ?? ID
    public int SkillRange { get; private set; }    //?? ?? ??? ?? ID
    public int[] SkillValues { get; private set; }


    public S_SkillData(string id, bool isActive, bool isNonTargeting, int elecConsume, int elecTransfer, float coolTime, string rangeId, string effectId, string useAnimationId, string nameStringId, int skillRange, int[] _skillValues)
    {
        Id = id;
        IsActive = isActive;
        IsNonTargeting = isNonTargeting;
        ElecConsume = elecConsume;
        ElecTransfer = elecTransfer;
        CoolTime = coolTime;
        RangeId = rangeId;
        EffectId = effectId;
        UseAnimationId = useAnimationId;
        NameStringId = nameStringId;
        SkillRange = skillRange;
        SkillValues = _skillValues;
    }
}

[CreateAssetMenu(fileName = "new Data_T_Table", menuName = "Data Table/Skill")]
public class Data_Skill_Table : ScriptableObject
{
    //?? ?? - ???? ID
    public Dictionary<string, S_SkillData> SkillDatas = new Dictionary<string, S_SkillData>();

    public void AddSKillDatas(S_SkillData skillData)
    {
        try
        {
            SkillDatas.Add(skillData.Id, skillData);
        }
        catch(System.Exception e)
        {
#if DEV
            //Debug.LogWarning(e.Message);
#endif
        }
    }
}

```

## Excel Importer (for mp)

### How to test 
excel 폴더안의 skillData 값을 변경하면 그 즉시 데이터가 유니티 프로젝트에 반영된다
a,s,d 를 통해서 각각의 skillName, coolDown을 확인해볼 수 있다

### reference
https://github.com/mikito/unity-excel-importer  
https://www.youtube.com/watch?v=2oip0H7VgPM&list=WL&index=16&t=505s  
//불러오기만 수행, 스크립터블 오브젝트 생성과 할당은 내가 구현해야하는 부분
  
## Google Sheet Reader (for mp)

### How to test
build 후 space를 누르면 tmp에 b2셀의 데이터가 나타난다(전체 데이터는 디버그 값으로 출력했으니 Run상태에서는 볼 수 없다)

재빌드를 하지 않아도 B2셀의 값을 변경 후, exe파일을 실행한다면 flash의 coolDown이 변경된 것을 확인할 수 있다

1. 구글시트 추출
```C#
#region DEV - GOOGLE EXCEL SHEET
    private const string DATA_SKILL_TABLE_URL = "https://docs.google.com/spreadsheets/d/1keaLZLRqs5bVp5iWA9jOapqTmcmiQJ3kY6ZlW5jl_UA/export?format=tsv&range=D2:O";

    IEnumerator Coroutine_GetDataSkillTable()
    {
        UnityWebRequest www = UnityWebRequest.Get(DATA_SKILL_TABLE_URL); 
        yield return www.SendWebRequest();  

        string data = www.downloadHandler.text;
     
        GetDataSkillTable(data);
    }

    public void GetDataSkillTable(string tableData)
    {
        string[] row = tableData.Split('\n');

        for (int rowIndex = 0; rowIndex < row.Length; rowIndex++)
        {
            string[] column = row[rowIndex].Split('\t');

            string id = column[0];

            bool isActive;
            if(string.IsNullOrEmpty(column[1]))
            {
                isActive = false;
            }
            else
            {
                isActive = bool.Parse(column[1].ToLower());
            }

            bool isNonTargeting;
            if (string.IsNullOrEmpty(column[2]))
            {
                isNonTargeting = false;
            }
            else
            {
                isNonTargeting = bool.Parse(column[2].ToLower());
            }

            int elecConsume;
            if (string.IsNullOrEmpty(column[3]))
            {
                elecConsume = 0;
            }
            else
            {
                elecConsume = int.Parse(column[3]);
            }

            int elecTransfer;
            if (string.IsNullOrEmpty(column[4]))
            {
                elecTransfer = 0;
            }
            else
            {
                elecTransfer = int.Parse(column[4]);
            }

            float coolTime;
            if (string.IsNullOrEmpty(column[5]))
            {
                coolTime = 0.0f;
            }
            else
            {
                coolTime = float.Parse(column[5]);
            }

            string rangeId = column[6];
            string effectId = column[7];
            string useAnimationId = column[8];
            string nameStringId = column[9];
            int skillRange;
            if (string.IsNullOrEmpty(column[10]))
            {
                skillRange = 0;
            }
            else
            {
                skillRange = int.Parse(column[10]);
            }

            int[] skillValues = null;

            if (column[11].Trim() != "null")
            {
                string[] skillValuesTmp = column[11].Split(',');
                skillValues = new int[skillValuesTmp.Length];

                for (int j = 0; j < skillValuesTmp.Length; j++)
                {
                    skillValues[j] = int.Parse(skillValuesTmp[j]);
                }
            }

            S_SkillData skillData = new S_SkillData(id, 
                                                    isActive, 
                                                    isNonTargeting, 
                                                    elecConsume, 
                                                    elecTransfer, 
                                                    coolTime, 
                                                    rangeId, 
                                                    effectId, 
                                                    useAnimationId, 
                                                    nameStringId,
                                                    skillRange, 
                                                    skillValues);

            DataSkillTable.AddSKillDatas(skillData);
        }
    }
    #endregion
```
