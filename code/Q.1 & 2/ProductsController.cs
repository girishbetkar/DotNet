using ProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMVC.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Examdb;Integrated Security=True";
            connect.Open();
            SqlCommand sc = new SqlCommand();
            sc.Connection = connect;
            sc.CommandType = System.Data.CommandType.Text;
            sc.CommandText = "Select * From Products";
            List<Product> lstProduct = new List<Product>();
            try
            {
                SqlDataReader sdata = sc.ExecuteReader();
                while (sdata.Read())
                {
                    Product p = null;
                    lstProduct.Add(new Product { ProductId = sdata.GetInt32(0) , ProductName = sdata.GetString(1),Rate=sdata.GetDecimal(2),Description=sdata.GetString(3),CategoryName=sdata.GetString(4)});
                    
                }
                sdata.Close();
            }
            catch(Exception except)
            {
                Console.WriteLine(except.Message);
                return View();
        
            }
            connect.Close();
            return View(lstProduct);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id=0)
        {
            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Examdb;Integrated Security=True";
            connect.Open();
            SqlCommand sc = new SqlCommand();
            sc.Connection = connect;
            sc.CommandType = System.Data.CommandType.Text;
            sc.CommandText = "Select * From Products where ProductId= @ProductId";
            sc.Parameters.AddWithValue("ProductId", id);
            SqlDataReader sdata = sc.ExecuteReader();
            Product p1 = null;
            if (sdata.Read())
            {
                p1=new Product{ ProductId = sdata.GetInt32(0), ProductName = sdata.GetString(1), Rate = sdata.GetDecimal(2), Description = sdata.GetString(3), CategoryName = sdata.GetString(4) };
                
            }
            else
            {
                return View();
            }
            connect.Close();

            return View(p1);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product p1)
        {
            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Examdb;Integrated Security=True";
            connect.Open();
            SqlCommand sc = new SqlCommand();
            sc.Connection = connect;
            sc.CommandType = System.Data.CommandType.Text;
            sc.CommandText = "Update Products set productName = @ProductName,ProductName= @ProductName,Rate= @Rate,Description =@Description,CartegoryName = @CategoryName where ProductId= @ProductId";
            sc.Parameters.AddWithValue("ProductId", p1.ProductId);
            sc.Parameters.AddWithValue("ProductName", p1.ProductName);
            sc.Parameters.AddWithValue("Rate",p1.Rate);
            sc.Parameters.AddWithValue("Description", p1.Description );
            sc.Parameters.AddWithValue("CategoryName", p1.CategoryName);
         
            try
            {
                sc.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch(Exception except)
            {
                Console.WriteLine(except.Message);
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
