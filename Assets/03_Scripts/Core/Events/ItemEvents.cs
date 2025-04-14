using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;

namespace Assets._03_Scripts.Core.Events
{
    public static class ItemEvents
    {
        public static event Action<TextMeshProUGUI, TextMeshProUGUI, Image> OnItemDisplayData;


        public static void TriggerItemShowInfo(TextMeshProUGUI itemName, TextMeshProUGUI itemDescription, Image itemIcon) => OnItemDisplayData?.Invoke(itemName, itemDescription, itemIcon);
    }
}
