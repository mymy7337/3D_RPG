using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int enemies;
    [SerializeField] private GameObject clearUI;

    private void Update()
    {
        if (enemies == 0)
            clearUI.SetActive(true);
    }
}
