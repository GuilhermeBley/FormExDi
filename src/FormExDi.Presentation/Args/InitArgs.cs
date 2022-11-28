using FormExDi.Application.Args;

namespace FormExDi.Presentation.Args;

internal class InitArgs : IInitArgs
{
    private string[] _args;

    private IEnumerable<string> _argsToUpper => _args.Skip(1).Select(arg => arg.ToUpper());

    public InitArgs(string[] args)
    {
        if (args is null)
        {
            _args = new string[0];
            return;
        }

        _args = args;
    }

    public char DefaultSeparator => ':';

    public string QuestName => _args.Length > 0 ? _args[1] : string.Empty;

    public int QuantityToRunQuest => int.TryParse(_args[2], out int n) ? n : n;

    public bool ContainsArgs(string arg)
    {
        if (_argsToUpper.Contains(arg.ToUpper()))
            return true;

        return false;
    }

    public string GetArgFrom(string argLeft)
    {
        return GetArgFrom(argLeft, DefaultSeparator);
    }

    public string GetArgFrom(string argLeft, char separator)
    {
        foreach (string completeArg in _argsToUpper)
        {
            if (!completeArg.Contains(argLeft + separator))
                continue;

            string[] splitLeftRigh = completeArg.Split(separator);

            if (splitLeftRigh.Length != 2)
                continue;

            return splitLeftRigh.Last();
        }

        return string.Empty;
    }
}

