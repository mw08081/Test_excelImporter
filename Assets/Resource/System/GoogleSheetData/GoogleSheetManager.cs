using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    readonly string URL = "https://docs.google.com/spreadsheets/d/1gIK-KaD8iGZFegPnz1d-HmjFNT53KRKuqVAQxr66gkM/" +
        "export?format=tsv&range=A2:D&gid=1996697708";

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        SetDataEntity(www.downloadHandler.text);
    }

    void SetDataEntity(string tsv)
    {
        string[] row = tsv.Split('\n');
        int rowSize = row.Length;
        int columnSize = row[0].Split('\t').Length;

        for (int i = 0; i < rowSize; i++)
        {
            string[] column = row[i].Split('\t');

            SystemManager.Instance.SpellManager.spellDatas.Add(new SpellData());

            SystemManager.Instance.SpellManager.spellDatas[i].name = column[0];
            SystemManager.Instance.SpellManager.spellDatas[i].coolDown = float.Parse(column[1]);
            SystemManager.Instance.SpellManager.spellDatas[i].range = float.Parse(column[2]);
            SystemManager.Instance.SpellManager.spellDatas[i].targetting = int.Parse(column[3]);
        }
    }
}
