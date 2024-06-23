using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DraggableComponent : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public event Action<PointerEventData> OnBeginDragHandler;
    public event Action<PointerEventData> OnDragHandler;
    public event Action<PointerEventData, bool> OnEndDragHandler;
    public bool FollowCursor { get; set; } = true;
    private Vector3 StartPosition;
    public bool CanDrag { get; set; } = true;

    private RectTransform rectTransform;
    private Canvas canvas;

    public PetController petController;
    public NeedsController needsController;
    //  [SerializeField]private AudioClip noSound;
    public int foodNumber;
    public int HappinessNumber;
    public int foodIndex;

    int counter = 0;
    [SerializeField] private GameObject boublePrefab;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!CanDrag)
        {
            return;
        }

        OnBeginDragHandler?.Invoke(eventData);
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (!CanDrag)
        {
            return;
        }

        OnDragHandler?.Invoke(eventData);

        if (FollowCursor)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }


        ///////////////////////////////////////////////////
        #region býcýbýcý
        if (!CanDrag)
        {
            return;
        }
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        DropArea dropArea = null;

        foreach (var result in results)
        {
            dropArea = result.gameObject.GetComponent<DropArea>();

            if (dropArea != null) { break; }
        }
        if (dropArea != null)
        {
            if (dropArea.Accepts(this))
            {
                
                if (gameObject.tag == ("Sponge"))
                {

                    //rectTransform.anchoredPosition = StartPosition;
                    OnEndDragHandler?.Invoke(eventData, false);
                    Debug.Log("býcýcýcýc");
              GameObject newBubble= Instantiate(boublePrefab, needsController.transform.position, transform.rotation);
               Destroy(newBubble,2f);


                    counter++;
                    if(counter%6==0)
                    SFXManager.instance.playClickSound();
                }
            }
        }
        #endregion
    }
    public void OnEndDrag(PointerEventData eventData)
    {

        if (!CanDrag)
        {
            return;
        }
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        DropArea dropArea = null;

        foreach (var result in results)
        {
            dropArea = result.gameObject.GetComponent<DropArea>();

            if (dropArea != null) { break; }
        }

        if (dropArea != null)
        {
            if (dropArea.Accepts(this))
            {
                #region sponge
                if (gameObject.tag==("Sponge"))
                {
                 
                    rectTransform.anchoredPosition = StartPosition;
                    OnEndDragHandler?.Invoke(eventData, false);
                  
                }
                #endregion 

              else  {
                    dropArea.Drop(this);
                    OnEndDragHandler?.Invoke(eventData, true);
                    gameObject.SetActive(false);
                    petController.Eat();
                    needsController.IncreaseFirstFOODThanHAPPINESS(foodNumber, HappinessNumber);
                    PlayerPrefs.SetInt("food" + foodIndex, PlayerPrefs.GetInt("food" + foodIndex) - 1);

                    rectTransform.anchoredPosition = StartPosition;
                    OnEndDragHandler?.Invoke(eventData, false);
                }
                return;
            }
        }

        rectTransform.anchoredPosition = StartPosition;
        OnEndDragHandler?.Invoke(eventData, false);
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        StartPosition = rectTransform.anchoredPosition;
    }


}
