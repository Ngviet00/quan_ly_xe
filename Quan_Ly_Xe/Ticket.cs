using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Xe
{
    public class Ticket
    {
        private static string myConn = @"Data Source = ADMIN\SQLEXPRESS; Initial Catalog = quan_ly_can_xe; Integrated Security = True; Encrypt = False";

        public long Id { get; set; }

        public string LicensePlates { get; set; }

        public string Seller { get; set; }

        public string Buyer { get; set; }

        public string Item { get; set; }

        public int TotalWeight { get; set; }

        public int TotalVehicle { get; set; }

        public int TotalItem { get; set; }

        public int Status { get; set; }

        public int IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        private const string SelectAllQuery = "SELECT * FROM tickets";
        
        private const string InsertQuery = "INSERT INTO tickets(license_plates, seller, buyer, item, total_weight, total_vehicle, total_item, status, is_deleted, created_at, updated_at) VALUES (@LicensePlates, @Seller, @Buyer, @Item, @TotalWeight, @TotalVehicle, @TotalItem, @Status, @IsDeleted, @CreatedAt, @UpdatedAt)";
        
        private const string UpdateQuery = "UPDATE tickets SET license_plates = @LicensePlates, seller = @Seller, buyer = @Buyer, item = @Item, total_weight = @TotalWeight, total_vehicle = @TotalVehicle, total_item = @TotalItem, updated_at = @UpdatedAt WHERE id = @Id";
        
        private const string DeleteQuery = "DELETE FROM tickets WHERE id = @Id";

        public DataTable GetAll()
        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SelectAllQuery, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }

        public bool Insert(Ticket ticket)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@LicensePlates", ticket.LicensePlates);
                    com.Parameters.AddWithValue("@Seller", ticket.Seller);
                    com.Parameters.AddWithValue("@Buyer", ticket.Buyer);
                    com.Parameters.AddWithValue("@Item", ticket.Item);
                    com.Parameters.AddWithValue("@TotalWeight", ticket.TotalWeight);
                    com.Parameters.AddWithValue("@TotalVehicle", ticket.TotalVehicle);
                    com.Parameters.AddWithValue("@TotalItem", ticket.TotalItem);
                    com.Parameters.AddWithValue("@Status", 1);
                    com.Parameters.AddWithValue("@IsDeleted", 0);
                    com.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    com.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        public bool Update(Ticket ticket)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                {
                    com.Parameters.AddWithValue("@LicensePlates", ticket.LicensePlates);
                    com.Parameters.AddWithValue("@Seller", ticket.Seller);
                    com.Parameters.AddWithValue("@Buyer", ticket.Buyer);
                    com.Parameters.AddWithValue("@Item", ticket.Item);
                    com.Parameters.AddWithValue("@TotalWeight", ticket.TotalWeight);
                    com.Parameters.AddWithValue("@TotalVehicle", ticket.TotalVehicle);
                    com.Parameters.AddWithValue("@TotalItem", ticket.TotalItem);
                    com.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }

        public bool Delete(Ticket ticket)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                {
                    com.Parameters.AddWithValue("@Id", ticket.Id);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }
    }
}
