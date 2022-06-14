using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFader : GameBehaviour
{
    public CanvasGroup background;
    // Start is called before the first frame update
    void Start()
    {
        background.alpha = 1;
        FadeOutCanvas(background, 3f);
    }

    
}
