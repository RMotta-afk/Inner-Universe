using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._03_Scripts.Core.Events
{
    internal class BossEvents
    {
        public static event Action<int> OnAttacked;


        public static event Action OnPlayerKilled;

        public static void TriggerBossAttacked(int attackDamage) => OnAttacked?.Invoke(attackDamage);

        public static void TriggerPlayerKilled() => OnPlayerKilled?.Invoke();

    }
}
