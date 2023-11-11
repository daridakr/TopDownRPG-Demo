using UnityEngine;

[RequireComponent (typeof(NPC))]
public class DialogNPC : MonoBehaviour, IInteracting
{
    [SerializeField] private InteractionType _interactionType;
    [SerializeField] private Dialog _dialog;
    [SerializeField] private string _answer;
    [SerializeField] private Sprite _avatar;

    private string _npcName;

    public InteractionType InteractionType { get => _interactionType; set => _interactionType = value; }
    public string Answer => _answer;
    public Sprite Avatar => _avatar;

    private void Awake()
    {
        _npcName = GetComponent<NPC>().Name;
    }

    public void Interact()
    {
        _dialog.StartDialogWith(new DialogTarget(_npcName, _avatar, _answer));
    }
}

public class DialogTarget
{
    private string _name;
    private Sprite _avatar;
    private string _answer;

    public string Name => _name;
    public Sprite Sprite => _avatar;
    public string Answer => _answer;

    public DialogTarget(string name, Sprite avatar, string answer)
    {
        _name = name;
        _avatar = avatar;
        _answer = answer;
    }
}
