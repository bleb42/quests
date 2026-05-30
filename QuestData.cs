using UnityEngine;

[CreateAssetMenu(menuName = "Quest/Quest")]
public class QuestData : ScriptableObject
{
    [SerializeField] private string _id;
    [SerializeField] private string _displayName;
    [SerializeField] private string _description;
    [SerializeField] private int _targetValue;

    public string Id => _id;
    public string DisplayName => _displayName;
    public string Description => _description;
    public int TargetValue => _targetValue;

    private void OnValidate()
    {
        if (string.IsNullOrEmpty(_id))
            _id = System.Guid.NewGuid().ToString();
    }
}