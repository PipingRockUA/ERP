using PipingRockERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace PipingRockERP.Controllers
{
    public class MaintenanceController : Controller
    {
        public ActionResult UnitOfMeasures()
        {
            PipingRockUAEntities db = new PipingRockUAEntities();

            var measures = (from UnitOfMeasure in db.UnitOfMeasures select UnitOfMeasure).ToList();

            return View(measures);
        }

        public ActionResult Index()
        {
            PipingRockUAEntities db = new PipingRockUAEntities();

            var users = (from User in db.Users select User).ToList();

            return View(users);
        }

        public ActionResult BottleChart()
        {
            PipingRockUAEntities db = new PipingRockUAEntities();
            var bottles = (from Bottle in db.Bottles select Bottle).ToList();

            ViewBag.Bottles = bottles;

            return View();
        }

        #region Edit Users Profiles
        public ActionResult Edit(string userId)
        {
            PipingRockUAEntities db = new PipingRockUAEntities();
            int ID = Int32.Parse(userId);

            var roles = (from User in db.Users
                         join User_UserRole in db.User_UserRole on User.UserId equals User_UserRole.UserId
                         join UserRole in db.UserRoles on User_UserRole.UserRoleId equals UserRole.UserRoleId
                         where User_UserRole.UserId == ID
                         select new UsersAndRolesModel
                         {
                             UserID = User.UserId,
                             UserName = User.UserName,
                             RoleID = UserRole.UserRoleId,
                             RoleName = UserRole.UserRoleName
                         }).ToList();

            if (roles.Count == 0)
            {
                var user = db.GetUserByID(ID).ToList();
                roles.Add(new UsersAndRolesModel
                {
                    UserID = ID,
                    UserName = user[0].UserName,
                    RoleID = 0,
                    RoleName = "Don't have any roles"
                });
            }

            var otherRoles = (from UserRole in db.UserRoles
                              select UserRole).ToList();

            ViewBag.OtherRoles = db.GetNonActiveRoles(ID);
            ViewBag.ActiveRoles = roles;

            return View();
        }
        #endregion

        public ActionResult EditBottle(string bottleId)
        {
            PipingRockUAEntities db = new PipingRockUAEntities();
            int ID = Int32.Parse(bottleId);

            var bottle = (from Bottle in db.Bottles
                          where Bottle.BottleId == ID
                          select Bottle).ToList();

            ViewBag.Bottle = bottle;

            return View();
        }

        public ActionResult Add(string param)
        {
            return View(param);
        }

        public ActionResult AddUser()
        {
            PipingRockUAEntities db = new PipingRockUAEntities();
      
            var roles = (from UserRole in db.UserRoles
                              select UserRole).ToList();

            ViewBag.Roles = roles;

            return View();
        }

        public ActionResult AddUserRole(int userId, int roleId)
        {
            PipingRockUAEntities db = new PipingRockUAEntities();

            db.AddRoleUserID(userId, roleId);

            return RedirectToAction("Edit", new { userId = userId.ToString() });
        }

        public ActionResult RemoveUserRole(int userId, int roleId)
        {
            PipingRockUAEntities db = new PipingRockUAEntities();

            var usersAndRole = from User_UserRole in db.User_UserRole
                               where User_UserRole.UserId == userId && User_UserRole.UserRoleId == roleId
                               select User_UserRole;

            foreach (var row in usersAndRole)
            {
                db.User_UserRole.Remove(row);               
            }

            db.SaveChanges();

            return RedirectToAction("Edit", new { userId = userId.ToString() });
        }

        public ActionResult UserSubmitAdd(string userName, string roleName)
        {
            PipingRockUAEntities db = new PipingRockUAEntities();

            var roleId = (from UserRole in db.UserRoles
                          where UserRole.UserRoleName == roleName
                          select UserRole.UserRoleId).Single();

            db.AddUser(userName);
            var userId = (from User in db.Users
                         where User.UserName == userName
                         select User.UserId).Single();
            db.AddRoleUserID(userId, roleId);
            return RedirectToAction("Index");
        }

        public ActionResult SubmitBottleAdd(string BottleItemKey,
                                              string BottleDescription,
                                              int BottlesSmallTray,
                                              int BottlesLargeTray,
                                              int WrappedBottlesTrayLarge,
                                              int WrappedBottlesTraySmall,
                                              int ItemStatusId,
                                              int ItemTypeId,
                                              int ItemTypeDetailId,
                                              decimal BottleLength,
                                              decimal BottleWidth,
                                              decimal BottleHieght,
                                              decimal BottleCubicInches,
                                              decimal BottleLengthWrapped,
                                              decimal BottleWidthWrapped,
                                              decimal BottleDepthWrapped,
                                              decimal BottleCubicInchWrapped,
                                              decimal BottleLabelSquareInches)
        {
            PipingRockUAEntities db = new PipingRockUAEntities();
            var bottle = new Bottle() {
                BottleItemKey = BottleItemKey,
                BottleDescription = BottleDescription,
                BottlesSmallTray = BottlesSmallTray,
                BottlesLargeTray = BottlesLargeTray,
                WrappedBottlesTrayLarge = WrappedBottlesTrayLarge,
                WrappedBottlesTraySmall = WrappedBottlesTraySmall,
                ItemStatusId = ItemStatusId,
                ItemTypeId = ItemTypeId,
                ItemTypeDetailId = ItemTypeDetailId,
                BottleLength = (decimal)BottleLength,
                BottleWidth = (decimal)BottleWidth,
                BottleHieght = (decimal)BottleHieght,
                BottleCubicInches = (decimal)BottleCubicInches,
                BottleLengthWrapped = (decimal)BottleLengthWrapped,
                BottleWidthWrapped = (decimal)BottleWidthWrapped,
                BottleDepthWrapped = (decimal)BottleDepthWrapped,
                BottleCubicInchWrapped = (decimal)BottleCubicInchWrapped,
                BottleLabelSquareInches = (decimal)BottleLabelSquareInches,
                BottleAddedDate = DateTime.Now,
                BottleChangedDate = DateTime.Now,
                BottleModifiedById = 1,
                isDeleted = false
            };
            db.Bottles.Add(bottle);
            db.SaveChanges();
            return RedirectToAction("BottleChart");
        }

        public ActionResult SubmitBottleUpdate(string bottleId,
                                              string BottleItemKey,
                                              string BottleDescription,
                                              int BottlesSmallTray,
                                              int BottlesLargeTray,
                                              int WrappedBottlesTrayLarge,
                                              int WrappedBottlesTraySmall,
                                              int ItemStatusId,
                                              int ItemTypeId,
                                              int ItemTypeDetailId,
                                              decimal BottleLength,
                                              decimal BottleWidth,
                                              decimal BottleHieght,
                                              decimal BottleCubicInches,
                                              decimal BottleLengthWrapped,
                                              decimal BottleWidthWrapped,
                                              decimal BottleDepthWrapped,
                                              decimal BottleCubicInchWrapped,
                                              decimal BottleLabelSquareInches)
        {
            PipingRockUAEntities db = new PipingRockUAEntities();
            int ID = Int32.Parse(bottleId);
            var bottle = (from Bottle in db.Bottles
                          where Bottle.BottleId == ID
                          select Bottle).Single();
            
            bottle.BottleItemKey = BottleItemKey;
            bottle.BottleDescription = BottleDescription;
            bottle.BottlesSmallTray = BottlesSmallTray;
            bottle.BottlesLargeTray = BottlesLargeTray;
            bottle.WrappedBottlesTrayLarge = WrappedBottlesTrayLarge;
            bottle.WrappedBottlesTraySmall = WrappedBottlesTraySmall;
            bottle.ItemStatusId = ItemStatusId;
            bottle.ItemTypeId = ItemTypeId;
            bottle.ItemTypeDetailId = ItemTypeDetailId;
            bottle.BottleLength = (decimal)BottleLength;
            bottle.BottleWidth = (decimal)BottleWidth;
            bottle.BottleHieght = (decimal)BottleHieght;
            bottle.BottleCubicInches = (decimal)BottleCubicInches;
            bottle.BottleLengthWrapped = (decimal)BottleLengthWrapped;
            bottle.BottleWidthWrapped = (decimal)BottleWidthWrapped;
            bottle.BottleDepthWrapped = (decimal)BottleDepthWrapped;
            bottle.BottleCubicInchWrapped = (decimal)BottleCubicInchWrapped;
            bottle.BottleLabelSquareInches = (decimal)BottleLabelSquareInches;
            bottle.BottleChangedDate = DateTime.Now;
            bottle.BottleModifiedById = 1;

            db.Entry(bottle).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("BottleChart");
        }

    }
}