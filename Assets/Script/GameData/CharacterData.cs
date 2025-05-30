using UnityEngine;



namespace ProjectS.GameData
{
    [System.Serializable]
    public class ScalableStat
    {
        public int baseValue;
        public int limitBreakBonus;
        public int levelBonus;
    }

    [CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
    public class CharacterData : ScriptableObject
    {
        public string UnitID;

        public ScalableStat Health;
        public ScalableStat Defense;
        public ScalableStat Attack;

        public float MoveSpeed = 5f;
        public float RotationSpeed = 720f;
        public float AttackSpeed = 1f;

        /// <summary>
        /// Used for dodging.
        /// </summary>
        public int Stamina = 100;

    }

}
