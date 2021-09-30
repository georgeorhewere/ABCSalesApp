using System.Collections.Generic;

namespace ABCApp.Web.Models
{
    public  class DropDownViewModel
    {
        public DropDownViewModel(List<DropDownItemViewModel> items)
        {
            Results = items;
        }
        public bool Success { get; set; }
        public List<DropDownItemViewModel> Results { get; private set; }

    }
    public class DropDownItemViewModel
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Text { get; set; }

    }
}