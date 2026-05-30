using TMPro;
using UnityEngine;

public class QuestPanel : MonoBehaviour
{
    private const string StartValue = "0";

    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _currentValue;
    [SerializeField] private TMP_Text _targetValue;

    public void Initialize(QuestData questData)
    {
        _name.text = questData.Name;
        _description.text = questData.Description;
        _currentValue.text = StartValue;
        _targetValue.text = questData.TargetValue.ToString();
    }

    public void UpdateValues(QuestData questData, int currentValue)
    {
        _currentValue.text = currentValue.ToString();
    }

    public void CompleteQuest()
    {
        _description.text = "Ended";
    }
}