using NUnit.Framework;
using UnityEngine;


namespace ProjectS.PlayerData {
    public class BasePlayerData 
    {
        public bool IsInitialized { get; private set; }

        public BasePlayerData(bool isInitialized) {
            IsInitialized = isInitialized;
        }
    }
}

