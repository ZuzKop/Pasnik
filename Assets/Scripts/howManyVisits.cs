using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class howManyVisits : MonoBehaviour
{
    void OnMouseDown()
    {
        if (!IsPointerOverUIObject())
        {
            Debug.Log("No of visits: " + PlayerPrefs.GetInt("ile-" + name ));
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
