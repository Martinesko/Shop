using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shop.Data.Models;
using Shop.Models.Category;
using Shop.Models.Color;
using Shop.Models.Make;
using Shop.Models.ModelType;
using Shop.Models.Size;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.Product
{
    public class AddProductViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Model Name is required.")]
        public string ModelName { get; set; }

        [Required(ErrorMessage = "Make is required.")]
        public int MakeId { get; set; }

        [Required(ErrorMessage = "Model Type is required.")]
        public int ModelTypeId { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Image Url is required.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "Size is required.")]
        public int SizeId { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        public ICollection<MakeViewModel> Makes { get; set; } = new List<MakeViewModel>();

        public ICollection<ModelTypeViewModel> ModelTypes { get; set; } = new List<ModelTypeViewModel>();

        public ICollection<ProductColorViewModel> Colors { get; set; } = new List<ProductColorViewModel>();

        public ICollection<ProductCategoryViewModel> Categories { get; set; } = new List<ProductCategoryViewModel>();

        public ICollection<ProductSizeViewModel> Sizes { get; set; } = new List<ProductSizeViewModel>();
    }
}
