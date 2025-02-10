using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace AvaloniaApplication1.Services;

public static class DbService
{
    private static readonly string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ShopDB", "database.db");
    public static void InitializeDatabase()
    {
        if (!File.Exists(DbPath))
            Directory.CreateDirectory(Path.GetDirectoryName(DbPath) ?? string.Empty);
        using (var connection = new SqliteConnection($"Data Source={DbPath}"))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"CREATE TABLE IF NOT EXISTS Wallpaper (
                                        w_id VARCHAR NOT NULL,
                                        w_prod_date DATE NOT NULL,
                                        w_company TEXT NOT NULL,
                                        w_title VARCHAR,
                                        w_quantity INTEGER NOT NULL,
                                        w_image BLOB,
                                        w_width SMALLINT NOT NULL,
                                        PRIMARY KEY (w_id, w_prod_date, w_company)
                                    );
                                    CREATE TABLE IF NOT EXISTS Seller (
                                        s_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        s_name VARCHAR(30) NOT NULL
                                    );
                                    CREATE TABLE IF NOT EXISTS Client (
                                        c_id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        c_name VARCHAR(30) NOT NULL
                                    );
                                    CREATE TABLE IF NOT EXISTS Restock (
                                        w_id VARCHAR NOT NULL,
                                        w_prod_date DATE NOT NULL,
                                        w_company TEXT NOT NULL,
                                        s_id INTEGER NOT NULL,
                                        Base_Price REAL,
                                        Load_date DATE NOT NULL,
                                        quantity SMALLINT NOT NULL,
                                        PRIMARY KEY (w_id, w_prod_date, w_company, Load_date, s_id),
                                        FOREIGN KEY (w_id, w_prod_date, w_company) REFERENCES Wallpaper(w_id, w_prod_date, w_company),
                                        FOREIGN KEY (s_id) REFERENCES Seller(s_id)
                                    );
                                    CREATE TABLE IF NOT EXISTS Sell (
                                        w_id VARCHAR NOT NULL,
                                        w_prod_date DATE NOT NULL,
                                        w_company TEXT NOT NULL,
                                        c_id INTEGER NOT NULL,
                                        purchase_date DATE NOT NULL,
                                        quantity SMALLINT NOT NULL,
                                        whole_price REAL NOT NULL,
                                        PRIMARY KEY (w_id, w_prod_date, w_company, purchase_date, c_id),
                                        FOREIGN KEY (w_id, w_prod_date, w_company) REFERENCES Wallpaper(w_id, w_prod_date, w_company),
                                        FOREIGN KEY (c_id) REFERENCES Client(c_id)
                                    )
            ";
            command.ExecuteNonQuery();
        }
    }

    public static void InsertData(string name)
    {
        using (var connection = new SqliteConnection($"Data Source={DbPath}"))
        {
            
        }
    }

    public static void LoadPhotos(string? dateBefore, string[]? company_names = null, string[]? widths = null, string low = "0", string high = "9999", string? dateAfter = "1990-10-10")
    {
        var dateaftertmp = dateBefore ?? DateTime.Now.ToString("yyyy-MM-dd");

        string tmp = " Select w_image from wallpaper w join Restock r on"+
                     " w.w_id = r.w_id and w.w_prod_date = r.w_prod_date"
                     +" and w.w_company = r.w_company Where ";

        foreach (var company in company_names)
            tmp += "w_company = " + company + " or ";
        foreach (var width in widths)
            tmp += "w_width = " + width + " or ";
        switch (low)
        {
            case "":
                tmp+= "r.base_price => 0 or ";
                break;
            case "0":
                tmp += "r.base_price => 0 or ";
                break;
            default:
                tmp += "r.base_price => " + low +" or ";
                break;
        }

        switch (high)
        {
            case "":
                tmp+= "r.base_price <= 9999 or ";
                break;
            case "9999":
                tmp += "r.base_price <= 9999 or ";
                break;
            default:
                tmp += "r.base_price <= " + high +" or ";
                break;
        }

        tmp += "w.prod_date > " + dateaftertmp + " or w.prod_date <" + dateBefore;



        using (var connection = new  SqliteConnection($"Data Source{DbPath}"))
        {
            Console.WriteLine(tmp);
        }
    }

    public static void FetchData()
    {
        using (var connection = new SqliteConnection($"Data Source={DbPath}"))
        {

        }
    }
}