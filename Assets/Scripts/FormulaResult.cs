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
    InputField attackField;
    [SerializeField]
    InputField speedField;
    [SerializeField]
    InputField defenseField;
    [SerializeField]
    InputField healthField;
    [SerializeField]
    Text result;

	// Use this for initialization
	void Start () 
	{
        attackField.textComponent.text = atk.ToString();
        speedField.textComponent.text = spd.ToString();
        defenseField.textComponent.text = def.ToString();
        healthField.textComponent.text = hp.ToString();
    }
	
	// Update is called once per frame
	void Update () 
	{
        result.text = string.Format("{0} - {1} = {2} damage.\nHealth remaining: {3}", atk, def, atk - def, hp - atk + def);

    }
}
