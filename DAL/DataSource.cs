using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class AbstractDataSource
    {
        protected AbstractDataContext dataContext;
        public AbstractDataContext Context { get { return dataContext; } }
    }

    public class DataSource : AbstractDataSource
    {

        public DataSource(string con)
        {
            dataContext = new DataContext(con);
            dataContext.DataProvider = new XMLDataProvider();
        }
    }
}
