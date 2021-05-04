using Series.Enums;
using System;

namespace Series.Classes
{
    public class Series : BaseEntity
    {
        private Genres genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }
        public Series(int id, Genres genre, string title, string description, int year)
        {
            this.Id = id;
            this.genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string info = "";
            info += "Title: " + this.Title + Environment.NewLine;
            info += "Gender: " + this.genre + Environment.NewLine;
            info += "Description: " + this.Description + Environment.NewLine;
            info += "Year: " + this.Year + Environment.NewLine;
            info += "Deleted: " + this.Deleted;
            return info;
        }

        public string ReturnTitle()
        {
            return this.Title;
        }

        public int ReturnId()
        {
            return this.Id;
        }

        public bool ReturnExcluded()
        {
            return this.Deleted;
        }

        public void Delete(){
            this.Deleted = true;
        }
    }
}