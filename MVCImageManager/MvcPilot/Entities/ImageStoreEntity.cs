using System.Collections.Generic;
using System.Linq;
using MvcPilot.DbContext;
using MvcPilot.Models;

namespace MvcPilot.Entities
{
    public class ImageStoreEntity
    {
        ImageStoreDbContext imageStoreDbContext = new ImageStoreDbContext();
        public IEnumerable<ImageStore> GetAll()
        {
           
            return imageStoreDbContext.ImageStores.ToList();
        }

        public void Inset(ImageStore imageStore)
        {
            imageStoreDbContext.ImageStores.Add(imageStore);
            imageStoreDbContext.SaveChanges();
        }
    }



}