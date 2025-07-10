using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr21.Model
{
    public class Document
    {
        // Внутренний код документа
        public int Id { get; set; }

        // Путь к изображению
        public string Src { get; set; }

        // Наименование документа
        public string Name { get; set; }

        // Наименование ответственного
        public string User { get; set; }

        // Код документа
        public int Id_document { get; set; }

        // Дата поступления документа
        public DateTime Date { get; set; }

        // Статус документа
        public int Status { get; set; }

        // Направление документа
        public string Vector { get; set; }
    }
}
