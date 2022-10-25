namespace GameA.Scenes.SceneManagement;

public abstract class Scene
{
    protected List<Entity> Entities;

    public void DestroyEntity(Entity e)
    {
        Entities.Remove(e);
    }

    public void AddEntity(Entity e)
    {
        Entities.Add(e);
    }

    public void AddEntity<T>() where T : Entity, new() 
    {
       Entities.Add(new T()); 
    }

    public virtual void LoadStep()
    {
    }

    public virtual int GetLoadSteps() => 0;

    public virtual void Draw(RenderContext context)
    {
    }

    public virtual void Update(float delta)
    {
    }

    /*
     Event callbacks for the custom control system built for Owoguelike.
     leaving this in the template in case I want to use that same control system in other games, as it is quite based.
    public virtual void ButtonControlPressed(ButtonControlEventArgs e)
    {
        
    }

    public virtual void ButtonControlReleased(ButtonControlEventArgs e)
    {
        
    }

    public virtual void AxisControlMoved(AxisControlEventArgs e)
    {
        
    }*/

    public virtual void MouseMoved(MouseMoveEventArgs e)
    {
    }

    public virtual void MousePressed(MouseButtonEventArgs e)
    {
    }

    public virtual void MouseReleased(MouseButtonEventArgs e)
    {
    }

    public virtual void WheelMoved(MouseWheelEventArgs e)
    {
    }

    public virtual void KeyPressed(KeyEventArgs e)
    {
    }

    public virtual void KeyReleased(KeyEventArgs e)
    {
    }

    public virtual void TextInput(TextInputEventArgs e)
    {
    }

    public virtual void ControllerConnected(ControllerEventArgs e)
    {
    }

    public virtual void ControllerDisconnected(ControllerEventArgs e)
    {
    }

    public virtual void ControllerButtonPressed(ControllerButtonEventArgs e)
    {
    }

    public virtual void ControllerButtonReleased(ControllerButtonEventArgs e)
    {
    }

    public virtual void ControllerAxisMoved(ControllerAxisEventArgs e)
    {
    }
}