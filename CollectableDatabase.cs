using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class CollectableDatabase
{
    public static Dictionary<CollectableType, float> healValues = new Dictionary<CollectableType, float>
    {
        { CollectableType.MEDICINE, 20f }
        // Add other collectables and their effects here
    };
}
