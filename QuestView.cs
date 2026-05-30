using System.Collections.Generic;
using UnityEngine;

public class QuestView : MonoBehaviour
{
    [SerializeField] private GameObject _questsListPanel;
    [SerializeField] private QuestPanel _questPanelPrefab;

    private Dictionary<QuestData, QuestPanel> _currentQuests;

    private void Awake()
    {
        _currentQuests = new Dictionary<QuestData, QuestPanel>();
    }

    public void AddQuest(QuestData data)
    {
        QuestPanel newQuest = Instantiate(_questPanelPrefab, _questsListPanel.transform);
        newQuest.Initialize(data);
        _currentQuests.Add(data, newQuest);
    }

    public void UpdateQuest(QuestData data, int currentValue)
    {
        if (_currentQuests.ContainsKey(data) == false)
            return;

        _currentQuests[data].UpdateValues(data, currentValue);
    }

    public void CompleteQuest(QuestData data)
    {
        if (_currentQuests.TryGetValue(data, out QuestPanel panel) == false) 
            return;

        _currentQuests[data].CompleteQuest();
        _currentQuests.Remove(data);
    }
}