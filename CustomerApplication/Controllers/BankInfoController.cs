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
    public class BankInfoController : Controller
    {
        //private CustomerEntities db = new CustomerEntities();
        客戶銀行資訊Repository repo = new 客戶銀行資訊Repository();

        // GET: BankInfo
        public ActionResult Index()
        {
            //var 客戶銀行資訊 = db.客戶銀行資訊.Include(客 => 客.客戶資料).Where(c => c.是否已刪除 == false);
            var 客戶銀行資訊 = repo.All();
            return View(客戶銀行資訊.ToList());
        }

        // GET: BankInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            客戶銀行資訊 客戶銀行資訊 = repo.Find(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: BankInfo/Create
        public ActionResult Create()
        {
            //ViewBag.客戶Id = new SelectList(db.客戶資料.Where(c => c.是否已刪除 == false), "Id", "客戶名稱");
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: BankInfo/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼,是否已刪除")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                //客戶銀行資訊.是否已刪除 = false;
                //db.客戶銀行資訊.Add(客戶銀行資訊);
                //db.SaveChanges();
                repo.Add(客戶銀行資訊);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            //ViewBag.客戶Id = new SelectList(db.客戶資料.Where(c => c.是否已刪除 == false), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: BankInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            客戶銀行資訊 客戶銀行資訊 = repo.Find(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            //ViewBag.客戶Id = new SelectList(db.客戶資料.Where(c => c.是否已刪除 == false), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: BankInfo/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼,是否已刪除")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(客戶銀行資訊).State = EntityState.Modified;
                //db.SaveChanges();
                repo.Update(客戶銀行資訊);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            //ViewBag.客戶Id = new SelectList(db.客戶資料.Where(c => c.是否已刪除 == false), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            ViewBag.客戶Id = new SelectList(repo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: BankInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            客戶銀行資訊 客戶銀行資訊 = repo.Find(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // POST: BankInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            //客戶銀行資訊.是否已刪除 = true;
            ////db.客戶銀行資訊.Remove(客戶銀行資訊);
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
