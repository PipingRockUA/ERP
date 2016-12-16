using PipingRockERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using libxl;

namespace PipingRockERP.Controllers
{
    public class MaintenanceController : Controller
    {
        //Book book = new BinBook();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(string param)
        {
            return View(param);
        }

        #region Units of Measures
        public ActionResult UnitOfMeasures()
        {
            PipingRockEntities db = new PipingRockEntities();

            var measures = (from UnitOfMeasure in db.UnitOfMeasures select UnitOfMeasure).ToList();

            return View(measures);
        }

        public ActionResult ExportUnitOfMeasures()
        {
            PipingRockEntities db = new PipingRockEntities();
            try
            {
                Book book = new XmlBook(); // use XmlBook() for xlsx
                Sheet sheet = book.addSheet("Sheet1");

                var table = (from UnitOfMeasure in db.UnitOfMeasures
                             select new
                             {
                                 ID = UnitOfMeasure.UnitOfMeasureId,
                                 UnitOfMeasure = UnitOfMeasure.UnitOfMeasure1,
                                 Abbreviation = UnitOfMeasure.UnitOfMeasureAbbreviation,
                                 AddedDate = UnitOfMeasure.UnitOfMeasureAddedDate,
                                 ChangedDate = UnitOfMeasure.UnitOfMeasureChangedDate,
                                 DeletedDate = UnitOfMeasure.UnitOfMeasureDeletedDate,
                                 ModifiedById = UnitOfMeasure.UnitOfMeasureModifiedById,
                                 isDeleted = (UnitOfMeasure.isDeleted ? 1 : 0)
                             }).ToList();
                for (int j = 0; j < 8; j++)
                {
                    switch (j)
                    {
                        case 0:
                            {
                                for (int i = 2; i < table.Count + 1; i++)
                                {
                                    sheet.writeNum(i, j, table[i - 2].ID);
                                }
                                break;
                            }
                        case 1:
                            {
                                for (int i = 2; i < table.Count + 1; i++)
                                {
                                    sheet.writeStr(i, j, table[i - 2].UnitOfMeasure);
                                }
                                break;
                            }
                        case 2:
                            {
                                for (int i = 2; i < table.Count + 1; i++)
                                {
                                    sheet.writeStr(i, j, table[i - 2].Abbreviation);
                                }
                                break;
                            }
                        case 3:
                            {
                                for (int i = 2; i < table.Count + 1; i++)
                                {
                                    sheet.writeStr(i, j, table[i - 2].AddedDate.ToString());
                                }
                                break;
                            }
                        case 4:
                            {
                                for (int i = 2; i < table.Count + 1; i++)
                                {
                                    sheet.writeStr(i, j, table[i - 2].ChangedDate.ToString());
                                }
                                break;
                            }
                        case 5:
                            {
                                for (int i = 2; i < table.Count + 1; i++)
                                {
                                    sheet.writeStr(i, j, table[i - 2].DeletedDate.ToString());
                                }
                                break;
                            }
                        case 6:
                            {
                                for (int i = 2; i < table.Count + 1; i++)
                                {
                                    sheet.writeNum(i, j, table[i - 2].ModifiedById);
                                }
                                break;
                            }
                        case 7:
                            {
                                for (int i = 2; i < table.Count + 1; i++)
                                {
                                    sheet.writeNum(i, j, table[i - 2].isDeleted);
                                }
                                break;
                            }
                    }
                }
                book.save("example.xlsx");
                System.Diagnostics.Process.Start("example.xlsx");
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //GridView gv = new GridView();
            //gv.DataSource = (from UnitOfMeasure in db.UnitOfMeasures
            //                 select new
            //                 {
            //                     ID = UnitOfMeasure.UnitOfMeasureId,
            //                     UnitOfMeasure = UnitOfMeasure.UnitOfMeasure1,
            //                     Abbreviation = UnitOfMeasure.UnitOfMeasureAbbreviation,
            //                     AddedDate = UnitOfMeasure.UnitOfMeasureAddedDate,
            //                     ChangedDate = UnitOfMeasure.UnitOfMeasureChangedDate,
            //                     DeletedDate = UnitOfMeasure.UnitOfMeasureDeletedDate,
            //                     ModifiedById = UnitOfMeasure.UnitOfMeasureModifiedById,
            //                     isDeleted = (UnitOfMeasure.isDeleted ? 1 : 0)
            //                 }).ToList();
            //gv.GridLines = GridLines.Both;
            //gv.DataBind();
            //Response.ClearContent();
            //Response.AddHeader("content-disposition", "attachment; filename=UnitOfMeasures.xls");
            //Response.ContentType = "application/ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //gv.RenderControl(htw);
            //Response.Output.Write(sw.ToString());
            //Response.Flush();
            //Response.End();

            return RedirectToAction("UnitOfMeasures");
        }
        #endregion

        #region Users Profiles
        public ActionResult Users()
        {
            PipingRockEntities db = new PipingRockEntities();

            var users = (from User in db.Users select User).ToList();

            return View(users);
        }

        public ActionResult UserAdd()
        {
            PipingRockEntities db = new PipingRockEntities();

            var roles = (from UserRole in db.UserRoles
                         select UserRole).ToList();

            ViewBag.Roles = roles;

            return View();
        }

        public ActionResult UserAddRole(int userId, int roleId)
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

            db.UserAdd(userName);
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
            var bottles = (from Bottle in db.Bottle2 select Bottle).ToList();

            ViewBag.Bottles = bottles;

            return View();
        }

