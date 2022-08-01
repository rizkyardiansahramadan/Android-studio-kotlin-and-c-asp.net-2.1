using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Osis.Model
{
    public class ProsesOsis
    {
        KonekDb db = null;
        public ProsesOsis()
        {
            db = new KonekDb();
        }
        public List<DataOsis> getOsis()
        {
            List<DataOsis> tw = new List<DataOsis>();
            using (MySqlConnection conn = db.openConnection())
            {
                string query = "SELECT * FROM anggota";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            tw.Add(new DataOsis
                            {
                                id = Convert.ToInt32(sdr["id"]),
                                nis = sdr["nis"].ToString(),
                                nama = sdr["nama"].ToString(),
                                kelas = sdr["kelas"].ToString(),
                                jabatan = sdr["jabatan"].ToString()
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return tw;
        }//end get osis


        public bool saveOsis(DataOsis osis)
        {
            bool hasil = false;
            using (MySqlConnection conn = db.openConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "insert into anggota (nis,nama,kelas,jabatan)" +
                        "values(@nis,@nama,@kelas,@jabatan)";
                    cmd.Parameters.Add("nis", MySqlDbType.VarChar).Value = osis.nis;
                    cmd.Parameters.Add("nama", MySqlDbType.VarChar).Value = osis.nama;
                    cmd.Parameters.Add("kelas", MySqlDbType.VarChar).Value = osis.kelas;
                    cmd.Parameters.Add("jabatan", MySqlDbType.VarChar).Value = osis.jabatan;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    hasil = true;
                }

            }
            return hasil;
        }// end save data
        public bool UpdateOsis(DataOsis osis)
        {
            bool hasil = false;
            using (MySqlConnection conn = db.openConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "UPDATE anggota SET  nis=@nis, nama=@nama, kelas=@kelas, jabatan=@jabatan where id=@id";
                    cmd.Parameters.Add("nis", MySqlDbType.VarChar).Value = osis.nis;
                    cmd.Parameters.Add("nama", MySqlDbType.VarChar).Value = osis.nama;
                    cmd.Parameters.Add("kelas", MySqlDbType.VarChar).Value = osis.kelas;
                    cmd.Parameters.Add("jabatan", MySqlDbType.VarChar).Value = osis.jabatan;
                    cmd.Parameters.Add("id", MySqlDbType.Int32).Value = osis.id;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    hasil = true;
                }
            }
            return hasil;
        }// end updateTwice

        public bool deleteOsis(String id)
        {
            bool hasil = false;
            using (MySqlConnection conn = db.openConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "delete from anggota where id=@id";
                    cmd.Parameters.Add("id", MySqlDbType.Int32).Value = Int32.Parse(id);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    hasil = true;
                }
            }
            return hasil;
        }
        public DataOsis getOsisById(string id)
        {
            DataOsis tw = new DataOsis();
            using (MySqlConnection conn = db.openConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select *from anggota where id=@id";
                    cmd.Parameters.Add("id", MySqlDbType.Int32).Value = Int32.Parse(id);
                    conn.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            tw = new DataOsis
                            {
                                id = Convert.ToInt32(sdr["id"]),
                                nis = sdr["nis"].ToString(),
                                nama = sdr["nama"].ToString(),
                                kelas = sdr["kelas"].ToString(),
                                jabatan = sdr["jabatan"].ToString(),

                            };
                        }
                    }
                    conn.Close();
                }
                return tw;
            }// end getOsisbyid
        }
    }
}
