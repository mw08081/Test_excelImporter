## Excel Importer (for mp)

### How to test 
excel 폴더안의 skillData 값을 변경하면 그 즉시 데이터가 유니티 프로젝트에 반영된다
a,s,d 를 통해서 각각의 skillName, coolDown을 확인해볼 수 있다

### reference
https://github.com/mikito/unity-excel-importer  
https://www.youtube.com/watch?v=2oip0H7VgPM&list=WL&index=16&t=505s  
  
## Google Sheet Reader (for mp)

### How to test
build 후 space를 누르면 tmp에 b2셀의 데이터가 나타난다(전체 데이터는 디버그 값으로 출력했으니 Run상태에서는 볼 수 없다)

재빌드를 하지 않아도 B2셀의 값을 변경 후, exe파일을 실행한다면 flash의 coolDown이 변경된 것을 확인할 수 있다

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
