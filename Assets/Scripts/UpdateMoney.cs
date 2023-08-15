using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoney : MonoBehaviour
{
    public Text txt;
    public Text txtSecond;

    public SaveState saveState;

   void Awake()
    {
        saveState = GameObject.FindObjectOfType<SaveState>();
    }

    public void MoneyUpdate()
    {
        txt.text = saveState.GetPieniazki().ToString();
        txtSecond.text = saveState.GetPieniazki().ToString();
    }

}
