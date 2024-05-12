using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    public event Action LevelUp;

    [SerializeField] private float _experience = 0;
    [SerializeField] private float _nextLevelExperience;

    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private Image _experienceScale;

    [SerializeField] private EffectsManager _effectsManager;

    [SerializeField] private AnimationCurve _experienceCurve;
    [SerializeField] private float _timeBeforShowCards = 1.5f;

    private int _level = -1;

    private void Awake()
    {
        _nextLevelExperience = _experienceCurve.Evaluate(0);
    }

    public void AddExperience(int value)
    {
        _experience += value;

        if (_experience >= _nextLevelExperience)
        {
            StartCoroutine(UpLevelCoroutine(_timeBeforShowCards));
        }

        DisplayExperience();
    }

    public void UpLevel()
    {
        StartCoroutine(UpLevelCoroutine(0));
    }

    private IEnumerator UpLevelCoroutine(float timeBeforShowCards)
    {
        _level++;
        _levelText.text = _level.ToString();

        LevelUp?.Invoke();

        _experience = 0;
        _nextLevelExperience = _experienceCurve.Evaluate(_level);

        yield return new WaitForSeconds(timeBeforShowCards);

        _effectsManager.ShowCards();

        //Time.timeScale = 0;
    }

    private void DisplayExperience()
    {
        _experienceScale.fillAmount = _experience / _nextLevelExperience;
    }
}
