using System;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject parent;

    private void OnDestroy()
    {
        Destroy(parent);
    }
}
