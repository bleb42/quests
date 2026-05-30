using UnityEngine;

[RequireComponent(typeof(QuestTracker), typeof(QuestView))]
public class QuestPresenter : MonoBehaviour
{
    private QuestTracker _tracker;
    private QuestView _view;

    private void Awake()
    {
        _tracker = GetComponent<QuestTracker>();
        _view = GetComponent<QuestView>();
    }

    private void OnEnable()
    {
        _tracker.OnQuestStart += OnQuestStart;
        _tracker.OnQuestProgress += OnQuestProgress;
        _tracker.OnQuestComplete += OnQuestComplete;
    }

    private void OnDisable()
    {
        _tracker.OnQuestStart -= OnQuestStart;
        _tracker.OnQuestProgress -= OnQuestProgress;
        _tracker.OnQuestComplete -= OnQuestComplete;
    }

    private void OnQuestStart(QuestData data, int currentValue)
    {
        _view.AddQuest(data);
    }

    private void OnQuestProgress(QuestData data, int currentValue)
    {
        _view.UpdateQuest(data, currentValue);
    }

    private void OnQuestComplete(QuestData data, int currentValue)
    {
        _view.CompleteQuest(data);
    }
}