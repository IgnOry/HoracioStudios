using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;

public class LocaleButton : MonoBehaviour
{
    private int selected = 0;
    private int totalLocales = 0;

    public Sprite AE;
    public Sprite GB;
    public Sprite EEUU;
    public Button bttn;

    void changeImage (int _selected)
    {
        if (selected == 0)
            bttn.image.sprite = EEUU;
        else if (selected == 1)
            bttn.image.sprite = GB;
        else
            bttn.image.sprite = AE;
    }

    IEnumerator Start()
    {
        // Wait for the localization system to initialize, loading Locales, preloading etc.
        yield return LocalizationSettings.InitializationOperation;

        // Generate list of available Locales
        totalLocales = LocalizationSettings.AvailableLocales.Locales.Count;
        for (int i = 0; i < totalLocales; ++i)
        {
            var locale = LocalizationSettings.AvailableLocales.Locales[i];
            if (LocalizationSettings.SelectedLocale == locale)
                selected = i;        
        }

        changeImage(selected);
    }

    // Start is called before the first frame update
    public void changeLocale()
    {
        if (selected < totalLocales - 1)
        {
            selected++;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[selected];
        }
        else
        {
            selected = 0;
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[selected];
        }

        changeImage(selected);

    }
}
