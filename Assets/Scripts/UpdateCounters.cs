using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCounters : MonoBehaviour
{
    public Text photoCounter;
    public Text visitCounter;
    public GameObject Animal;
    public Text totalPhotos;
    public SaveState saveState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateTextCounters()
    {
        //photos i visits sa zamienione, bo nie chce mi sie podmieniac ich w ui, a pomylilo mi sie cos tam wczesniej. moze to naprawie
        int photos = PlayerPrefs.GetInt("ile-" + Animal.name);
        int visits = PlayerPrefs.GetInt(Animal.name + "Photo");

        string photosString = photos.ToString();
        string visitsString = visits.ToString();

        photoCounter.text = photosString;
        visitCounter.text = visitsString;
    }
}
