namespace GameA.Entities;

public class Wall : Entity, ICollisionEntity
{
    public Collider Collider { get; set; }
    public Vector2 Size { get; set; }
    public Wall(Vector2 pos, Vector2 size) : base(pos)
    {
        Collider = new RectangleCollider(pos, size);
        Size = size;
        GameCore.CollisionManager.Register(this);
    }

    public override void Draw(RenderContext ctx)
    {
        ctx.Rectangle(ShapeMode.Fill, Position, Size.X, Size.Y, Color.Gray);
    }
    
    public void OnCollision(ICollisionEntity other)
    {
        
    }
}