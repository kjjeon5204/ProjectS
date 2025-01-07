using System.Collections.Generic;
using UnityEngine;


namespace ProjectS.PlayerData {
    public class MasterData 
    {
        public static MasterData instance;

        public List<BasePlayerData> playerDataList = new List<BasePlayerData>();


        public MasterData() {
            instance = this;
        }


        public void LoadPlayerData() {
            // Load the player data from the database.
            
        }
    }
}

