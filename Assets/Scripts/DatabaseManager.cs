using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private string dbPath;

    void Awake()
    {
        dbPath = "URI=file:" + Application.persistentDataPath + "/GameData.db";
        CreateTable();
    }
    void Start()
    {
        Debug.Log("Veritabaný yolu: " + Application.persistentDataPath);
    }

    private void CreateTable()
    {
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"CREATE TABLE IF NOT EXISTS Scores (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Score INTEGER,
                                            BestScore INTEGER,
                                            CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
                                        );";
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void InsertScore(int score, int bestScore)
    {
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Scores (Score, BestScore) VALUES (@score, @bestScore)";
                command.Parameters.AddWithValue("@score", score);
                command.Parameters.AddWithValue("@bestScore", bestScore);
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public int GetBestScore()
    {
        using (var connection = new SqliteConnection(dbPath))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT MAX(BestScore) FROM Scores";

                object result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
            }

            connection.Close();
        }

        return 0;
    }
}
