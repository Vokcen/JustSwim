using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayButton()
    {
        SceneManager.LoadScene("Main");
    }

    // Update is called once per frame
   public void QuickButton()
    {
        Application.Quit();
    }
}
