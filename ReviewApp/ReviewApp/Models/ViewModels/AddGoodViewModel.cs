using System.ComponentModel.DataAnnotations;
using ReviewApp.Models.Dto;
namespace ReviewApp.Models.ViewModels;

public class AddGoodViewModel
{
    public GoodDto Good { get; set; }
    
    public IFormFile PostedFile { get; set; }
}