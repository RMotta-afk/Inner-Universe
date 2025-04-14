using System.IO;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    private string saveLocation;
    private InventoryController inventoryController;
    private ToolBarController toolbarController;
    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
        inventoryController = FindFirstObjectByType<InventoryController>();
        toolbarController = FindFirstObjectByType<ToolBarController>();

        LoadGame();
    }

    public void SaveGame()
    {

        SaveData saveData = new SaveData { playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position, 
        inventorySaveData = inventoryController.GetInventoryItems(),
        toolBarSaveData = toolbarController.GetToolBarItems()
        };


        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));

            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;

            inventoryController.SetInventoryItems(saveData.inventorySaveData);
            toolbarController.SetToolBarItems(saveData.inventorySaveData);
        }
        else
        {
            SaveGame();
        }
    }
}
