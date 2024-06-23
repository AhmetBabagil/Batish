using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class AngryBirdsSlingShotHandler : MonoBehaviour
{
    [Header("Line Renderers")]
    [SerializeField] private LineRenderer _leftLineRenderer;
    [SerializeField] private LineRenderer _rightLineRenderer;


    [Header("Transform References")]
    [SerializeField] private Transform _leftStartPosition;
    [SerializeField] private Transform _rightStartPosition;
    [SerializeField] private Transform _centerPosition;
    [SerializeField] private Transform _idlePosition;

    [Header("Slingshot Stats")]
    [SerializeField] private float _maxDistance=3.5f;
    [SerializeField] private float _shotForce = 5f;
    [SerializeField] private float _timeBetweenBirdRespawns = 2f;

    [Header("Scripts")]
    [SerializeField] private AngryBirdsSlingShotArea _slingShotArea;

    [Header("Bird")]
    [SerializeField] private AngryBirdsAngieBird _angieBirdPrefab;
    [SerializeField] private float _angieBirdPositionOffset=2f;

    private Vector2 _slingShotLinesPosition;

    private Vector2 _direction;
    private Vector2 _directionNormalized;

    private bool _clickedWithInArea;
    private bool _birdOnSlingShot;

    private AngryBirdsAngieBird _spawnedAngieBird;

    private void Awake()
    {
        _leftLineRenderer.enabled = false;
        _rightLineRenderer.enabled = false;

        SpawnAngieBird();
    }
    private void Update()
    {
        if (AngryBirdsInputManager.WasLeftMouseButtonPressed && _slingShotArea.IsWithinSlingShotArea())
        {
            _clickedWithInArea = true;
        }
        if (AngryBirdsInputManager.IsLeftMousePressed && _clickedWithInArea && _birdOnSlingShot)
        {
            DrawSlingShot();
            PositionAndRotateAngieBird();
        }
        if (AngryBirdsInputManager.WasLeftMouseButtonReleased && _birdOnSlingShot && _clickedWithInArea)
        {
            if (AngryBirdsGameManager.instance.HasEnoughShots())
            {
                _clickedWithInArea = false;
                _birdOnSlingShot = false;

                _spawnedAngieBird.LaunchBird(_direction, _shotForce);
                AngryBirdsGameManager.instance.UseShot();                                      
                SetLines(_centerPosition.position);

                if (AngryBirdsGameManager.instance.HasEnoughShots())
                {

                    StartCoroutine(SpawnAngieBirdAfterTime());
                }

            }
        }
    }

    #region SlingShotMethods

    private void DrawSlingShot()
    {
    
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(AngryBirdsInputManager.MousePosition);

        _slingShotLinesPosition = _centerPosition.position+Vector3.ClampMagnitude(touchPosition-_centerPosition.position,_maxDistance);
   
        SetLines(_slingShotLinesPosition);

        _direction =(Vector2)_centerPosition.position - _slingShotLinesPosition;
        _directionNormalized = _direction.normalized;
    }


    private void SetLines(Vector2 position)
    {

        if (!_leftLineRenderer.enabled && !_rightLineRenderer.enabled)
        {
            _leftLineRenderer.enabled = true;
            _rightLineRenderer.enabled = true;
        }

        _leftLineRenderer.SetPosition(0,position);
        _leftLineRenderer.SetPosition(1, _leftStartPosition.position);

        _rightLineRenderer.SetPosition(0,position);
        _rightLineRenderer.SetPosition(1, _rightStartPosition.position); 
    }

    #endregion

    #region Angie Bird Methods

    private void SpawnAngieBird()
    {
        SetLines(_idlePosition.position);

        Vector2 dir = (_centerPosition.position - _idlePosition.position).normalized;
        Vector2 spawnPosition =(Vector2) _idlePosition.position + dir * _angieBirdPositionOffset;

       _spawnedAngieBird=Instantiate(_angieBirdPrefab, spawnPosition, Quaternion.identity);
        _spawnedAngieBird.transform.right = dir;

        _birdOnSlingShot = true;
    }

    private void PositionAndRotateAngieBird()
    {
        _spawnedAngieBird.transform.position = _slingShotLinesPosition + _directionNormalized * _angieBirdPositionOffset;
        _spawnedAngieBird.transform.right = _directionNormalized;
    }


    private IEnumerator SpawnAngieBirdAfterTime()
    {
        yield return new WaitForSeconds(_timeBetweenBirdRespawns);

        SpawnAngieBird();
    }
    #endregion
}