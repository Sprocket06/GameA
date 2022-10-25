using Chroma.Diagnostics.Logging.Base;

namespace GameA.CommanderExtensions;

public class CommanderSink : Sink
{
    private DebugConsole _console;

    public CommanderSink(DebugConsole console)
    {
        _console = console;
    }

    public override void Write(LogLevel logLevel, string message, params object[] args)
    {
        _console.Print($"[{logLevel.ToString()}] {message}");
    }
}