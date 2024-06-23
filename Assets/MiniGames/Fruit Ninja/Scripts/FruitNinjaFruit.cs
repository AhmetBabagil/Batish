using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitNinjaFruit : MonoBehaviour
{
    public GameObject slicedVersion; // Kesilmiþ versiyonun prefab'ý.

    public void Setup(GameObject slicedPrefab)
    {
        slicedVersion = slicedPrefab;
    }
}
