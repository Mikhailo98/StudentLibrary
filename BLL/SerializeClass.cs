using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    internal class SerializeClass<T>
    {
        private AbstractDataSource dataSource;

        public void Serialize(string str)
        {
            dataSource = new DataSource(str);
        }

        public List<T> GetInfo()
        {
            return (List<T>)dataSource.Context.GetData(typeof(List<T>));
        }

        public void SetInfo(List<T> data)
        {
            dataSource.Context.SetData(data);
        }
    }
}
