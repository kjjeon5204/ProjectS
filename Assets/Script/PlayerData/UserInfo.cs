using System;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectS.PlayerData {
    /// <summary>
    /// Root user info that contains each user info entry.
    /// </summary>
    public class UserInfo 
    {
        public static UserInfo CreateNewSession()
        {
            return new UserInfo(Guid.NewGuid().ToString(), new Dictionary<Type, BasePlayerData>());
        }


        public string UserSessionID { get; private set; }

        public Dictionary<Type, BasePlayerData> SubDataDict { get; private set; }


       

        public UserInfo(string userSessionID, Dictionary<Type, BasePlayerData> subDataDict) {
            UserSessionID = userSessionID;
            SubDataDict = subDataDict;
        }



        public void UpdatePlayerData(BasePlayerData data)
        {
            SubDataDict[data.GetType()] = data;
        }

        public BasePlayerData GetSubData<T> () where T : BasePlayerData {
            if (SubDataDict.ContainsKey(typeof(T))) return SubDataDict[typeof(T)];
            else return null;
        }
    }
}