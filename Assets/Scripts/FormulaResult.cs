using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormulaResult : MonoBehaviour 
{
    [SerializeField]
    Toggle resToggleOne;
    [SerializeField]
    Toggle resToggleTwo;
    [SerializeField]
    Text result;
    [Tooltip("P1 Attack, P1 Defense, P1 Speed, P1 Health, P2 Attack, P2 Defense, P2 Speed, P2 Health")]
    [SerializeField] List<RectTransform> statBoxes;
    [SerializeField] List<int> numericStats;
    /*
    [SerializeField]
    RectTransform attackField;
    [SerializeField]
    RectTransform speedField;
    [SerializeField]
    RectTransform defenseField;
    [SerializeField]
    RectTransform healthField;
    */


	private int damage;
    int atk = 0;
    int spd = 2;
    int def = 5;
    int hp = 7;
    int enemySpd = 2;
    int atkTimes = 1;
    bool res;
    bool resOne;
    bool resTwo;
    bool pTwoDead = false;
    string resultString;

    void Start () 
	{
        res = resTwo;
        for (int i = 0; i < statBoxes.Count; i++)
        {
            statBoxes[i].Find("Placeholder").GetComponent<Text>().text = numericStats[i].ToString();
        }

    }

	void Update () 
	{
        UpdateStats();
        for (int i = 1; i <= 2; i++)
        {

            if (res)
            {
                numericStats[def] = Mathf.RoundToInt((numericStats[def] * 1.15f) + .1f);
                damage = numericStats[atk] - numericStats[def];
            }
            else
                damage = numericStats[atk] - numericStats[def];
            if (numericStats[spd] - numericStats[enemySpd] >= 5)
                atkTimes = 2;
            else
                atkTimes = 1;
		    if (damage > 0)
            {
                if (numericStats[hp] - damage * atkTimes >= 0)
                    resultString = string.Format("{0} - {1} = {2} * {3} attack(s) = {4} damage. Health remaining: {5}\n", 
                        numericStats[atk], numericStats[def], damage, atkTimes, atkTimes * damage, numericStats[hp] - (damage * atkTimes));
                else
                {
                    resultString = string.Format("{0} - {1} = {2} * {3} attack(s) = {4} damage. Health remaining: 0\n", 
                        numericStats[atk], numericStats[def], damage, atkTimes, atkTimes * damage);
                    if(i == 1)
                        pTwoDead = true;
                }
            }
            else
                resultString = string.Format("{0} - {1} = 0 damage. Health remaining: {2}\n", 
                    numericStats[atk], numericStats[def], numericStats[hp]);
            if (i == 1 && !pTwoDead)
            {
                atk = 4;
                spd = 6;
                def = 1;
                hp = 3;
                enemySpd = 2;
                res = resOne;
                result.text = resultString;
                result.text += "\nCounterattack:\n";
            }
            else
            {
                atk = 0;
                spd = 2;
                def = 5;
                hp = 7;
                enemySpd = 6;
                res = resTwo;
                if (!pTwoDead)
                    result.text += resultString;
                else
                    result.text = resultString;
            }
        }
        
    }

    void UpdateStats()
    {
        resOne = resToggleOne.isOn;
        resTwo = resToggleTwo.isOn;
        for (int i = 0; i < statBoxes.Count; i++)
        {
            int val = 0;
            if (statBoxes[i].Find("Text").GetComponent<Text>().text != "")
                int.TryParse(statBoxes[i].Find("Text").GetComponent<Text>().text, out val);
            else
                int.TryParse(statBoxes[i].Find("Placeholder").GetComponent<Text>().text, out val);
            numericStats[i] = val;
        }
    }
}
