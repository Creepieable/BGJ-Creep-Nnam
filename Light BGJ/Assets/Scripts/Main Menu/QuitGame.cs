using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

    public void quit_game ()
    {
        Debug.Log("You has quit the game!");
        Application.Quit();
    }

}
