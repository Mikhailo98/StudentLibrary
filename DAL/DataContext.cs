using System;

namespace DAL
{
    abstract public class AbstractDataContext
    {
        protected string connectionString;
        protected IDataProvider dataProvider;

        abstract public Object GetData(Type typeData);
        abstract public void SetData(Object data);

        public string ConnectionString
        {
            get { return connectionString; }
        }

        public IDataProvider DataProvider
        {
            get { return dataProvider; }
            set { dataProvider = value; }
        }
    }

    public class DataContext : AbstractDataContext
    {
        public DataContext(string con)
        {
            connectionString = con;
        }

        public override Object GetData(Type typeData)
        {
            if (dataProvider != null)
            {
                if (storedData != null)
                    return storedData;
                else
                {
                    try
                    {
                        storedData = dataProvider.Read(typeData, connectionString);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    return storedData;
                }
            }
            else
                throw new InvalidOperationException("Data provider is undefined");
        }

        public override void SetData(Object data)
        {
            if (dataProvider != null)
            {
                dataProvider.Write(data, connectionString);
            }
            else
                throw new InvalidOperationException("Data provider is undefined");
        }

        private Object storedData;
    }

}

