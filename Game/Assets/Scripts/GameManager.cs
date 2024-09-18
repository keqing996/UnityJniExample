using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Button button;
    [SerializeField] public Transform box;
    [SerializeField] public float rotateSpeed = 100;

    void Update()
    {
        box.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
}
