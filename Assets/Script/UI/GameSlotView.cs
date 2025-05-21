
using ProjectS.PlayerData;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectS.UI
{
    /// <summary>
    /// This method is used to show list of available save slots.
    /// This view is used to select new game slot selection or load existing game slot.
    /// 
    /// Comprises of vertical list of game slots.
    /// </summary>
    public class GameSlotView : MonoBehaviour
    {
        public Transform slotHolder;
        public GameSlotEntry slotPrefab;


        public void DisplaySlots(List<UserInfo> dataList, int slotCount)
        {
            for (int i = 0; i < slotCount; i++)
            {
                GameSlotEntry slot = Instantiate(slotPrefab, slotHolder);
                slot.SetData(dataList[i]);
            }
        }

        public void DisplaySlots(List<UserInfo> dataList)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                GameSlotEntry slot = Instantiate(slotPrefab, slotHolder);
                slot.SetData(dataList[i]);
            }
        }
    }
}

