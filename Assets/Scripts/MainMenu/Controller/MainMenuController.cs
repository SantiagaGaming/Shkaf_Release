using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private MainMenuUi _ui;
    [SerializeField] private SceneLoader _loader;
    [SerializeField] private SoundPlayer _soundPlayer;

    private string _mainScene = "Main";
    private void OnEnable()
    {
        _ui.TrainingButtonTapEvent += OnStartTrainingScene;
        _ui.PracticeButtonTapEvent += OnStartPracticeScene;
    }
    private void OnDisable()
    {
        _ui.TrainingButtonTapEvent -= OnStartTrainingScene;
        _ui.PracticeButtonTapEvent -= OnStartPracticeScene;
    }
    private void SetLoadingText(string value)
    {
        _ui.ShowLoadingText(value);
    }
    private void StartTrainingScene()
    {
        _loader.LoadScene(_mainScene);
    }
    private void OnStartTrainingScene()
    {
        _soundPlayer.PlayClickSound();
        _ui.ShowLoadingPanel();
        StartCoroutine(SetLoadingTextCo());
    }
    private void OnStartPracticeScene()
    {
        _soundPlayer.PlayClickSound();

    }
    private IEnumerator SetLoadingTextCo()
    {
        SetLoadingText("Загрузка");
        yield return new WaitForSeconds(0.3f);
        SetLoadingText("Загрузка.");
        yield return new WaitForSeconds(0.3f);
        SetLoadingText("Загрузка..");
        yield return new WaitForSeconds(0.3f);
        SetLoadingText("Загрузка...");
        yield return new WaitForSeconds(0.3f);
        StartTrainingScene();
    }

}
