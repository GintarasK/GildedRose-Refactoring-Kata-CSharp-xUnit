using System;
using System.Text;

using GildedRoseKata.Services.Wrappers;

namespace GildedRoseKata.Services;

// NOTE: If there is a need to use UI/Web API remove ConsoleService and Create Views/Controllers.
internal class ConsoleService(IConsoleWrapper consoleWrapper)
    : IConsoleService
{
    public (bool Escape, string Line) ReadLineWithEscape()
    {
        string result;

        StringBuilder buffer = new();

        var info = consoleWrapper.ReadKey(true);
        while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape)
        {
            consoleWrapper.Write(info.KeyChar);
            buffer.Append(info.KeyChar);
            info = consoleWrapper.ReadKey(true);
        }

        switch (info.Key)
        {
            case ConsoleKey.Enter:
                result = buffer.ToString();
                break;
            case ConsoleKey.Escape:
                return (true, null);
            default:
                throw new ArgumentOutOfRangeException();
        }

        return (false, result);
    }
}