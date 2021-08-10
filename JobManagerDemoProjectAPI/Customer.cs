using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace JobTrackerDemoProjectAPI
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public decimal CreditBalance { get; set; }

        // Select
        public static List<Customer> GetCustomers(SqlConnection con)
        {
            // Create a list of customer objects
            List<Customer> customers = new List<Customer>();

            SqlCommand cmd = new SqlCommand("SELECT customerId, first_name, last_name, phone, email, address1, address2, city, state, zipcode, status, comments, credit_balance FROM customer", con);
            cmd.CommandType = System.Data.CommandType.Text;

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                // Create a new customer object to store properties inside
                Customer customer = new Customer();

                customer.CustomerId = Convert.ToInt32(rdr["customerId"]);
                customer.FirstName = rdr["first_name"].ToString();
                customer.LastName = rdr["last_name"].ToString();
                customer.Phone = rdr["phone"].ToString();
                customer.Email = rdr["email"].ToString();
                customer.Address1 = rdr["address1"].ToString();
                customer.Address2 = rdr["address2"].ToString();
                customer.City = rdr["city"].ToString();
                customer.State = rdr["state"].ToString();
                customer.Zipcode = rdr["zipcode"].ToString();
                customer.Status = rdr["status"].ToString();
                customer.Comments = rdr["comments"].ToString();
                customer.CreditBalance = Convert.ToDecimal(rdr["credit_balance"]);

                customers.Add(customer);
            }

            return customers;
        }

        // Insert
        public static int InsertCustomer(SqlConnection con, Customer customer)
        {
            int rowsInserted = 0;
            SqlCommand cmd = new SqlCommand("INSERT INTO customer (first_name, last_name, phone, email, address1, address2, city, [state], zipcode, [status], comments, credit_balance) VALUES (@FirstName, @LastName, @Phone, @Email, @Address1, @Address2, @City, @State, @Zipcode, @Status, @Comments, @CreditBalance)", con);
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Address1", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Address2", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@City", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@State", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Zipcode", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Status", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Comments", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@CreditBalance", System.Data.SqlDbType.Decimal);

            cmd.Parameters["@FirstName"].Value = customer.FirstName;
            cmd.Parameters["@LastName"].Value = customer.LastName;
            cmd.Parameters["@Phone"].Value = customer.Phone;
            cmd.Parameters["@Email"].Value = customer.Email;
            cmd.Parameters["@Address1"].Value = customer.Address1;
            cmd.Parameters["@Address2"].Value = customer.Address2;
            cmd.Parameters["@City"].Value = customer.City;
            cmd.Parameters["@State"].Value = customer.State;
            cmd.Parameters["@Zipcode"].Value = customer.Zipcode;
            cmd.Parameters["@Status"].Value = customer.Status;
            cmd.Parameters["@Comments"].Value = customer.Comments;
            cmd.Parameters["@CreditBalance"].Value = customer.CreditBalance;

            rowsInserted = cmd.ExecuteNonQuery();
            return rowsInserted;
        }

        // Update
        public static int UpdateCustomer(SqlConnection con, Customer customer)
        {
            int rowsUpdated = 0;

            SqlCommand cmd = new SqlCommand("UPDATE customer SET first_name = @FirstName, last_name = @LastName, phone = @Phone, email = @Email, address1 = @Address1, address2 = @Address2, city = @City, state = @State, zipcode = @Zipcode, status = @Status, comments = @Comments, credit_balance = @CreditBalance WHERE customerId = @CustomerId", con);
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add("@CustomerId", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Address1", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Address2", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@City", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@State", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Zipcode", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Status", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@Comments", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@CreditBalance", System.Data.SqlDbType.Decimal);

            cmd.Parameters["@CustomerId"].Value = customer.CustomerId;
            cmd.Parameters["@FirstName"].Value = customer.FirstName;
            cmd.Parameters["@LastName"].Value = customer.LastName;
            cmd.Parameters["@Phone"].Value = customer.Phone;
            cmd.Parameters["@Email"].Value = customer.Email;
            cmd.Parameters["@Address1"].Value = customer.Address1;
            cmd.Parameters["@Address2"].Value = customer.Address2;
            cmd.Parameters["@City"].Value = customer.City;
            cmd.Parameters["@State"].Value = customer.State;
            cmd.Parameters["@Zipcode"].Value = customer.Zipcode;
            cmd.Parameters["@Status"].Value = customer.Status;
            cmd.Parameters["@Comments"].Value = customer.Comments;
            cmd.Parameters["@CreditBalance"].Value = customer.CreditBalance;

            rowsUpdated = cmd.ExecuteNonQuery();

            return rowsUpdated;
        }
        
        // Delete
        public static int DeleteCustomer(SqlConnection con, int customerId)
        {
            int rowsDeleted = 0;

            SqlCommand cmd = new SqlCommand("DELETE FROM customer WHERE customerId = @CustomerId", con);
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.Add("@CustomerId", System.Data.SqlDbType.Int);
            cmd.Parameters["@CustomerId"].Value = customerId;

            rowsDeleted = cmd.ExecuteNonQuery();

            return rowsDeleted;
        }
    }
}