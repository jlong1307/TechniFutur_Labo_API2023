using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Services
{
    public abstract class Repository
    {

        protected string ConnectionString;
        public Repository(string connectionString)
        {
            ConnectionString = connectionString;
        }


    }
}
