using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameView : MonoBehaviour
{
    [SerializeField] public CharaBehaviour CharaBehaviour;
    [SerializeField] public IngameCameraController CameraController;

    [SerializeField] public ItemSpawner ItemSpawner;

    [SerializeField] public IngameUIController GameUIController;
}
