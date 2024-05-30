using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    
    [SerializeField] private Slider slider;
    //[SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    private Camera mainCamera;

    public void Start()
    {
        mainCamera = Camera.main;
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    void Update()
    {
        // transform.rotation = Quaternion.identity;
        // transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position);
        transform.rotation = mainCamera.transform.rotation;
        transform.position = target.position + offset;
    }
}
