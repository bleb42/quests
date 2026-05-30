using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestTracker : MonoBehaviour
{
    public event Action<QuestData, int> OnQuestStart;
    public event Action<QuestData, int> OnQuestProgress;
    public event Action<QuestData, int> OnQuestComplete;

    private Dictionary<QuestData, int> _currentQuests = new();

    public bool IsActive(QuestData quest) => _currentQuests.ContainsKey(quest);

    public void StartQuest(QuestData quest)
    {
        if (_currentQuests.ContainsKey(quest)) 
            return;

        _currentQuests[quest] = 0;
        OnQuestStart?.Invoke(quest, 0);
    }

    public void ProgressQuest(QuestData quest)
    {
        if (!_currentQuests.ContainsKey(quest)) 
            return;

        _currentQuests[quest]++;
        int current = _currentQuests[quest];
        OnQuestProgress?.Invoke(quest, current);

        if (current >= quest.TargetValue)
            EndQuest(quest);
    }

    private void EndQuest(QuestData quest)
    {
        int final = _currentQuests[quest];
        _currentQuests.Remove(quest);
        OnQuestComplete?.Invoke(quest, final);
    }
}