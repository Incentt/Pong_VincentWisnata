using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject Transition;
    // Start is called before the first frame update
    void Start()
    {
        Transition.SetActive(false);

    }

    public void startgame()
    {
        Transition.SetActive(true);
        Invoke("Changescene", 1.55f);
        
    }
    public void quit()
    {
        Application.Quit();
    }
    void Changescene()
    {
        SceneManager.LoadScene(1);
    }
}
