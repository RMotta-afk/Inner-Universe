using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;

namespace Assets._03_Scripts.Entities.Base
{
    internal interface IItem
    {
        TextMeshProUGUI itemName { get; set; }
        TextMeshProUGUI ItemText { get; set; }

        void UseItem();
    }
}
