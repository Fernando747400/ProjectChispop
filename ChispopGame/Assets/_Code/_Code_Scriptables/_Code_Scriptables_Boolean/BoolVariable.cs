using UnityEngine;

[CreateAssetMenu(menuName = "Game/MainMenu/Bool")]
public class BoolVariable : ScriptableObject
{
    public string DeveloperDescription;
    public bool Value;
    public bool defaultValue;

    public void SetValue(bool value)
    {
        Value = value;
        SetDirty();
    }
}
