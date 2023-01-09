using PasswordValidatorApp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorAppTests.Data.Repository
{
    internal class MockFileRepository : IRepository
    {
        private readonly IEnumerable<string> _data;

        public MockFileRepository(IEnumerable<string> data)
        {
            _data = data;
        }

        public Task<IEnumerable<string>> GetDataForValidation()
        {
            return Task.Run(() => { return _data; });
        }
    }
}
