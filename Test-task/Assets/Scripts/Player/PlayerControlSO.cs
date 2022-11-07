using UnityEngine;

[CreateAssetMenu(fileName = "Control", menuName = "Player/Control")]
public class PlayerControlSO : ScriptableObject
{
    [SerializeField] private KeyCode up;

    public KeyCode Up => up;
}
