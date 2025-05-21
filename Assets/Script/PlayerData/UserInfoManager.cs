using ProjectS.Map;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectS.PlayerData
{
    public class UserInfoManager : MonoBehaviour
    {
        public static UserInfoManager Instance;

        /// <summary>
        /// Current session info.
        /// </summary>
        private UserInfo currentSessionInfo;

        private Dictionary<Type, Func<BasePlayerData>> InfoCreator = new Dictionary<Type, Func<BasePlayerData>>
        {
            {typeof(UserDetailsData), UserDetailsData.CreateNew },
            {typeof(PlayerMapData),  PlayerMapData.CreateNew },
        };


        public void CreateNewUserSession()
        {
            currentSessionInfo = UserInfo.CreateNewSession();
        }

        public T GetSubData<T>(bool autoCreate = true) where T : BasePlayerData
        {
            if (currentSessionInfo == null)
            {
                throw new Exception("No active session found!");
            }

            BasePlayerData data = currentSessionInfo.GetSubData<T>();

            if (data == null && autoCreate)
            {
                data = InfoCreator[typeof(T)](); //Creates info of type

                //Save data to current session
                currentSessionInfo.UpdatePlayerData(data);  
            }

            return (T)data;
        }



        public void Start()
        {
            Instance = this;
        }
    }
}

