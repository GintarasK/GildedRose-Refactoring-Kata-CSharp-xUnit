namespace GildedRoseKata.Services;

internal interface IConsoleService
{
    void DisplayItems(int day);

    (bool Escape, string Line) ReadLineWithEscape();
}