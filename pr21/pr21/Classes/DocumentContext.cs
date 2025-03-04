using pr21.Classes.Common;
using pr21.Interfaces;
using pr21.Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr21.Classes
{
    public class DocumentContext : Document, IDocument
    {
        public List<DocumentContext> AllDocuments()
        {
            List<DocumentContext> allDocuments = new List<DocumentContext>();
            OleDbConnection connection = DBConnection.Connection();
            OleDbDataReader dataDocuments = DBConnection.Query("SELECT * FROM [Документы]", connection);
            while (dataDocuments.Read())
            {

                DocumentContext newDocument = new DocumentContext();
                Id = dataDocuments.GetInt32(0);
                Src = dataDocuments.GetString(1);
                Name = dataDocuments.GetString(2);
                User = dataDocuments.GetString(3);
                Id_document = dataDocuments.GetInt32(4);
                Date = dataDocuments.GetDateTime(5);
                Status = dataDocuments.GetInt32(6);
                Vector = dataDocuments.GetString(7);
                allDocuments.Add(newDocument);

            }
            DBConnection.CloseConnection(connection);
            return allDocuments;

        }

        public void Delete()
        {

            OleDbConnection connection =  DBConnection.Connection();
            DBConnection.Query($"DELETE FROM [Документы] WHERE [Код] = {this.Id}", connection);
            DBConnection.CloseConnection(connection);
        }

        public void Save(bool Update = false)
        {
            if (Update)
            {
                OleDbConnection connection = Common.DBConnection.Connection();
                Common.DBConnection.Query("UPDATE [Документы] " +
                                            "Set " +
                                            $"[Изображение] = '{this.Src}', " +
                                            $"[Наименование] = '{this.Name}', " +
                                            $"[Отвественный] = '{this.User}', " +
                                            $"[Код документа] = '{this.Id_document}', " +
                                            $"[Дата поступления] = '{this.Date.ToString("dd.MM.yyyy")}', " +
                                            $"[Статус] = '{this.Status}', " +
                                            $"[Направление] = '{this.Vector}' " +
                                            $"Where [Код] = {this.Id}", connection);

                Common.DBConnection.CloseConnection(connection);
            }
            else
            {
                OleDbConnection connection = Common.DBConnection.Connection();
                Common.DBConnection.Query("INSERT INTO " +
                                        "[Документы] " +
                                        $"([Изображение], " +
                                        $"[Наименование], " +
                                        $"[Отвественный], " +
                                        $"[Код документа], " +
                                        $"[Дата поступления], " +
                                        $"[Статус], " +
                                        $"[Направление])" +
                                " VALUES (" +
                                    $"'{this.Src}', " +
                                    $"'{this.Name}', " +
                                    $"'{this.User}', " +
                                    $"'{this.Id_document}', " +
                                    $"'{this.Date.ToString("dd.MM.yyyy")}', " +
                                    $"'{this.Status}', " +
                                    $"'{this.Vector}')",
                                        connection);

                Common.DBConnection.CloseConnection(connection);
            }
        }

    }
}
