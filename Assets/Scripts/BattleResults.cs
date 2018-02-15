using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleResults : MonoBehaviour {
    [SerializeField]
    GameObject resultManager;

    public void RevealResults()
    {
        resultManager.SetActive(true);
    }

    public void HideResults()
    {
        resultManager.SetActive(false);
    }
}
