using CosmeticShop.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.AuxiliaryEntities
{
    public class ProductPictures
    {

        public int Id { get; set; }

        public List<Picture> Pictures { get; set; }
        public int? PreviewNnmber { get; set; }

        public async Task<byte[]> GetPreviewPicture()
        {
            if (Pictures != null && Pictures.Count() > 0)
                return Pictures[PreviewNnmber ?? 0].ByteImage;

            var loadDefaultPicture = await System.IO.File.ReadAllBytesAsync(@"../CosmeticShop/wwwroot/image/card/no_image.jpg");
            return loadDefaultPicture;
        }

        public int ProductContainerId { get; set; }
        public ProductContainer ProductContainer { get; set; }
    }
}
