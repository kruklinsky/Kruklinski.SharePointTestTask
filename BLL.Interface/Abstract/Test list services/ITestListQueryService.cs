using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Abstract
{
    public interface ITestListQueryService
    {
        string GetTestList();
        Task<string> GetTestListAsync();
    }
}