        public ActionResult BottleEdit(string bottleId)
        {
            PipingRockEntities db = new PipingRockEntities();
            int ID = Int32.Parse(bottleId);

            var bottle = (from Bottle in db.Bottle2
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

            var bottle = new Bottle2()
            {
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

                BottleAddedDate = DateTime.Now,
                BottleChangedDate = DateTime.Now,
                BottleModifiedById = 1,
                isDeleted = false
            };

            db.Bottle2.Add(bottle);
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
            var bottle = (from Bottle in db.Bottle2
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

            bottle.BottleChangedDate = DateTime.Now;
            bottle.BottleModifiedById = 1;

            db.Entry(bottle).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("BottleEdit", new { bottleId = bottleId });
        }

        public ActionResult ExportBottle()
        {
            PipingRockEntities db = new PipingRockEntities();

            GridView gv = new GridView();
            gv.DataSource = (from Bottle in db.Bottle2
                             select new
                             {
                                 ID = Bottle.BottleId,
                                 ItemKey = Bottle.BottleItemKey,
                                 Description = Bottle.BottleDescription,
                                 BottlesSmallTray = Bottle.BottlesSmallTray,
                                 BottlesLargeTray = Bottle.BottlesLargeTray,
                                 WrappedBottlesTraySmall = Bottle.WrappedBottlesTraySmall,
                                 WrappedBottlesTrayLarge = Bottle.WrappedBottlesTrayLarge,
                                 ItemStatusId = Bottle.ItemStatusId,
                                 ItemTypeId = Bottle.ItemTypeId,
                                 ItemSubTypeId = Bottle.ItemSubTypeId,
                                 BottleLengthInches = Bottle.BottleLengthInches,
                                 BottleWidthInches = Bottle.BottleWidthInches,
                                 BottleHieghtInches = Bottle.BottleHieghtInches,
                                 BottleCubicInches = Bottle.BottleCubicInches,
                                 BottleLengthCm = Bottle.BottleLengthCm,
                                 BottleWidthCm = Bottle.BottleWidthCm,
                                 BottleHieghtCm = Bottle.BottleHieghtCm,
                                 BottleCubicCm = Bottle.BottleCubicCm,
                                 BottleLengthWrappedInches = Bottle.BottleLengthWrappedInches,
                                 BottleWidthWrappedInches = Bottle.BottleWidthWrappedInches,
                                 BottleDepthWrappedInches = Bottle.BottleDepthWrappedInches,
                                 BottleCubicInchWrappedInches = Bottle.BottleCubicInchWrappedInches,
                                 BottleLengthWrappedCm = Bottle.BottleLengthWrappedCm,
                                 BottleWidthWrappedCm = Bottle.BottleWidthWrappedCm,
                                 BottleDepthWrappedCm = Bottle.BottleDepthWrappedCm,
                                 BottleCubicInchWrappedCm = Bottle.BottleCubicInchWrappedCm,
                                 BottleLabelSquareInches = Bottle.BottleLabelSquareInches,
                                 LabelSquareInches = Bottle.LabelSquareInches,
                                 LabelSquareCm = Bottle.LabelSquareCm,
                                 BottleSize = Bottle.BottleSize,
                                 PrintFrames = Bottle.PrintFrames,
                                 NumberOfPrintingPositions = Bottle.NumberOfPrintingPositions,
                                 AddedDate = Bottle.BottleAddedDate,
                                 ChangedDate = Bottle.BottleChangedDate,
                                 DeletedDate = Bottle.BottleDeletedDate,
                                 ModifiedById = Bottle.BottleModifiedById,
                                 isDeleted = (Bottle.isDeleted ? 1 : 0)
                             }).ToList();
            gv.GridLines = GridLines.Both;
            gv.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Bottles.xls");
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("BottleChart");
        }
        #endregion

        #region Quarantine Types
        public ActionResult Quarantines()
        {
            PipingRockEntities db = new PipingRockEntities();

            var quarantineTypes = (from Quarantine in db.Quarantines select Quarantine).ToList();

            return View(quarantineTypes);
        }

        public ActionResult QuarantineEdit(string qtId)
        {
            PipingRockEntities db = new PipingRockEntities();
            int ID = Int32.Parse(qtId);

            var qt = (from Quarantine in db.Quarantines
                          where Quarantine.QuarantineId == ID
                          select Quarantine).ToList();

            ViewBag.Quarantine = qt;

            return View();
        }

        public ActionResult SubmitQuarantineAdd(string qtname)
        {
            PipingRockEntities db = new PipingRockEntities();

            var qt = new Quarantine() {
                Quarantine1 = qtname,
                QuarantineAddedDate = DateTime.Now,
                QuarantineChangedDate = DateTime.Now,
                QuarantineModifiedById = 0,
                isDeleted = false
        };
            db.Quarantines.Add(qt);
            db.SaveChanges();
            return RedirectToAction("Quarantines");
        }

        public ActionResult SubmitQuarantineUpdate(string qtId, string qtname)
        {
            PipingRockEntities db = new PipingRockEntities();

            int ID = Int32.Parse(qtId);
            var qt = (from Quarantine in db.Quarantines
                          where Quarantine.QuarantineId == ID
                          select Quarantine).Single();

            qt.Quarantine1 = qtname;
            qt.QuarantineChangedDate = DateTime.Now;

            db.Entry(qt).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Quarantines");
        }

        public ActionResult ExportQuarantine()
        {
            PipingRockEntities db = new PipingRockEntities();

            GridView gv = new GridView();
            gv.DataSource = (from Quarantine in db.Quarantines
                             select new
                             {
                                 Id = Quarantine.QuarantineId,
                                 Quarantine = Quarantine.Quarantine1,
                                 AddedDate = Quarantine.QuarantineAddedDate,
                                 ChangedDate = Quarantine.QuarantineChangedDate,
                                 DeletedDate = Quarantine.QuarantineDeletedDate,
                                 ModifiedById = Quarantine.QuarantineModifiedById,
                                 isDeleted = (Quarantine.isDeleted ? 1 : 0)

                             }).ToList();
            gv.GridLines = GridLines.Both;
            gv.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Quarantines.xls");
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Quarantines");
        }
        #endregion

        #region Storage Conditions
        public ActionResult StorageConditions()
        {
            PipingRockEntities db = new PipingRockEntities();

            var sc = (from StorageCondition in db.StorageConditions select StorageCondition).ToList();

            return View(sc);
        }

        public ActionResult StorageConditionEdit(string scId)
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

        public ActionResult ExportStorageConditions()
        {
            PipingRockEntities db = new PipingRockEntities();

            GridView gv = new GridView();
            gv.DataSource = (from StorageCondition in db.StorageConditions
                             select new
                             {
                                 ID = StorageCondition.StorageConditionId,
                                 StorageCondition = StorageCondition.StorageCondition1,
                                 Description = StorageCondition.StorageConditionDescription,
                                 AddedDate = StorageCondition.StorageConditionAddedDate,
                                 ChangedDate = StorageCondition.StorageConditionChangedDate,
                                 DeletedDate = StorageCondition.StorageConditionDeletedDate,
                                 ModifiedById = StorageCondition.StorageConditionModifiedById,
                                 isDeleted = (StorageCondition.isDeleted ? 1 : 0)
                             }).ToList();
            gv.GridLines = GridLines.Both;
            gv.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=StorageConditions.xls");
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("StorageConditions");
        }
        #endregion

        #region Brands
        public ActionResult Brands()
        {
            PipingRockEntities db = new PipingRockEntities();

            var brands = (from Brand in db.Brands select Brand).ToList();

            return View(brands);
        }

        public ActionResult BrandEdit(string brandId)
        {
            PipingRockEntities db = new PipingRockEntities();
            int ID = Int32.Parse(brandId);

            var brand = (from Brand in db.Brands
                      where Brand.BrandID == ID
                      select Brand).ToList();

            ViewBag.Brand = brand;

            return View();
        }

        public ActionResult SubmitBrandAdd(string brandName, string brandCode)
        {
            PipingRockEntities db = new PipingRockEntities();

            var brand = new Brand()
            {
                Brand1 = brandName,
                BrandCode = brandCode,
                BrandAddedDate = DateTime.Now,
                BrandChangedDate = DateTime.Now,
                BrandModifiedById = 0,
                isDeleted = false
            };
            db.Brands.Add(brand);
            db.SaveChanges();
            return RedirectToAction("Brands");
        }

        public ActionResult SubmitBrandUpdate(string brandId, string brandName, string brandCode)
        {
            PipingRockEntities db = new PipingRockEntities();

            int ID = Int32.Parse(brandId);
            var brand = (from Brand in db.Brands
                      where Brand.BrandID == ID
                      select Brand).Single();

            brand.Brand1 = brandName;
            brand.BrandCode = brandCode;
            brand.BrandChangedDate = DateTime.Now;

            db.Entry(brand).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Brands");
        }

        public ActionResult ExportBrand()
        {
            PipingRockEntities db = new PipingRockEntities();

            GridView gv = new GridView();
            gv.DataSource = (from Brand in db.Brands
                             select new
                             {
                                 ID = Brand.BrandID,
                                 BrandCode = Brand.BrandCode,
                                 Brand = Brand.Brand1,
                                 AddedDate = Brand.BrandAddedDate,
                                 ChangedDate = Brand.BrandChangedDate,
                                 DeletedDate = Brand.BrandDeletedDate,
                                 ModifiedById = Brand.BrandModifiedById,
                                 isDeleted = (Brand.isDeleted ? 1 : 0)
                             }).ToList();
            gv.GridLines = GridLines.Both;
            gv.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Brands.xls");
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Brands");
        }
        #endregion
    }
}