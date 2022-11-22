using Chroma.Diagnostics.Logging.Sinks;
using GameA.CommanderExtensions;

namespace GameA;

public class GameCore : Game
{
    [ConsoleVariable("show_collision_shapes")]
    public static bool ShowCollisionShapes { get; set; } = false;
    
    public static Log Log { get; private set; }
    public static CollisionManager CollisionManager { get; private set; } = new();
    private readonly DebugConsole _console;
    private Cursor _cursor;

    public GameCore() : base(new(false, false))
    {
        Log = LogManager.GetForCurrentAssembly();
        _console = new DebugConsole(this.Window);
        _console.RegisterStaticEntities();
        Log.SinkTo(new CommanderSink(_console));
        SceneManager.SetActiveScene<GameplayScene>();
    }

    protected override void LoadContent()
    {
        _cursor = Content.Load<Cursor>("crosshair.png");
        _cursor.SetCurrent();
    }
    protected override void Draw(RenderContext context)
    {
        SceneManager.ActiveScene?.Draw(context);
        if (ShowCollisionShapes)
        {
            foreach (ICollisionEntity e in CollisionManager.Entities)
            {
                if (e.Collider is CircleCollider c)
                {
                    context.Circle(ShapeMode.Stroke, c.Position, c.Radius, Color.Red);
                }

                if (e.Collider is RectangleCollider r)
                {
                    context.Rectangle(ShapeMode.Stroke, r.Position, r.Size.X, r.Size.Y, Color.Red);
                }
                    
            }
        }
        _console.Draw(context);
    }

    protected override void Update(float delta)
    {
        if(!_console.IsOpen)
            SceneManager.ActiveScene?.Update(delta);
        _console.Update(delta);
    }

    protected override void MouseMoved(MouseMoveEventArgs e)
    {
        SceneManager.ActiveScene?.MouseMoved(e);
    }

    protected override void MousePressed(MouseButtonEventArgs e)
    {
        SceneManager.ActiveScene?.MousePressed(e);
    }

    protected override void MouseReleased(MouseButtonEventArgs e)
    {
        SceneManager.ActiveScene?.MouseReleased(e);
    }

    protected override void WheelMoved(MouseWheelEventArgs e)
    {
        SceneManager.ActiveScene?.WheelMoved(e);
    }

    protected override void KeyPressed(KeyEventArgs e)
    {
        _console.KeyPressed(e);
        if(!_console.IsOpen)
            SceneManager.ActiveScene?.KeyPressed(e);
    }

    protected override void KeyReleased(KeyEventArgs e)
    {
        SceneManager.ActiveScene?.KeyReleased(e);
    }

    protected override void TextInput(TextInputEventArgs e)
    {
        _console.TextInput(e);
        SceneManager.ActiveScene?.TextInput(e);
    }
}