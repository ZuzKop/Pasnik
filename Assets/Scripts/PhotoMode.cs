using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoMode : MonoBehaviour
{
    public GameObject aparatOn;
    public GameObject aparat;
    public SpriteRenderer polaroid;
    public SpriteRenderer kadr;
    public bool photoModeOn;

    // Start is called before the first frame update
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            photoModeOn = false;
            aparatOn.SetActive(false);
            aparat.SetActive(true);
        }
    }


    public void EnablePhotoMode()
    {
        photoModeOn = true;
    }

    public void DisablePhotoMode()
    {
        polaroid.enabled = false;
        kadr.enabled = false;
        photoModeOn = false;
        aparatOn.SetActive(false);
        aparat.SetActive(true);


    }

}
