using System;

namespace GildedRoseKata.Services.Wrappers;

public interface IConsoleWrapper
{
    ConsoleKeyInfo ReadKey(bool intercept) => Console.ReadKey(intercept);

    void Write(char value) => Console.Write(value);
}