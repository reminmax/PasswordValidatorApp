using CommandLine;
using PasswordValidatorApp.CmdLineArgsParser;
using PasswordValidatorApp.Data.Repository;

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

            var repository = new FileRepository(fileName);

            var stringCollection = await repository.GetDataForValidation();
            if (!stringCollection.Any())
            {
                Console.WriteLine("Specified file is empty. There is nothing to validate.");
            }

            foreach (var line in stringCollection)
            {
                Console.WriteLine(line);
            }
        }
    }
}