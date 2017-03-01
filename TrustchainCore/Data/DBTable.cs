﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace TrustchainCore.Data
{
    public class DBTable
    {
        public SQLiteConnection Connection { get; set; }
        public string  TableName { get; set; }

        public bool TableExist()
        {
            string sql = "SELECT name FROM sqlite_master WHERE type='table' AND name='@table' COLLATE NOCASE";
            var command = new SQLiteCommand(sql, Connection);
            command.Parameters.Add(new SQLiteParameter("@table", TableName));
            var reader = command.ExecuteReader();
            return (reader.Read());
        }

        public virtual IEnumerable<T> Query<T>(SQLiteCommand command, Func<SQLiteDataReader, T> newItemMethod = null)
        {
            if (newItemMethod == null)
                throw new MissingMethodException("Missing newItemMethod");

            var reader = command.ExecuteReader();
            var list = new List<T>();
            while (reader.Read())
                list.Add(newItemMethod(reader));
            return list;
        }


        public virtual JArray Query(SQLiteCommand command, Func<SQLiteDataReader, JObject> newItemMethod = null)
        {
            if (newItemMethod == null)
                throw new MissingMethodException("Missing newItemMethod");

            var result = new JArray();
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                result.Add(newItemMethod(reader));

            return result;
        }

        public virtual int Count()
        {
            var command = new SQLiteCommand("SELECT count(*) FROM " + TableName, Connection);
            var result = Query(command, (reader) => new JObject(new JProperty("count", reader[0]))).FirstOrDefault();
            return (int)result["count"];
        }

        public int DropTable()
        {
            var command = new SQLiteCommand("DROP TABLE IF EXISTS " + TableName, Connection);
            return command.ExecuteNonQuery();
        }
    }
}
