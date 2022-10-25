namespace GameA.Scenes;

public class GameplayScene : Scene
{
    public GameplayScene()
    { 
        Entities = new List<Entity>();
        Entities.Add(new Player(new(100, 100)));
    }

    public override void Draw(RenderContext context)
    {
        foreach(Entity e in Entities)
        {
           e.Draw(context); 
        }
    }

    public override void Update(float delta)
    {
        foreach (Entity e in Entities)
        {
            e.Update(delta);
        }
    }
}