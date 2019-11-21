using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using BT4.Models;
using System.Linq;

namespace BT4.Helpers
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public Database()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.CreateTable<Loaihoa>();
                    connection.CreateTable<Hoa>();
                }
            } catch (SQLiteException ex)
            {
                // Log.Info("SQLiteExpection:", ex.Message);
            }     
        }

        public List<Loaihoa> GetLoaihoas()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    return connection.Table<Loaihoa>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                // Log.Info("SQLiteExpection:", ex.Message);
                return null;
            }
        }

        public Loaihoa GetLoaihoaById(int Maloai)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var dsh = from lhs in connection.Table<Loaihoa>().ToList()
                              where lhs.Maloai == Maloai
                              select lhs;
                    return dsh.ToList<Loaihoa>().FirstOrDefault();
                }
            }
            catch (SQLiteException ex)
            {
                // Log.Info("SQLiteExpection:", ex.Message);
                return null;
            }
        }

        public bool InsertLoaihoa(Loaihoa lh)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Insert(lh);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                // Log.Info("SQLiteExpection:", ex.Message);
                return false;
            }
        }

        public bool UpdateLoaihoa(Loaihoa lh)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Update(lh);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                // Log.Info("SQLiteExpection:", ex.Message);
                return false;
            }
        }

        public bool DeleteLoaihoa(Loaihoa lh)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Delete(lh);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                // Log.Info("SQLiteExpection:", ex.Message);
                return false;
            }
        }
    }
}
