using CommandLine;

namespace PasswordValidatorApp.CmdLineArgsParser
{
    [Verb("validate", HelpText = "Validate passwords in batch mode")]
    internal class ValidateOptions
    {
        [Option(
            shortName: 'f',
            longName: "filename",
            Required = true,
            HelpText = "Set the path to the file containing passwords to validate"
            )]

        public string Filename { get; set; } = "";
    }
}
