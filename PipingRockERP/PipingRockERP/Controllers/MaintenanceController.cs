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
        public ActionResult Index()
        {
            PipingRockEntities db = new PipingRockEntities();

            var users = (from User in db.Users select User).ToList();

            return View(users);
        }

        public ActionResult Add(string param)
        {
            return View(param);
        }

        public ActionResult UnitOfMeasures()
        {
            PipingRockEntities db = new PipingRockEntities();

            var measures = (from UnitOfMeasure in db.UnitOfMeasures select UnitOfMeasure).ToList();

            return View(measures);
        }

        #region Users Profiles
        public ActionResult AddUser()
        {
            PipingRockEntities db = new PipingRockEntities();

            var roles = (from UserRole in db.UserRoles
                         select UserRole).ToList();

            ViewBag.Roles = roles;

            return View();
        }

        public ActionResult AddUserRole(int userId, int roleId)
        {
            PipingRockEntities db = new PipingRockEntities();

            db.AddRoleUserID(userId, roleId);

            return RedirectToAction("Edit", new { userId = userId.ToString() });
        }

        public ActionResult Edit(string userId)
        {
            PipingRockEntities db = new PipingRockEntities();
            int ID = Int32.Parse(userId);

            var roles = (from User in db.Users
                         join User_UserRole in db.User_UserRole on User.UserId equals User_UserRole.UserId
                         join UserRole in db.UserRoles on User_UserRole.UserRoleId equals UserRole.UserRoleId
                         where User_UserRole.UserId == ID
                         orderby UserRole.UserRoleId
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

        public ActionResult RemoveUserRole(int userId, int roleId)
        {
            PipingRockEntities db = new PipingRockEntities();

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
            PipingRockEntities db = new PipingRockEntities();

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
        #endregion

        #region Bottle Chart
        public ActionResult BottleChart()
        {
            PipingRockEntities db = new PipingRockEntities();
            var bottles = (from Bottle in db.Bottles select Bottle).ToList();

            ViewBag.Bottles = bottles;

            return View();
        }

        public ActionResult EditBottle(string bottleId)
        {
            PipingRockEntities db = new PipingRockEntities();
            int ID = Int32.Parse(bottleId);

            var bottle = (from Bottle in db.Bottles
                          where Bottle.BottleId == ID
                          select Bottle).ToList();

            ViewBag.Bottle = bottle;

            return View();
        }

        public ActionResult SubmitBottleAdd(string BottleItemKey,
                                              string BottleDescription,
                                              int BottlesSmallTray,
                                              int BottlesLargeTray,
                                              int WrappedBottlesTrayLarge,
                                              int WrappedBottlesTraySmall,

                                              string BottleLengthInches,
                                              string BottleWidthInches,
                                              string BottleHieghtInches,
                                              string BottleCubicInches,

                                              string BottleLengthCm,
                                              string BottleWidthCm,
                                              string BottleHieghtCm,
                                              string BottleCubicCm,

                                              string BottleLengthWrappedCm,
                                              string BottleWidthWrappedCm,
                                              string BottleDepthWrappedCm,
                                              string BottleCubicInchWrappedCm,

                                              string BottleLengthWrappedInches,
                                              string BottleWidthWrappedInches,
                                              string BottleDepthWrappedInches,
                                              string BottleCubicInchWrappedInches,

                                              string BottleLabelSquareInches,
                                              string LabelSquareInches,
                                              string LabelSquareCm,

                                              string BottleSize,
                                              int PrintFrames,
                                              int NumberOfPrintingPositions)
        {
            PipingRockEntities db = new PipingRockEntities();

            var bottle = new Bottle() {
                BottleItemKey = BottleItemKey,
                BottleDescription = BottleDescription,
                BottlesSmallTray = BottlesSmallTray,
                BottlesLargeTray = BottlesLargeTray,
                WrappedBottlesTrayLarge = WrappedBottlesTrayLarge,
                WrappedBottlesTraySmall = WrappedBottlesTraySmall,
                ItemStatusId = 3,
                ItemTypeId = 2,
                ItemSubTypeId = 1,

                BottleLengthInches = Convert.ToDecimal(BottleLengthInches.Replace(".", ",")),
                BottleWidthInches = Convert.ToDecimal(BottleWidthInches.Replace(".", ",")),
                BottleHieghtInches = Convert.ToDecimal(BottleHieghtInches.Replace(".", ",")),
                BottleCubicInches = Convert.ToDecimal(BottleCubicInches.Replace(".", ",")),

                BottleLengthCm = Convert.ToDecimal(BottleLengthCm.Replace(".", ",")),
                BottleWidthCm = Convert.ToDecimal(BottleWidthCm.Replace(".", ",")),
                BottleHieghtCm = Convert.ToDecimal(BottleHieghtCm.Replace(".", ",")),
                BottleCubicCm = Convert.ToDecimal(BottleCubicCm.Replace(".", ",")),

                BottleLengthWrappedInches = Convert.ToDecimal(BottleLengthWrappedInches.Replace(".", ",")),
                BottleWidthWrappedInches = Convert.ToDecimal(BottleWidthWrappedInches.Replace(".", ",")),
                BottleDepthWrappedInches = Convert.ToDecimal(BottleDepthWrappedInches.Replace(".", ",")),
                BottleCubicInchWrappedInches = Convert.ToDecimal(BottleCubicInchWrappedInches.Replace(".", ",")),

                BottleLengthWrappedCm = Convert.ToDecimal(BottleLengthWrappedCm.Replace(".", ",")),
                BottleWidthWrappedCm = Convert.ToDecimal(BottleWidthWrappedCm.Replace(".", ",")),
                BottleDepthWrappedCm = Convert.ToDecimal(BottleDepthWrappedCm.Replace(".", ",")),
                BottleCubicInchWrappedCm = Convert.ToDecimal(BottleCubicInchWrappedCm.Replace(".", ",")),

                BottleLabelSquareInches = Convert.ToDecimal(BottleLabelSquareInches.Replace(".", ",")),
                LabelSquareInches = Convert.ToDecimal(LabelSquareInches.Replace(".", ",")),
                LabelSquareCm = Convert.ToDecimal(LabelSquareCm.Replace(".", ",")),

                BottleSize = BottleSize,
                PrintFrames = PrintFrames,
                NumberOfPrintingPositions = NumberOfPrintingPositions,
                is3rdParty = false,

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

                                              string BottleLengthInches,
                                              string BottleWidthInches,
                                              string BottleHieghtInches,
                                              string BottleCubicInches,

                                              string BottleLengthCm,
                                              string BottleWidthCm,
                                              string BottleHieghtCm,
                                              string BottleCubicCm,

                                              string BottleLengthWrappedCm,
                                              string BottleWidthWrappedCm,
                                              string BottleDepthWrappedCm,
                                              string BottleCubicInchWrappedCm,

                                              string BottleLengthWrappedInches,
                                              string BottleWidthWrappedInches,
                                              string BottleDepthWrappedInches,
                                              string BottleCubicInchWrappedInches,

                                              string BottleLabelSquareInches,
                                              string LabelSquareInches,
                                              string LabelSquareCm,

                                              string BottleSize,
                                              int PrintFrames,
                                              int NumberOfPrintingPositions)
        {
            PipingRockEntities db = new PipingRockEntities();
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
            bottle.ItemStatusId = 3;
            bottle.ItemTypeId = 2;
            bottle.ItemSubTypeId = 1;

            bottle.BottleLengthInches = Convert.ToDecimal(BottleLengthInches.Replace(".", ","));
            bottle.BottleWidthInches = Convert.ToDecimal(BottleWidthInches.Replace(".", ","));
            bottle.BottleHieghtInches = Convert.ToDecimal(BottleHieghtInches.Replace(".", ","));
            bottle.BottleCubicInches = Convert.ToDecimal(BottleCubicInches.Replace(".", ","));

            bottle.BottleLengthCm = Convert.ToDecimal(BottleLengthCm.Replace(".", ","));
            bottle.BottleWidthCm = Convert.ToDecimal(BottleWidthCm.Replace(".", ","));
            bottle.BottleHieghtCm = Convert.ToDecimal(BottleHieghtCm.Replace(".", ","));
            bottle.BottleCubicCm = Convert.ToDecimal(BottleCubicCm.Replace(".", ","));

            bottle.BottleLengthWrappedInches = Convert.ToDecimal(BottleLengthWrappedInches.Replace(".", ","));
            bottle.BottleWidthWrappedInches = Convert.ToDecimal(BottleWidthWrappedInches.Replace(".", ","));
            bottle.BottleDepthWrappedInches = Convert.ToDecimal(BottleDepthWrappedInches.Replace(".", ","));
            bottle.BottleCubicInchWrappedInches = Convert.ToDecimal(BottleCubicInchWrappedInches.Replace(".", ","));

            bottle.BottleLengthWrappedCm = Convert.ToDecimal(BottleLengthWrappedCm.Replace(".", ","));
            bottle.BottleWidthWrappedCm = Convert.ToDecimal(BottleWidthWrappedCm.Replace(".", ","));
            bottle.BottleDepthWrappedCm = Convert.ToDecimal(BottleDepthWrappedCm.Replace(".", ","));
            bottle.BottleCubicInchWrappedCm = Convert.ToDecimal(BottleCubicInchWrappedCm.Replace(".", ","));

            bottle.BottleLabelSquareInches = Convert.ToDecimal(BottleLabelSquareInches.Replace(".", ","));
            bottle.LabelSquareInches = Convert.ToDecimal(LabelSquareInches.Replace(".", ","));
            bottle.LabelSquareCm = Convert.ToDecimal(LabelSquareCm.Replace(".", ","));

            bottle.BottleSize = BottleSize;
            bottle.PrintFrames = PrintFrames;
            bottle.NumberOfPrintingPositions = NumberOfPrintingPositions;
            bottle.is3rdParty = false;

            bottle.BottleChangedDate = DateTime.Now;
            bottle.BottleModifiedById = 1;

            db.Entry(bottle).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("BottleChart");
        }
        #endregion

        #region Quarantine Types
        public ActionResult Quarantine()
        {
            PipingRockEntities db = new PipingRockEntities();

            var quarantineTypes = (from QuarantineType in db.Quarantine select QuarantineType).ToList();

            return View(quarantineTypes);
        }

        public ActionResult EditQuarantineType(string qtId)
        {
            PipingRockEntities db = new PipingRockEntities();
            int ID = Int32.Parse(qtId);

            var qt = (from QuarantineType in db.Quarantine
                          where QuarantineType.QuarantineTypeId == ID
                          select QuarantineType).ToList();

            ViewBag.QuarantineType = qt;

            return View();
        }

        public ActionResult SubmitQuarantineTypeAdd(string qtname)
        {
            PipingRockEntities db = new PipingRockEntities();

            var qt = new QuarantineType() {
                QuarantineType1 = qtname,
                QuarantineTypeAddedDate = DateTime.Now,
                QuarantineTypeChangedDate = DateTime.Now,
                QuarantineTypeModifiedById = 0,
                isDeleted = false
        };
            db.Quarantine.Add(qt);
            db.SaveChanges();
            return RedirectToAction("Quarantine");
        }

        public ActionResult SubmitQuarantineTypeUpdate(string qtId, string qtname)
        {
            PipingRockEntities db = new PipingRockEntities();

            int ID = Int32.Parse(qtId);
            var qt = (from QuarantineType in db.Quarantine
                          where QuarantineType.QuarantineTypeId == ID
                          select QuarantineType).Single();

            qt.QuarantineType1 = qtname;
            qt.QuarantineTypeChangedDate = DateTime.Now;

            db.Entry(qt).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Quarantine");
        }
        #endregion

        #region Storage Conditions
        public ActionResult StorageConditions()
        {
            PipingRockEntities db = new PipingRockEntities();

            var sc = (from StorageCondition in db.StorageConditions select StorageCondition).ToList();

            return View(sc);
        }

        public ActionResult EditStorageCondition(string scId)
        {
            PipingRockEntities db = new PipingRockEntities();
            int ID = Int32.Parse(scId);

            var sc = (from StorageCondition in db.StorageConditions
                      where StorageCondition.StorageConditionId == ID
                      select StorageCondition).ToList();

            ViewBag.StorageCondition = sc;

            return View();
        }

        public ActionResult SubmitStorageConditionAdd(string scname, string scdesc)
        {
            PipingRockEntities db = new PipingRockEntities();

            var sc = new StorageCondition()
            {
                StorageCondition1 = scname,
                StorageConditionDescription = scdesc,
                StorageConditionAddedDate = DateTime.Now,
                StorageConditionChangedDate = DateTime.Now,
                StorageConditionModifiedById = 0,
                isDeleted = false
            };
            db.StorageConditions.Add(sc);
            db.SaveChanges();
            return RedirectToAction("StorageConditions");
        }

        public ActionResult SubmitStorageConditionUpdate(string scId, string scname, string scdesc)
        {
            PipingRockEntities db = new PipingRockEntities();

            int ID = Int32.Parse(scId);
            var sc = (from StorageCondition in db.StorageConditions
                      where StorageCondition.StorageConditionId == ID
                      select StorageCondition).Single();

            sc.StorageCondition1 = scname;
            sc.StorageConditionDescription = scdesc;
            sc.StorageConditionChangedDate = DateTime.Now;

            db.Entry(sc).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("StorageConditions");
        }
        #endregion
    }
}