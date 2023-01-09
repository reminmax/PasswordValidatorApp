using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorApp.Data.Repository
{
    public class FileRepository : IRepository
    {
        private readonly string _fileName;

        public FileRepository(string fileName)
        {
            _fileName = fileName;
        }

        public async Task<IEnumerable<string>> GetDataForValidation()
        {
            try
            {
                using (var reader = File.OpenText(_fileName))
                {
                    var fileText = await reader.ReadToEndAsync();

                    var stringArray = fileText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    return stringArray;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new string[0];
            }
        }
    }
}
