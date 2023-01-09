using CommandLine;
using PasswordValidatorApp.CmdLineArgsParser;
using PasswordValidatorApp.Data.Repository;
using PasswordValidatorApp.Domain.StringsParser;
using PasswordValidatorApp.Domain.Validator;
using PasswordValidatorApp.Domain;
using PasswordValidatorApp.Utils;
using PasswordValidatorApp.Data.Entities;

namespace PasswordValidatorApp
{
    internal class Program
    {
        private static readonly CancellationTokenSource cts = new CancellationTokenSource();
        private static readonly CancellationToken cancellationToken = cts.Token;

        static async Task Main(string[] args)
        {
            // Completion handling on click Ctrl+C
            Console.CancelKeyPress += delegate (object? sender, ConsoleCancelEventArgs args) {
                cts.Cancel();
                args.Cancel = true;
            };

            await Parser.Default
                .ParseArguments<ValidateOptions>(args)
                .WithParsedAsync(async options => {
                    if (!string.IsNullOrEmpty(options.Filename))
                    {
                        try
                        {
                            await RunValidation(options.Filename, cancellationToken);
                        }
                        catch (TaskCanceledException)
                        {
                            Console.WriteLine("Execution was canceled.");
                            return;
                        }
                    }
                });
        }

        private static async Task RunValidation(string fileName, CancellationToken token)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File {fileName} doesn't exist. Check the path.");
                return;
            }

            Console.WriteLine("Validation process started.");

            if (token.IsCancellationRequested)
            {
                throw new TaskCanceledException();
            }

            var mainProcessor = new MainProcessor(
                new FileRepository(fileName, cancellationToken),
                new StringParser(
                    validationPattern: Constants.VALIDATION_PATTERN,
                    splitPattern: Constants.SPLIT_PATTERN
                    ),
                new PswValidator());

            var result = await mainProcessor.GetValidationResult();

            Console.WriteLine("Validation process finished.");

            ShowValidationResult(result);
        }

        private static void ShowValidationResult(ValidationResult result)
        {
            if (result.HasError)
            {
                Console.WriteLine("Errors occurred while processing the file:");
                var errorCounter = 1;
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($" {errorCounter}. {error}");
                    errorCounter++;
                }
            }
            else
            {
                Console.WriteLine("Validation process completed successfully.");
            }

            if (!result.ValidPasswords.Any())
            {
                Console.WriteLine("No valid password found.");
                return;
            }

            Console.WriteLine($"{result.ValidPasswords.Count} valid password(s) found:");
            foreach (var password in result.ValidPasswords)
            {
                Console.WriteLine($" {password}");
            }

            Console.WriteLine("Thanks for using PswValidatorApp :)");
        }

    }
}