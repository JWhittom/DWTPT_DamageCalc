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
        attackField.text = atk.ToString();
        speedField.text = spd.ToString();
        defenseField.text = def.ToString();
        healthField.text = hp.ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{

        result.text = atk + " - " + def + " = " + (atk - def).ToString() + " damage.\n Health remaining: " + (hp - (atk - def)).ToString(); 

    }
}
