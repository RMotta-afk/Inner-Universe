using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject darkScreen;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDesc;
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
            if (!menuCanvas.activeSelf && PauseController.IsGamePaused)
                return;

            menuCanvas.SetActive(!menuCanvas.activeSelf);
            darkScreen.SetActive(!darkScreen.activeSelf);
            PauseController.SetPause(menuCanvas.activeSelf);

            if (!menuCanvas.activeSelf)
            {
                itemName.text = string.Empty;
                itemDesc.text = string.Empty;
            }
        }
    }
}
