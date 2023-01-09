using CommandLine;
using PasswordValidatorApp.CmdLineArgsParser;

namespace PasswordValidatorApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Parser.Default
                .ParseArguments<ValidateOptions>(args)
                .WithParsedAsync(async options => {
                    if (!string.IsNullOrEmpty(options.Filename))
                    {
                        await RunValidation(options.Filename);
                    }
                });
        }

        private static async Task RunValidation(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} doesn't exist. Check the path.");
                return;
            }

            try
            {
                using (var reader = File.OpenText(fileName))
                {
                    var fileText = await reader.ReadToEndAsync();

                    var stringArray = fileText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    foreach (var item in stringArray)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}