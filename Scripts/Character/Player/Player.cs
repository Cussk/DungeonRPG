using DungeonRpg.Scripts.General;
using Godot;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer animationPlayerNode;
    [Export] public Sprite3D spriteNode;
    
    public Vector2 playerDirection;
    float _playerSpeed = 5;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(playerDirection.X, 0 , playerDirection.Y);
        Velocity *= _playerSpeed;

        MoveAndSlide();
        Flip();
    }

    public override void _Input(InputEvent @event)
    {
        playerDirection = Input.GetVector
            (GlobalConstants.INPUT_MOVE_LEFT, GlobalConstants.INPUT_MOVE_RIGHT, 
            GlobalConstants.INPUT_MOVE_BACKWARD, GlobalConstants.INPUT_MOVE_FORWARD);
    }

    void Flip()
    {
        var isNotMovingHorizontally = Velocity.X == 0;
        
        if(isNotMovingHorizontally) return;
        
        var isMovingLeft = Velocity.X < 0;
        spriteNode.FlipH = isMovingLeft;
    }
}
