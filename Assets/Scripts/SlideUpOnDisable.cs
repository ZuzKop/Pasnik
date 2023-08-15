using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideUpOnDisable : MonoBehaviour
{
    public GameObject pan;

    public void SlideUpAndDisable(GameObject panel)
    {
        LeanTween.moveY(panel.GetComponent<RectTransform>(), 1800, 0.2f);
        StartCoroutine(WaitSome(panel));
    }

    IEnumerator WaitSome(GameObject panel)
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        LeanTween.moveY(pan.GetComponent<RectTransform>(), 1800, 0.2f);
    }
}
