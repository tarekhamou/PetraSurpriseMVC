using PetraSurpriseMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using PetraSurpriseMvc.ViewModels;
using X.PagedList;

namespace PetraSurpriseMvc.Controllers
{
    public class GiftController : Controller
    {
        private PetraSurpriseContext db = new PetraSurpriseContext();

        // GET: Gift
        public ActionResult Index(int? page)


        {


            GiftListViewModel giftsList = new GiftListViewModel();

            if (Session["firstload"] == null)
            {
                giftsList.Giftlist = getgifts(500).OrderByDescending(i => i.ID).ToPagedList(page ?? 1, 9);
                Session["SelectedCategories"] = giftsList.SelectedCategories;
                Session["SelectedGiftsFor"] = giftsList.SelectedGiftsFor;
                Session["SelectedOccasions"] = giftsList.SelectedOccasions;
                Session["SelectedThemes"] = giftsList.SelectedThemes;
                Session["firstload"] = true;
            }
            else
            {

                giftsList.SelectedCategories = (List<CheckBoxItem>)Session["SelectedCategories"];
                giftsList.SelectedGiftsFor = (List<CheckBoxItem>)Session["SelectedGiftsFor"];
                giftsList.SelectedOccasions = (List<CheckBoxItem>)Session["SelectedOccasions"];
                giftsList.SelectedThemes = (List<CheckBoxItem>)Session["SelectedThemes"];
                string SelectedCategories = JoinStringList(giftsList.SelectedCategories);
                string SelectedThemes = JoinStringList(giftsList.SelectedThemes);
                string SelectedOccasions = JoinStringList(giftsList.SelectedOccasions);
                string SelectedGiftsFor = JoinStringList(giftsList.SelectedGiftsFor);


                giftsList.Giftlist = db.Database.SqlQuery<GiftListViewModel>(
                    "Exec SearchGifts @Themestring, @Occassionstring, @Giftforstring, @Category, @Title, @Highestprice, @Lowestprice",
                    new SqlParameter("Themestring", SelectedThemes),
                    new SqlParameter("Occassionstring", SelectedOccasions),
                    new SqlParameter("Giftforstring", SelectedGiftsFor),
                    new SqlParameter("Category", SelectedCategories),
                    new SqlParameter("Title", ""),
                    new SqlParameter("Highestprice", 100000),
                    new SqlParameter("Lowestprice", 1)
                    ).ToList().OrderByDescending(i => i.ID).ToPagedList(page ?? 1, 9);
            }


            return View(giftsList);
        }

        [HttpPost]
        public ActionResult Index( GiftListViewModel ReturnedInfo, int? page)
        {

            page = 1;
            Session["SelectedCategories"] = ReturnedInfo.SelectedCategories;
            Session["SelectedGiftsFor"] = ReturnedInfo.SelectedGiftsFor;
            Session["SelectedOccasions"] = ReturnedInfo.SelectedOccasions;
            Session["SelectedThemes"] = ReturnedInfo.SelectedThemes;

            string SelectedCategories = JoinStringList(ReturnedInfo.SelectedCategories);
            string SelectedThemes = JoinStringList(ReturnedInfo.SelectedThemes);
            string SelectedOccasions = JoinStringList(ReturnedInfo.SelectedOccasions);
            string SelectedGiftsFor = JoinStringList(ReturnedInfo.SelectedGiftsFor);
            ReturnedInfo.Giftlist = db.Database.SqlQuery<GiftListViewModel>(
                "Exec SearchGifts @Themestring, @Occassionstring, @Giftforstring, @Category, @Title, @Highestprice, @Lowestprice",
                new SqlParameter("Themestring", SelectedThemes),
                new SqlParameter("Occassionstring", SelectedOccasions),
                new SqlParameter("Giftforstring", SelectedGiftsFor),
                new SqlParameter("Category", SelectedCategories),
                new SqlParameter("Title", ""),
                new SqlParameter("Highestprice", 100000),
                new SqlParameter("Lowestprice", 1)
                ).ToList().OrderByDescending(i => i.ID).ToPagedList(page ?? 1, 9);

            return View(ReturnedInfo);
        }



        public List<GiftListViewModel> getgifts(int count)
        {
            return db.Gifts.Include("ID")
           .Include("Title")
           .Include("Icon").Include("Price").Take(500).Select(p => new GiftListViewModel()
           {
               ID = p.ID,
               Title = p.Title,
               Photo = p.Photo,
               Price = p.Price
           }).ToList();
        }

        private string JoinStringList(List<CheckBoxItem> checkboxlist)
        {
            
            string Result = string.Join(",", checkboxlist.Where(x => x.Checked == true));
           if (Result=="")
            { return string.Join(",", checkboxlist.Select(x => x.Id)); }
           else
            return Result;
        }

    }
}