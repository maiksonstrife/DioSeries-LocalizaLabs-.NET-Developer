using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series.Classes
{
    public class SeriesRepo : Irepository<Series>
    {
        private List<Series> seriesList = new List<Series>();

        public void Delete(int id)
        {
            seriesList[id].Delete();
        }

        public void Insert(Series serie)
        {
            seriesList.Add(serie);
        }

        public List<Series> List()
        {
            return seriesList;
        }

        public int NextId()
        {
            return seriesList.Count;
        }

        public Series ReturnById(int id)
        {
            return seriesList[id];
        }

        public void Update(int id, Series serie)
        {
            seriesList[id] = serie;
        }
    }
}