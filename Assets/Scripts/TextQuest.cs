using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Serializable]
public class Action
{
    public string Description;
    public byte Index;
    public UnityEvent OnAnswered;
}

[Serializable]
public class Room
{
    [TextArea(3, 10)]
    public string[] Description;
    public Action[] Actions;

    public Sprite BG;

    //public AudioClip Clip;
}

public class TextQuest : MonoBehaviour
{
    /*
    Bad code!
    
    public TMP_Text RoomDesc;
    public Button[] ActionButtons;
    */

    [SerializeField]
    private TMP_Text _roomDesc;

    [SerializeField]
    private Button[] _actionButtons;

    [SerializeField]
    private TMP_Text[] _actionTexts;

    [SerializeField]
    private Image _background;

    //[SerializeField]
    //private AudioSource _bgAudio;

    [SerializeField]
    private AudioSource _clickAudio;

    //[SerializeField] private AudioSource clickClip;
    /*
     ????????? ???????? ???????

    ??????? = [
        '???????? ???????',
        ['????????1', ??????_???????],
        ['????????2', ??????_???????],
    ]
     */
    [SerializeField] private InformationManager informationManager;
    [SerializeField] private InformationWindow informationWindow;
    [SerializeField] private Stress stress;

    [SerializeField]
    private Room[] _roomInfo;

    [SerializeField]
    private int _currentIndex = 0;


    private void SetRoomInfo()
    {
        var currentRoom = _roomInfo[_currentIndex];
        var currentRoomActions = currentRoom.Actions;

        //_roomDesc.text = currentRoom.Description;
        informationWindow.SetStartHeight();
        TriggerInformation();
        _background.sprite = currentRoom.BG;

        for (var i = 0; i < _actionButtons.Length; i++)
        {
            _actionButtons[i].gameObject.SetActive(false);
        }

        for (var i = 0; i < currentRoomActions.Length; i++)
        {
            _actionTexts[i].text = currentRoomActions[i].Description;

            _actionButtons[i].interactable = false;
        }

        //_bgAudio.clip = currentRoom.Clip;
        //_bgAudio.Play();
    }

    private void EndGame()
    {
        _roomDesc.text = "?? ?????? ?????? ????? ????????. ????? ????? ????!";

        for (var i = 0; i < _actionButtons.Length; i++)
        {
            _actionButtons[i].gameObject.SetActive(false);
        }
        _actionButtons[0].gameObject.SetActive(true);
        _actionTexts[0].text = "?????? ??????";

        _actionButtons[0].onClick.RemoveAllListeners();
        _actionButtons[0].onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name));
    }

    private void OnActionButton(byte index)
    {
        var currentAction = _roomInfo[_currentIndex].Actions[index];


        if (currentAction.Description == "[Атаковать]" && stress.StressCount >= 10)
        {
            _currentIndex = 29;
        }
        else      
        _currentIndex = currentAction.Index;
        
        //clickClip.Play();

        currentAction.OnAnswered.Invoke();

        if (_currentIndex >= _roomInfo.Length)
            EndGame();
        else
            SetRoomInfo();
        Save();
    }


    private void Start()
    {
        Load();
        informationWindow.SetStartHeight();
        SetRoomInfo();

        for (byte i = 0; i < _actionButtons.Length; i++)
        {
            var index = i;
            _actionButtons[i].onClick.AddListener(() => OnActionButton(index));
        }
    }

    private void TriggerInformation()
    {
        var currentRoom = _roomInfo[_currentIndex];
        informationManager.ShowInformation(currentRoom);
    }

    public void ActiveInteractable()
    {
        var currentRoom = _roomInfo[_currentIndex];
        var currentRoomActions = currentRoom.Actions;
        for (var i = 0; i < currentRoomActions.Length; i++)
        {
            _actionButtons[i].gameObject.SetActive(true);
            _actionButtons[i].interactable = true;
        }
    }


    private void Save()
    {
        PlayerPrefs.SetInt("currentIndex", _currentIndex);
    }
    private void Load()
    {
        _currentIndex = PlayerPrefs.GetInt("currentIndex", _currentIndex);
    }

    public void Restart()
    {
        _currentIndex = 0;
        Save();
    }
}