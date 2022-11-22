namespace GameA.Entities;

public class Player : Entity, ICollisionEntity
{
    [ConsoleVariable("player_speed")]
    public static float moveSpeed { get; set; } = 260f; 
    public Collider Collider { get; set; }
    public Size Size { get; set; }
    public Player(Vector2 pos) : base(pos)
    {
        Size = new(10, 10);
        Collider = new RectangleCollider(pos, new(10, 10));
        GameCore.CollisionManager.Register(this);
    }
    
    public override void Update(float delta)
    {
        Vector2 inputVector = new(0);

        if (Keyboard.IsKeyDown(KeyCode.S))
        {
            inputVector.Y += 1;
        }

        if (Keyboard.IsKeyDown(KeyCode.W))
        {
            inputVector.Y -= 1;
        }

        if (Keyboard.IsKeyDown(KeyCode.A))
        {
            inputVector.X -= 1;
        }

        if (Keyboard.IsKeyDown(KeyCode.D))
        {
            inputVector.X += 1;
        }

        if (inputVector != Vector2.Zero)
        {
           inputVector = Vector2.Normalize(inputVector); 
           Position += inputVector * (moveSpeed * delta);
        }

        Collider.Position = Position;
        GameCore.CollisionManager.ProcessMovement(this);
    }

    public override void Draw(RenderContext ctx)
    {
        ctx.Rectangle(ShapeMode.Fill, Position, new(10, 10), Color.Aqua);
    }

    public void OnCollision(ICollisionEntity other)
    {
        if (other is Wall w)
        {
            CollisionData data = Collider.GetCollisionData(other.Collider);
            Position -= data.Normal * data.Depths[0];
            Collider.Position = Position;
            //Comment above to re-introduce the funny "feature" that makes collisions slightly more visible
        }
    }

    private void DoAttack()
    {
        
    }
}