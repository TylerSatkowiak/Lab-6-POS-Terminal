using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_6_Project_POS_Terminal
{
    public class Descriptions
    {

        private string _name;
        private string _category;
        private string _description;
        private double _price;

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string Category
        {
            get { return this._category; }
            set { this._category = value; }
        }
        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }
        public double Price
        {
            get { return this._price; }
            set { this._price = value; }
        }

        public Descriptions(string name, string category, string description, double price)
        {
            _name = name;
            _category = category;
            _description = description;
            _price = price;
            Store.AddToStore(this);
        }

        public override string ToString()
        {
            return String.Format("{0,15} {1,15} {2,15} {3,15} ",$"{_name}", $"{_category}", $"{_description}", $"${_price}");
        }
    }
}
