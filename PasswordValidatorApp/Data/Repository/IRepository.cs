using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorApp.Data.Repository
{
    public interface IRepository
    {
        Task<IEnumerable<string>> GetDataForValidation();
    }
}
