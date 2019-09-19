using System;
using System.Collections.Generic;
using UnityEngine;
//using Mono.Data.Sqlite;

public class DBManager {

    //static string path = "D:/sqlite-tools-win32-x86-3280000/wsDB";

    //static SqliteConnection connection;
    //static SqliteCommand command;
    //static SqliteDataReader reader;

    //public static Dictionary<string, string> curReadInfo = new Dictionary<string, string>();

    //public static void OnOpenDB() {
    //    connection = new SqliteConnection("Data Source=" + path);
    //    connection.Open();
    //    Debug.Log("打开数据库");
        
    //}

    //public static void OnCloseDB() {
    //    connection?.Dispose();
    //    command?.Dispose();
    //    reader?.Dispose();
    //}

    //public static void ExecuteCMD(string cmd) {

    //    command = connection.CreateCommand();
    //    command.CommandText = cmd;
    //    reader = command.ExecuteReader();
    //}

    //public static void OnCreateTable(string tableName, string[] tableKey) {
    //    string cmd1 = "create table " + tableName;
    //    string cmd2 = "(";
    //    for (int i = 0; i < tableKey.Length; i++)
    //    {
    //        cmd2 += tableKey[i] + ",";
    //    }
    //    cmd2 = cmd2.TrimEnd(',') +  ")";
        
    //    string cmd = cmd1 + cmd2;
    //    Debug.Log(cmd);

    //    ExecuteCMD(cmd);
    //}

    //public static void OnInsertValues(string tableName, string[] tableKey, string[] values) {
    //    string cmd1 = "insert into " + tableName;
    //    string cmd2 = "(";
    //    for (int i = 0; i < tableKey.Length; i++)
    //    {
    //        cmd2 += tableKey[i] + ",";
    //    }
    //    cmd2 = cmd2.TrimEnd(',') + ")";
    //    string cmd3 = " values";
    //    for (int i = 0; i < values.Length; i++)
    //    {
    //        cmd3 +=  values[i] + ",";
    //    }
    //    cmd3 = cmd3.TrimEnd(',');
    //    string cmd = cmd1 + cmd2 + cmd3;
    //    Debug.Log(cmd);

    //    ExecuteCMD(cmd);
    //}

    //public static void OnReadTable(string tableName,string[] tableKey) {
    //    string cmd1 = "";
    //    for (int i = 0; i < tableKey.Length; i++)
    //    {
    //        cmd1 += tableKey[i] + ",";
    //    }

    //    string cmd = "select " + cmd1 + "from" + tableName;

    //    Debug.Log(cmd);

    //    ExecuteCMD(cmd);

    //    curReadInfo.Clear();
    //    while (reader.Read()) {

    //        for (int i = 0; i < reader.FieldCount; i++)
    //        {

    //        }
    //    }

    //}
}
