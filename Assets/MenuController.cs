using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject darkScreen;
    void Start()
    {
        menuCanvas.SetActive(false);
        darkScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            //if (!menuCanvas.activeSelf && PauseController.IsGamePaused)
            //    return;

            menuCanvas.SetActive(!menuCanvas.activeSelf);
            darkScreen.SetActive(!darkScreen.activeSelf);
            //PauseController.SetPause(menuCanvas.activeSelf);
        }
    }
}
