using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormulaResult : MonoBehaviour 
{
    [SerializeField]
    int atk = 10;
    [SerializeField]
    int spd = 5;
    [SerializeField]
    int def = 7;
    [SerializeField]
    int hp = 20;
    [SerializeField]
    bool magRes;
    [SerializeField]
    bool phyRes;

    [SerializeField]
    RectTransform attackField;
    [SerializeField]
    RectTransform speedField;
    [SerializeField]
    RectTransform defenseField;
    [SerializeField]
    RectTransform healthField;
    [SerializeField]
    Text result;

	// Use this for initialization
	void Start () 
	{
        attackField.Find("Placeholder").GetComponent<Text>().text = atk.ToString();
        speedField.Find("Placeholder").GetComponent<Text>().text = spd.ToString();
        defenseField.Find("Placeholder").GetComponent<Text>().text = def.ToString();
        healthField.Find("Placeholder").GetComponent<Text>().text = hp.ToString();
    }
	
	// Update is called once per frame
	void Update () 
	{
        UpdateStats();
        if (atk >= def)
        {
            if (hp - atk + def >= 0)
                result.text = string.Format("{0} - {1} = {2} damage.\nHealth remaining: {3}", atk, def, atk - def, hp - atk + def);
            else
                result.text = string.Format("{0} - {1} = {2} damage.\nHealth remaining: 0", atk, def, atk - def);
        }
        else
            result.text = string.Format("{0} - {1} = 0 damage.\nHealth remaining: {2}", atk, def, hp);
    }

    void UpdateStats()
    {
        if (attackField.Find("Text").GetComponent<Text>().text != "")
            int.TryParse(attackField.Find("Text").GetComponent<Text>().text, out atk);
        else
            int.TryParse(attackField.Find("Placeholder").GetComponent<Text>().text, out atk);
        if (speedField.Find("Text").GetComponent<Text>().text != "")
            int.TryParse(speedField.Find("Text").GetComponent<Text>().text, out spd);
        else
            int.TryParse(speedField.Find("Placeholder").GetComponent<Text>().text, out spd);
        if (defenseField.Find("Text").GetComponent<Text>().text != "")
            int.TryParse(defenseField.Find("Text").GetComponent<Text>().text, out def);
        else
            int.TryParse(defenseField.Find("Placeholder").GetComponent<Text>().text, out def);
        if (healthField.Find("Text").GetComponent<Text>().text != "")
            int.TryParse(healthField.Find("Text").GetComponent<Text>().text, out hp);
        else
            int.TryParse(healthField.Find("Placeholder").GetComponent<Text>().text, out hp);
    }
}
