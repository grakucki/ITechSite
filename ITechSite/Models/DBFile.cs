using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;

namespace ITechSite.Models
{

   

    public class DBFile
    {
        public List<string> GetAll()
        {
            List<string> result = new List<string>();
            using (var conn = OpenConnection())
            using (var cmd = new SqlCommand("SELECT CodeName FROM dbo.FileContent", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add((string)reader[0]);
                }
            }
            return result;
        }

        private void Save(FileData data)
        {
            using (var conn = OpenConnection())
            using (var tran = conn.BeginTransaction())
            using (var cmd = new SqlCommand(
                "INSERT dbo.FileContent(CodeName, Content) " +
                "OUTPUT inserted.Content.PathName(), GET_FILESTREAM_TRANSACTION_CONTEXT() " +
                "VALUES(@codename, 0x)", conn, tran))
            {
                cmd.Parameters.AddWithValue("@codename", data.Name);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string filePath = (string)reader[0];
                        byte[] NTFSContext = (byte[])reader[1];
                        using (var dbStream = new SqlFileStream(filePath, NTFSContext, FileAccess.Write))
                        {
                            data.File.CopyTo(dbStream);
                        }
                    }
                }
                tran.Commit();
            }
        }

        public void Save(FileData data, Guid FileId)
        {
            using (var conn = OpenConnection())
            using (var tran = conn.BeginTransaction())
            using (var cmd = new SqlCommand(
                "SELECT Content.PathName() [Path], GET_FILESTREAM_TRANSACTION_CONTEXT() [TransactionContext] " +
                "FROM dbo.FileContent F WHERE F.FileId=@FileId", conn, tran))
            {
                cmd.Parameters.AddWithValue("@FileId", FileId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string filePath = (string)reader[0];
                        byte[] NTFSContext = (byte[])reader[1];
                        using (var dbStream = new SqlFileStream(filePath, NTFSContext, FileAccess.Write))
                        {
                            data.File.CopyTo(dbStream);
                        }
                    }
                }
                tran.Commit();
            }
        }

        public Stream Get(Guid FileId)
        {
            //Do not close or release connection and transaction,
            //FileResult closes them automatically.
            var conn = OpenConnection();
            var tran = conn.BeginTransaction();
            var cmd = new SqlCommand(
                "SELECT Content.PathName() [Path], GET_FILESTREAM_TRANSACTION_CONTEXT() [TransactionContext] " +
                "FROM dbo.FileContent F WHERE F.FileId=@FileId", conn, tran);
            cmd.Parameters.AddWithValue("@FileId", FileId);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    string path = (string)reader[0];
                    byte[] NTFSContext = (byte[])reader[1];
                    return new OpenSqlFileStream(new SqlFileStream(path, NTFSContext, FileAccess.Read), conn, tran);
                }
            }
            return null;
        }

        public void Delete(Guid FileId)
        {
            var conn = OpenConnection();
            var tran = conn.BeginTransaction();
            var cmd = new SqlCommand("DELETE FROM dbo.FileContent F WHERE F.FileId=@FileId", conn, tran);
            cmd.Parameters.AddWithValue("@FileId", FileId);
            cmd.ExecuteNonQuery();
            tran.Commit();
        }

        public void DeleteAll(int DocId)
        {
            var conn = OpenConnection();
            var tran = conn.BeginTransaction();
            var cmd = new SqlCommand("DELETE FROM dbo.FileContent F WHERE F.Dokument_Id=@DocId", conn, tran);
            cmd.Parameters.AddWithValue("@DocId", DocId);
            cmd.ExecuteNonQuery();
            tran.Commit();
        }

        private SqlConnection OpenConnection()
        {
            ITechEntities m = new ITechEntities(0);
            var c = m.Database.Connection.ConnectionString;
//            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            var connection = new SqlConnection(c);
            connection.Open();
            return connection;
        }
    }
}