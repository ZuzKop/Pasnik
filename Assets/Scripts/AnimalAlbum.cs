using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimalAlbum : MonoBehaviour
{
    public GameObject profil;
    public GameObject menu;
    public GameObject opis;

    public GameObject aparat;
    public LeanTweenManager ltm;

    void Awake()
    {
        ltm = GameObject.FindGameObjectWithTag("LeanTween").GetComponent<LeanTweenManager>();
        aparat = GameObject.FindGameObjectWithTag("aparatButton");
    }

    void OnMouseUp()
    {
        if (!IsPointerOverUIObject() && !aparat.GetComponent<PhotoMode>().photoModeOn)
        {
            gameObject.GetComponent<UpdateCounters>().UpdateTextCounters();
            ltm.CloseAllMenus(menu);
            ltm.SlideDown();
            profil.SetActive(true);
            opis.SetActive(true);
        }
    }

    private bool IsPointerOverUIObject()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return true;

        for (int touchIndex = 0; touchIndex < Input.touchCount; touchIndex++)
        {
            Touch touch = Input.GetTouch(touchIndex);
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                return true;
        }

        return false;
    }

}

