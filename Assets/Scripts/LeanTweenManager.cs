using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenManager : MonoBehaviour
{
    public GameObject fade;
    public GameObject menus;

    public void SlideDown()
    {
        LeanTween.moveY(menus.GetComponent<RectTransform>(), 0, 0.3f);
        fade.SetActive(true);
    }

    public void SlideUp()
    {
        LeanTween.moveY(menus.GetComponent<RectTransform>(), 1800, 0.3f);
        fade.SetActive(false);
    }

    public void CloseAllMenus(GameObject butThisOne)
    {
        foreach (Transform child in menus.transform) { child.gameObject.SetActive(false); }

        if(butThisOne)
        {
            butThisOne.SetActive(true);
        }
    }
}
