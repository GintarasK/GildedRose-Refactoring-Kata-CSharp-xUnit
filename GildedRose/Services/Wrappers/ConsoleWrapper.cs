using System;

namespace GildedRoseKata.Services.Wrappers;

internal class ConsoleWrapper : IConsoleWrapper
{
    public ConsoleKeyInfo ReadKey(bool intercept) => Console.ReadKey(intercept);

    public void Write(char value) => Console.Write(value);
}