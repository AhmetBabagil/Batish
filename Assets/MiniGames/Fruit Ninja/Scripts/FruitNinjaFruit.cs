using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitNinjaFruit : MonoBehaviour
{
    public GameObject slicedVersion; // Kesilmi� versiyonun prefab'�.

    public void Setup(GameObject slicedPrefab)
    {
        slicedVersion = slicedPrefab;
    }
}
