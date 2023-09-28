using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_Project.Models;
using CRUD_Project.ViewModel;

namespace CRUD_Project.Controllers
{
	public class CustomersController : Controller
	{
		private AppDbContext db = new AppDbContext();

		// GET: Customers
		public ActionResult Index()
		{
			//var vm = db.Customers.Select(s => new IndexVM
			//{
			//	City = s.City,
			//	Address = s.Address,
			//	CompanyName = s.CompanyName,
			//	ContactName = s.ContactName,
			//	ContactTitle = s.ContactTitle,
			//	Country = s.Country,
			//	CustomerID = s.CustomerID,
			//	Fax = s.Fax,
			//	Phone = s.Phone,
			//	PostalCode = s.PostalCode,
			//	Region = s.Region

			//}).ToList();

			return View(db.Customers.Select(s => new IndexVM
			{
				City = s.City,
				Address = s.Address,
				CompanyName = s.CompanyName,
				ContactName = s.ContactName,
				ContactTitle = s.ContactTitle,
				Country = s.Country,
				CustomerID = s.CustomerID,
				Fax = s.Fax,
				Phone = s.Phone,
				PostalCode = s.PostalCode,
				Region = s.Region

			}).ToList());
		}

		// GET: Customers/Details/5
		public ActionResult Details(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Customer customer = db.Customers.Find(id);
			if (customer == null)
			{
				return HttpNotFound();
			}
			return View(customer);
		}

		// GET: Customers/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Customers/Create
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer)
		{
			if (ModelState.IsValid)
			{
				db.Customers.Add(customer);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(customer);
		}

		// GET: Customers/Edit/5
		public ActionResult Edit(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Customer customer = db.Customers.Find(id);
			if (customer == null)
			{
				return HttpNotFound();
			}
			return View(customer);
		}

		// POST: Customers/Edit/5
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer)
		{
			if (ModelState.IsValid)
			{
				db.Entry(customer).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(customer);
		}

		// GET: Customers/Delete/5
		public ActionResult Delete(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Customer customer = db.Customers.Find(id);
			if (customer == null)
			{
				return HttpNotFound();
			}
			return View(customer);
		}

		// POST: Customers/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(string id)
		{
			Customer customer = db.Customers.Find(id);
			db.Customers.Remove(customer);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
