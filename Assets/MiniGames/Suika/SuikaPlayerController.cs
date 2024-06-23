using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuikaPlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Transform _leftPoint;  // Sol kenar i�in GameObject
    [SerializeField] private Transform _rightPoint; // Sa� kenar i�in GameObject
    [SerializeField] private Transform _fruitThrowTransform;

    private float _leftBound;
    private float _rightBound;

    private bool _movingRight = true; // Ba�lang�� y�n�

    // Unity Message | 0 references
    private void Awake()
    {
        // S�n�rlar� do�rudan Transform nesnelerinden al
        _leftBound = _leftPoint.position.x;
        _rightBound = _rightPoint.position.x;
    }

    // Unity Message | 0 references
    private void Update()
    {
        // E�er sa� s�n�r� ge�tiyse veya sol s�n�r�n alt�na d��t�yse y�n de�i�tir
        if (_movingRight && transform.position.x >= _rightBound)
        {
            _movingRight = false;
        }
        else if (!_movingRight && transform.position.x <= _leftBound)
        {
            _movingRight = true;
        }

        // Y�n bilgisine g�re yeni pozisyonu hesapla
        float direction = _movingRight ? 1 : -1;
        Vector3 moveDelta = new Vector3(direction * _moveSpeed * Time.deltaTime, 0, 0);
        transform.position += moveDelta;
    }
/*
    public void ChangeBoundary(float extraWidth)
    {
        // S�n�rlar� geni�letmek veya daraltmak i�in mevcut noktalar�n x pozisyonlar�n� g�ncelle
        _leftPoint.position = new Vector3(
            _leftPoint.position.x - SuikaThrowFruitController.instance.Bounds.extents.x - extraWidth,
            _leftPoint.position.y,
            _leftPoint.position.z
        );

        _rightPoint.position = new Vector3(
            _rightPoint.position.x + SuikaThrowFruitController.instance.Bounds.extents.x + extraWidth,
            _rightPoint.position.y,
            _rightPoint.position.z
        );

        // S�n�rlar� yeni transform pozisyonlar�ndan g�ncelle
        _leftBound = _leftPoint.position.x;
        _rightBound = _rightPoint.position.x;
    }

    */
}
