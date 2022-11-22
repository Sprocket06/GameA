namespace GameA.Entities;

public abstract class Entity
{
    public Vector2 Position { get; set; }
    public bool DeathMark { get; set; } = false;
    public bool Solid { get; set; } = false;

    public Entity(Vector2 pos)
    {
        Position = pos;
    }

    public virtual void Update(float delta)
    {
        
    }

    public virtual void Draw(RenderContext ctx)
    {
        
    }

    public virtual void Die()
    {
        
    }
}  