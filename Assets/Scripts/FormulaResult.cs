using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormulaResult : MonoBehaviour 
{
    [SerializeField]
    int atk = 10;
    [SerializeField]
    int spd = 1;
    [SerializeField]
    int def = 7;
    [SerializeField]
    int hp = 20;
    [SerializeField]
    bool res;

    [SerializeField]
    RectTransform attackField;
    [SerializeField]
    RectTransform speedField;
    [SerializeField]
    RectTransform defenseField;
    [SerializeField]
    RectTransform healthField;
    [SerializeField]
    Toggle resToggle;
    [SerializeField]
    Text result;

	private int damage;

	void Start () 
	{
        attackField.Find("Placeholder").GetComponent<Text>().text = atk.ToString();
        speedField.Find("Placeholder").GetComponent<Text>().text = spd.ToString();
        defenseField.Find("Placeholder").GetComponent<Text>().text = def.ToString();
        healthField.Find("Placeholder").GetComponent<Text>().text = hp.ToString();
    }

	void Update () 
	{
        UpdateStats();
        if (res)
        {
            def = Mathf.RoundToInt((def * 1.15f) + .1f);
            damage = atk - def;
        }
        else
            damage = atk - def;
		if (damage > 0)
        {
            if (hp - damage * spd >= 0)
				result.text = string.Format("{0} - {1} = {2} * {3} attack(s) = {4} damage.\nHealth remaining: {5}", atk, def, damage, spd, spd * damage, hp - (damage * spd));
            else
				result.text = string.Format("{0} - {1} = {2} * {3} attack(s) = {4} damage.\nHealth remaining: 0", atk, def, damage, spd, spd * damage);
        }
        else
            result.text = string.Format("{0} - {1} = 0 damage.\nHealth remaining: {2}", atk, def, hp);
    }

    void UpdateStats()
    {
        res = resToggle.isOn;
        if (attackField.Find("Text").GetComponent<Text>().text != "")
            int.TryParse(attackField.Find("Text").GetComponent<Text>().text, out atk);
        else
            int.TryParse(attackField.Find("Placeholder").GetComponent<Text>().text, out atk);
		if (speedField.Find ("Text").GetComponent<Text> ().text != "") 
		{
			int.TryParse (speedField.Find ("Text").GetComponent<Text> ().text, out spd);
			spd = Mathf.Min (3, spd);
			spd = Mathf.Max (1, spd);
		}
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
