using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pr19.Classes
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Src { get; set; }

        public Category(int Id, string Name, string Src)
        {
            this.Id = Id;
            this.Name = Name;
            this.Src = Src;
        }

        public static List<Classes.Category> AllCategories()
        {
            List<Category> allCategories = new List<Category>();
            
            allCategories.Add(new Category(1, "Кошки", "Cat.jpg"));
            allCategories.Add(new Category(2, "Собаки", "Dog.jpg"));

            return allCategories;
        }
    }
}