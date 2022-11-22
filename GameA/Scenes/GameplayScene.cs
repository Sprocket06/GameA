namespace GameA.Scenes;

public class GameplayScene : Scene
{
    private Player _player;
    private List<Entity> _entityQueue = new();
    private List<Entity> _entityRemovalQueue = new();
    private List<Raycast> iveGotThemInMySights;

    public GameplayScene()
    {
        Entities = new List<Entity>();
        _player = new Player(new(100, 100));
        Entities.Add(_player);
        Entities.Add(new Wall(new(200, 200), new(20, 60)));
        Entities.Add(new Wall(new(400, 200), new(20, 60)));
    }

    public override void Draw(RenderContext context)
    {
        foreach (Entity e in Entities)
        {
            e.Draw(context);
        }

        iveGotThemInMySights.Sort((a, b) =>
        {
            if (a.Length < b.Length) return -1;
            if (a.Length > b.Length) return 1;
            return 0;
        });

        //first item in the list *should* be the player
        iveGotThemInMySights.RemoveAt(0);

        if (iveGotThemInMySights.Count > 0)
        {
            Raycast r = iveGotThemInMySights[0];

            if (r.Entity.Collider is CircleCollider c)
            {
                context.Circle(ShapeMode.Stroke, c.Position, c.Radius, Color.Red);
            }
            else if (r.Entity.Collider is RectangleCollider rect)
            {
                context.Rectangle(ShapeMode.Stroke, rect.Position, rect.Size.X, rect.Size.Y, Color.Red);
            }
        }

        /*foreach (Raycast r in iveGotThemInMySights)
        {
            /*if (r.Entity is Player)
            {
                // skip
            }
            //else
            {
                if (r.Entity.Collider is CircleCollider c)
                {
                    context.Circle(ShapeMode.Stroke, c.Position, c.Radius, Color.Red);
                }
                else if (r.Entity.Collider is RectangleCollider rect)
                {
                    context.Rectangle(ShapeMode.Stroke, rect.Position, rect.Size.X, rect.Size.Y, Color.Red);
                }
            }
        }*/
    }

    public override void Update(float delta)
    {
        /*foreach (var entity in _entityQueue)
        {
            Entities.Add(entity);
        }*/

        Vector2 mPos = Mouse.GetPosition();

        // draw line from player to mouse, raycast on said line
        // treat player as origin
        Vector2 relativeMousePos = mPos - _player.Position;
        // normalize because we just care about the angle
        relativeMousePos = Vector2.Normalize(relativeMousePos);

        Ray aimRay = new Ray(_player.Position + (new Vector2(5,5)), relativeMousePos, 1000);
        iveGotThemInMySights = GameCore.CollisionManager.Raycast(aimRay);

        foreach (Entity e in Entities.ToList())
        {
            if (e.DeathMark) continue;
            e.Update(delta);
        }

        foreach (Entity e in Entities.ToList())
        {
            if (e.DeathMark)
            {
                Entities.Remove(e);
                e.Die();
            }
        }
    }

    public override void MousePressed(MouseButtonEventArgs e)
    {
        if (e.Button == MouseButton.Left)
        {
            Vector2 direction = Vector2.Normalize(e.Position - _player.Position);
            Vector2 bulletPos = new Vector2(_player.Position.X + 5, _player.Position.Y + 5) + (direction * 20);
            Bullet b = new Bullet(bulletPos, direction * 150);
            //_entityQueue.Add(b);
            Entities.Add(b);
        }
    }
}