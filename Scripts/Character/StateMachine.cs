using Godot;

public partial class StateMachine : Node
{
    [Export] Node currentState;
    [Export] Node[] states;

    public override void _Ready()
    {
        currentState.Notification(5001);
    }
}
