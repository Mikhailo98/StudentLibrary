using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.Threading;

namespace BLL
{

    /// <summary>
    /// This is a generic class that is responsible for Collection of classes of a project
    /// </summary>
    /// <typeparam name="T"> Is type of Class</typeparam>
    public class Handle<T> : ICollection<T>
    {
        private List<T> Collection;
        private SerializeClass<T> sc;
        private readonly string Path;

        protected Handle()
        {
        }

        public Handle(string path)
        {
            Collection = new List<T>();
            sc = new SerializeClass<T>();
            this.Path = path;
            sc.Serialize(Path);
            Collection = sc.GetInfo();

        }
        public bool Serialize()
        {
            try
            {
                sc.SetInfo(Collection);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Handle<T> ShowAll()
        {
            Handle<T> t = new Handle<T>();
            foreach (var item in Collection)
                t.Add(item);
            return t;
        }

        public T Find(Predicate<T> match)
        {
            return Collection.Find(match);
        }


        public void Sort(Comparison<T> comp)
        {
            Collection.Sort(comp);
        }


        #region ICollection<T> Implementation

        public int Count { get { return Collection.Count; } }

        public bool IsReadOnly { get { return false; } }

        public void Add(T item)
        {
            Collection.Add(item);
        }

        public void Clear()
        {
            Collection.Clear();
        }

        public bool Contains(T item)
        {
            return Collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Collection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in Collection)
                yield return item;
        }

        /// <summary>
        /// Removes first occurrence of specific object
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {

            return Collection.Remove(item);
        }

        public bool IsEmpty()
        {
            return (Collection.Count == 0) ? true : false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion


        public override string ToString()
        {
            var sb = new StringBuilder();
            if (IsEmpty())
                sb.AppendLine("Empty");
            else
                for (int i = 0; i != Collection.Count; ++i)
                    sb.AppendLine(Collection[i].ToString());
            return sb.ToString();
        }


    }
}
