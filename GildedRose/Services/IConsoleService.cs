namespace GildedRoseKata.Services;

internal interface IConsoleService
{
    (bool Escape, string Line) ReadLineWithEscape();
}