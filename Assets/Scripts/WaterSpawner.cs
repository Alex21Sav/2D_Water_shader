using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _dropPrefab;

    private float _cooldown = 0;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }
    private void Update()
    {
        DropCreation();
    }
    private void DropCreation()
    {
        if (Input.GetMouseButton(0))
        {
            _cooldown -= Time.deltaTime;
            while (_cooldown < 0)
            {
                _cooldown += 0.01f;

                Instantiate(_dropPrefab, (Vector2)_mainCamera.ScreenToWorldPoint(Input.mousePosition) + Random.insideUnitCircle * .2f, Quaternion.identity);
            }
        }
    }
}
