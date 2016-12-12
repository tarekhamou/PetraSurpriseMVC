using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PetraSurpriseMvc.Models;
using System.Web.Mvc;
using CheckBoxList.Mvc;

namespace PetraSurpriseMvc.ViewModels
{
    [Table("Gift")]
    public class GiftListViewModel
    {
        private PetraSurpriseContext db = new PetraSurpriseContext();

        public X.PagedList.IPagedList<GiftListViewModel> Giftlist { get; set; }
        public List<CheckBoxItem> SelectedCategories { get; set; }
        public List<CheckBoxItem> SelectedThemes { get; set; }
        public List<CheckBoxItem> SelectedOccasions { get; set; }
        public List<CheckBoxItem> SelectedGiftsFor { get; set; }
        
        public GiftListViewModel()
        {
            var Categories = db.Categories.ToList();
            var Themes = db.Themes.ToList();
            var Occasions = db.Occasions.ToList();
            var GiftFor = db.GiftFors.ToList();

            SelectedCategories = new List<CheckBoxItem>();
            foreach (var item in Categories)
            {
                SelectedCategories.Add(new CheckBoxItem() { Name = item.Name, Id = item.ID, Checked = false });
            }

            SelectedThemes = new List<CheckBoxItem>();
            foreach (var item in Themes)
            {
                SelectedThemes.Add(new CheckBoxItem() { Name = item.Name, Id = item.ID, Checked = false });
            }

            SelectedOccasions = new List<CheckBoxItem>();
            foreach (var item in Occasions)
            {
                SelectedOccasions.Add(new CheckBoxItem() { Name = item.Name, Id = item.ID, Checked = false });
            }

            SelectedGiftsFor = new List<CheckBoxItem>();
            foreach (var item in GiftFor)
            {
                SelectedGiftsFor.Add(new CheckBoxItem() { Name = item.Name, Id = item.ID, Checked = false });
            }
        }
        
          


        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public string Photo { get; set; }

        public decimal? Price { get; set; }
 }
}