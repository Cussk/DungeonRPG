using DungeonRpg.Scripts.General;
using Godot;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] AnimationPlayer _animationPlayerNode;
    [Export] Sprite3D _spriteNode;
    
    Vector2 _playerDirection;
    float _playerSpeed = 5;

    public override void _Ready()
    {
        
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(_playerDirection.X, 0 , _playerDirection.Y);
        Velocity *= _playerSpeed;

        MoveAndSlide();
        Flip();
    }

    public override void _Input(InputEvent @event)
    {
        _playerDirection = Input.GetVector
            (GlobalConstants.INPUT_MOVE_LEFT, GlobalConstants.INPUT_MOVE_RIGHT, 
            GlobalConstants.INPUT_MOVE_BACKWARD, GlobalConstants.INPUT_MOVE_FORWARD);

        _animationPlayerNode.Play(_playerDirection == Vector2.Zero ? GlobalConstants.ANIM_IDLE : GlobalConstants.ANIM_MOVE);
    }

    void Flip()
    {
        var isNotMovingHorizontally = Velocity.X == 0;
        
        if(isNotMovingHorizontally) return;
        
        var isMovingLeft = Velocity.X < 0;
        _spriteNode.FlipH = isMovingLeft;
    }
}
