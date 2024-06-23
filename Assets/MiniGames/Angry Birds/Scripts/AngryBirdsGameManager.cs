using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AngryBirdsGameManager : MonoBehaviour
{
    [SerializeField] private ADManager ADManager;
    public static AngryBirdsGameManager instance;

    public int MaxNumberOfShots = 3;
    [SerializeField] private float _secondsToWaitBeforeDeathCheck = 3f;
    [SerializeField] private GameObject _restartScreenObject;
    [SerializeField] private AngryBirdsSlingShotHandler _slingShotHandler;
    private int _usedNumberOfShots;

    private AngryBirdsIconHandler _iconHandler;

    private List<AngryBirdsBaddie> _baddies= new List<AngryBirdsBaddie>();

    [SerializeField] private GameObject[] BuildingsArr;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        BuildingsArr[Random.Range(0,BuildingsArr.Length-1)].gameObject.SetActive(true);
    }

    private void Start()
    {
        _iconHandler = FindObjectOfType<AngryBirdsIconHandler>();

        AngryBirdsBaddie[] baddies = FindObjectsOfType<AngryBirdsBaddie>();
        for (int i = 0; i < baddies.Length; i++)
        {
            _baddies.Add(baddies[i]);
        }
    }
    public void UseShot()
    {
        _usedNumberOfShots++;
        _iconHandler.UseShot(_usedNumberOfShots);
 
        CheckForLastShot();
    }
    public bool HasEnoughShots()
    {
        if(_usedNumberOfShots < MaxNumberOfShots )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CheckForLastShot()
    {
        if(_usedNumberOfShots== MaxNumberOfShots )
        {
            StartCoroutine(CheckAfterWaitTime());   
        }
    }

    private IEnumerator CheckAfterWaitTime()
    {
        yield return new WaitForSeconds(_secondsToWaitBeforeDeathCheck);

        if (_baddies.Count == 0)
        {
            WinGame();
        }
        else
        {
            ReStartGame();
        }
    }

    public void RemoveBaddie(AngryBirdsBaddie baddie)
    {
        _baddies.Remove(baddie);
        CheckForAllDeadBadies();
    }

    private void CheckForAllDeadBadies()
    {
        if (_baddies.Count == 0)
        {
            WinGame();
        }
    }
    #region win / lose
   
    public void WinGame()
    {
        _restartScreenObject.SetActive(true);
        _slingShotHandler.enabled = false;
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 10);
        PlayerPrefs.SetInt("xp", PlayerPrefs.GetInt("xp") + 10);
    }

    public void ReStartGameWithoutADS()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReStartGame()
    {
        Debug.Log("lose");
        ADManager.GecisReklamiGoster();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    #endregion
}
