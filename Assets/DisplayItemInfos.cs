using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItemInfos : MonoBehaviour
{
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI itemName;

    public void ShowData(Item itemToDisplay)
    {
        itemText.text = itemToDisplay.Description;
        itemName.text = itemToDisplay.name;

    }
}
