using App.Models;

namespace App.Helpers;

public interface IConsoleRender
{
    void RenderMessage(string message);
    void RenderFeatures(string title, Features features);
}