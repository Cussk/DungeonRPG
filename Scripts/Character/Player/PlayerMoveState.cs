using DungeonRpg.Scripts.General;
using Godot;

public partial class PlayerMoveState : Node
{
    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            var characterNode = GetOwner<Player>();
            characterNode.animationPlayerNode.Play(GlobalConstants.ANIM_MOVE);
        }
    }
}
