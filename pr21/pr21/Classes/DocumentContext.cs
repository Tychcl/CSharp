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
                newDocument.Id = dataDocuments.GetInt32(0);
                newDocument.Src = dataDocuments.GetString(1);
                newDocument.Name = dataDocuments.GetString(2);
                newDocument.User = dataDocuments.GetString(3);
                newDocument.Id_document = Convert.ToInt32(dataDocuments.GetString(4));
                newDocument.Date = dataDocuments.GetDateTime(5);
                newDocument.Status = dataDocuments.GetInt32(6);
                newDocument.Vector = dataDocuments.GetString(7);
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
                                            $"[Ответственный] = '{this.User}', " +
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
                                        $"[Ответственный], " +
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
