using System;

namespace Enemies
{
    public class EventManager
    {
        public static event Action CharacterDied;

        public static void OnCharacterDied()
        {
            CharacterDied?.Invoke();
        }
    }
}