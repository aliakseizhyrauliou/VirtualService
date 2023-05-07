using System.Diagnostics;

namespace VirtualServiceWeb.Services;

public class CoreService
{
    public string StartScript()
    {
        string scriptDirectory = "/home/alex/Repos/VirtualService/PythonCore";

        // Путь до скрипта
        string scriptPath = Path.Combine(scriptDirectory, "vagrantGeneration.py");

        // Аргументы командной строки для запуска скрипта
        string arguments = $"{scriptPath}";

        // Создаем процесс и запускаем скрипт
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "python3",
                Arguments = arguments,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = scriptDirectory
            }
        };
        
        
        process.Start();
        process.WaitForExit();

        // Получаем вывод скрипта
        string output = process.StandardOutput.ReadToEnd();

        return output;
    }
}