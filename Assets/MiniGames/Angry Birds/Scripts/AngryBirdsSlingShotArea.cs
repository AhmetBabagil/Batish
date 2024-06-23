
using UnityEngine;using UnityEngine.InputSystem;

public class AngryBirdsSlingShotArea : MonoBehaviour
{


    [SerializeField] private LayerMask _slingShotAreaMask;

    public bool IsWithinSlingShotArea()
    {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(AngryBirdsInputManager.MousePosition);


        if (Physics2D.OverlapPoint(worldPosition,_slingShotAreaMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
