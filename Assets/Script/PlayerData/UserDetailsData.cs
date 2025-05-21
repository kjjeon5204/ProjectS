using UnityEditor;
using UnityEngine;


namespace ProjectS.PlayerData
{
    /// <summary>
    /// Contains various session related information
    /// </summary>
    public class UserDetailsData : BasePlayerData
    {
        public static UserDetailsData CreateNew()
        {
            return new UserDetailsData(false);
        }


        public string UserName { get; set; }

        public UserDetailsData(bool isInitialized) : base(isInitialized)
        {
        }


        public void SetUserName(string userName)
        {
            UserName = userName;
        }
    }
}

