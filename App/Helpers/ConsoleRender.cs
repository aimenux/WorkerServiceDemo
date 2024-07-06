using App.Models;
using Spectre.Console;

namespace App.Helpers;

public class ConsoleRender : IConsoleRender
{
    public void RenderMessage(string message)
    {
        var rule = new Rule($"[olive]{message}[/]")
        {
            Border = BoxBorder.Double
        };
        rule.Centered();
        AnsiConsole.WriteLine();
        AnsiConsole.Write(rule);
    }

    public void RenderFeatures(string title, Features features)
    {
        const int defaultWidth = 50;
        var one = nameof(Features.One).ToUpper();
        var two = nameof(Features.Two).ToUpper();

        var table = new Table()
            .Border(TableBorder.Square)
            .BorderColor(Color.White)
            .Title($"[yellow]{title}[/]")
            .AddColumn(new TableColumn($"[green]{one}[/]").Centered())
            .AddColumn(new TableColumn($"[green]{two}[/]").Centered())
            .AddRow(features.One, features.Two);
        table.Width = defaultWidth;

        AnsiConsole.WriteLine();
        AnsiConsole.Write(table);
    }
}