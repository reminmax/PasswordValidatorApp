namespace PasswordValidatorApp.Data.Repository
{
    public class FileRepository : IRepository
    {
        private readonly string _fileName;
        private readonly CancellationToken _token;

        public FileRepository(string fileName, CancellationToken token)
        {
            _fileName = fileName;
            _token = token;
        }

        public async Task<IEnumerable<string>> GetDataForValidation()
        {
            try
            {
                using (var reader = File.OpenText(_fileName))
                {
                    var fileText = await reader.ReadToEndAsync(_token);
                    
                    if (_token.IsCancellationRequested)
                    {
                        throw new TaskCanceledException();
                    }

                    var stringArray = fileText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    return stringArray;
                }
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Execution was canceled.");
                return new string[0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new string[0];
            }
        }
    }
}
