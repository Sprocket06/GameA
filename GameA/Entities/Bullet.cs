namespace GameA.Entities;

public class Bullet : Entity, ICollisionEntity
{
    public Collider Collider { get; set; }
    public Vector2 Velocity { get; private set; }
    public float Damage { get; set; }
    
    public Bullet(Vector2 pos, Vector2 vel) : base(pos)
    {
        Velocity = vel;
        Collider = new CircleCollider(pos, 5);

        GameCore.CollisionManager.Register(this);
    }

    public override void Update(float delta)
    {
        Position += Vector2.Normalize(Velocity) * (Velocity.Length() * delta);
        Collider.Position = Position;
        GameCore.CollisionManager.ProcessMovement(this);
    }

    public override void Draw(RenderContext ctx)
    {
        ctx.Circle(ShapeMode.Fill, Position, 5, Color.Coral); 
    }
    
    public void OnCollision(ICollisionEntity other)
    {
        DeathMark = true;
        //Die();
    }

    public override void Die()
    {
        GameCore.CollisionManager.Deregister(this);
    }
}