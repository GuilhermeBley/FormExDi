namespace FormExDi.Application.Args;

public interface IInitArgs
{
    char DefaultSeparator { get; }
    string QuestName { get; }
    int QuantityToRunQuest { get; }

    bool ContainsArgs(string arg);
    string GetArgFrom(string argLeft);
    string GetArgFrom(string argLeft, char separator);
}