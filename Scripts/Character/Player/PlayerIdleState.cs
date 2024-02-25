using DungeonRpg.Scripts.General;
using Godot;

public partial class PlayerIdleState : Node
{
    Player _characterNode;
    
    public override void _Ready()
    {
        _characterNode = GetOwner<Player>();
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            _characterNode.animationPlayerNode.Play(GlobalConstants.ANIM_IDLE);
        }
    }
}
