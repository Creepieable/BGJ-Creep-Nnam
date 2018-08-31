using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private float check;
    public GameObject canvas;
    private CanvasGroup canvasGroup;

    private bool fadeAndReloade = false;


    public void reloadScene()
    {     
        canvasGroup = canvas.GetComponent<CanvasGroup>();
        fadeAndReloade = true;       
    }

    private void Update()
    {
        if (canvasGroup != null)
        {
            if (fadeAndReloade)
            {
                canvasGroup.alpha += Time.deltaTime / 3;

                if (canvasGroup.alpha >= 1)
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
        }
    }






}

    
