﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerApplication.Models;

namespace CustomerApplication.Controllers
{
    public class ContactController : Controller
    {
        //private CustonerEntities db = new CustonerEntities();
        客戶聯絡人Repository repo = new 客戶聯絡人Repository();


        // GET: Contact
        public ActionResult Index()
        {
            //var 客戶聯絡人 = db.客戶聯絡人.Include(客 => 客.客戶資料).Where(c => c.是否已刪除 == false);
            var 客戶聯絡人 = repo.All().ToList();
            return View(客戶聯絡人.ToList());
        }

        // GET: Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = repo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            客戶資料Repository repoC = new 客戶資料Repository();
            //ViewBag.客戶Id = new SelectList(db.客戶資料.Where(c => c.是否已刪除 == false), "Id", "客戶名稱");
            ViewBag.客戶Id = new SelectList(repoC.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: Contact/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,是否已刪除")] 客戶聯絡人 客戶聯絡人)
        {
            //var tempContact = db.客戶聯絡人.Where(c => c.客戶Id == 客戶聯絡人.客戶Id && c.Email.ToUpper() == 客戶聯絡人.Email.ToUpper() && c.是否已刪除 == false);

            //if (tempContact.ToList().Count > 0)
            //{
            //    ViewBag.客戶Id = new SelectList(db.客戶資料.Where(c => c.是否已刪除 == false), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            //    return View(客戶聯絡人);
            //}

            //if (ModelState.IsValid)
            //{
            //    客戶聯絡人.是否已刪除 = false;
            //    db.客戶聯絡人.Add(客戶聯絡人);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            repo.Add(客戶聯絡人);
            repo.UnitOfWork.Commit();

            //ViewBag.客戶Id = new SelectList(db.客戶資料.Where(c => c.是否已刪除 == false), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = repo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            //ViewBag.客戶Id = new SelectList(db.客戶資料.Where(c => c.是否已刪除 == false), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: Contact/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話,是否已刪除")] 客戶聯絡人 客戶聯絡人)
        {
            //var tempContact = db.客戶聯絡人.Where(c => c.客戶Id == 客戶聯絡人.客戶Id && c.Email.ToUpper() == 客戶聯絡人.Email.ToUpper() && c.是否已刪除 == false);

            //if (tempContact.ToList().Count > 0)
            //{
            //    ViewBag.客戶Id = new SelectList(db.客戶資料.Where(c => c.是否已刪除 == false), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            //    return View(客戶聯絡人);
            //}

            //if (ModelState.IsValid)
            //{
            //    db.Entry(客戶聯絡人).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            repo.Update(客戶聯絡人);
            repo.UnitOfWork.Commit();

            //ViewBag.客戶Id = new SelectList(db.客戶資料.Where(c => c.是否已刪除 == false), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = repo.Find(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            //客戶聯絡人.是否已刪除 = true;
            ////db.客戶聯絡人.Remove(客戶聯絡人);
            //db.SaveChanges();
            repo.Delete(repo.Find(id));
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
