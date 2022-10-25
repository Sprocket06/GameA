using Color = System.Drawing.Color;

namespace GameA.Entities;

public class Player : Entity
{
    public float moveSpeed { get; set; } = 400f;
    
    public Player(Vector2 pos) : base(pos)
    {
        
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
    }

    public override void Draw(RenderContext ctx)
    {
        ctx.Rectangle(ShapeMode.Fill, Position, new(10, 10), Color.Aqua);
    }
}