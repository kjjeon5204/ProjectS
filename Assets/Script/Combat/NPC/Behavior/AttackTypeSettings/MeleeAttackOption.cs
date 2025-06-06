using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;



[System.Serializable]
public class MeleeAttackOption
{
    public List<string> colliders = new List<string>();

    public GameObject hitEffect;
}
