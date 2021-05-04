using CosmeticShop.Models.AuxiliaryEntities;
using CosmeticShop.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] ByteImage { get; set; }

        [NotMapped]
        private IFormFile _image;
        [NotMapped]
        public IFormFile Image
        {
            get => _image;
            set
            {
                _image = value;
                Name = _image.FileName;
                ByteImage = GetBytesFromFile(_image);
            }
        }

        private byte[] GetBytesFromFile(IFormFile formFile)
        {
            using (var stream = new MemoryStream())
            {
                formFile.CopyTo(stream);
                return stream.ToArray();
            }
        }

        public int? ProductPicturesId { get; set; }
        public ProductPictures ProductPictures { get; set; }
    }
}
