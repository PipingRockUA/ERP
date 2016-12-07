// <copyright file="HomeController.cs" company="None">  
// Copyright (c) Allow to distribute this code.   
// </copyright>  
// <author>Asma Khalid</author>  
//-----------------------------------------------------------------------   
namespace PipingRockERP.Controllers
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    /// <summary>  
    /// Home controller class.   
    /// </summary>  
    [Authorize]
    public class HomeController : Controller
    {
        #region Index method.  
        /// <summary>  
        /// Index method.   
        /// </summary>  
        /// <returns>Returns - Index view</returns>  
        public ActionResult Index()
        {
            return this.View();
        }

        //public ActionResult UnitOfMeasures()
        //{
        //    PipingRockUAEntities db = new PipingRockUAEntities();

        //    var measures = (from UnitOfMeasure in db.UnitOfMeasures select UnitOfMeasure).ToList();

        //    return View(measures);
        //}

        //public ActionResult Maintenance()
        //{
        //    PipingRockUAEntities db = new PipingRockUAEntities();

        //    var users = (from User in db.Users select User).ToList();

        //    return View(users);
        //}

        //public ActionResult BottleChart()
        //{
        //    PipingRockUAEntities db = new PipingRockUAEntities();
        //    var bottles = (from Bottle in db.Bottles select Bottle).ToList();

        //    ViewBag.Bottles = bottles;

        //    return View();
        //}

        //public ActionResult Edit(string userId)
        //{
        //    PipingRockUAEntities db = new PipingRockUAEntities();
        //    int ID = Int32.Parse(userId);

        //    var roles = (from User in db.Users
        //                 join User_UserRole in db.User_UserRole on User.UserId equals User_UserRole.UserId
        //                 join UserRole in db.UserRoles on User_UserRole.UserRoleId equals UserRole.UserRoleId
        //                 where User_UserRole.UserId == ID
        //                 select new UsersAndRolesModel
        //                 {
        //                     UserID = User.UserId,
        //                     UserName = User.UserName,
        //                     RoleID = UserRole.UserRoleId,
        //                     RoleName = UserRole.UserRoleName
        //                 }).ToList();

        //    if (roles.Count == 0)
        //    {
        //        var user = db.GetUserByID(ID).ToList();
        //        roles.Add(new UsersAndRolesModel
        //        {
        //            UserID = ID,
        //            UserName = user[0].UserName,
        //            RoleID = 0,
        //            RoleName = "Don't have any roles"
        //        });
        //    }

        //    var otherRoles = (from UserRole in db.UserRoles 
        //                      select UserRole).ToList();

        //    //ViewBag.OtherRoles = db.GetAllNotActiveUserRoles(ID);
        //    ViewBag.OtherRoles = roles;
        //    ViewBag.ActiveRoles = roles;

        //    return View();
        //}

        //public ActionResult Add(string param)
        //{
        //    return View(param);
        //}

        //public ActionResult AddSubmit(string txtName, string txtRole)
        //{
        //    PipingRockUAEntities db = new PipingRockUAEntities();

        //    int userRoleID = Int32.Parse(txtRole);
        //    db.AddUser(txtName);
        //    var user = db.GetUser(txtName).ToList();
        //    db.AddRoleUserID(user[0].UserId, userRoleID);
        //    return RedirectToAction("Maintenance");
        //}
        #endregion
    }
}