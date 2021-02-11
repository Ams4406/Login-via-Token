using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenLogin.Models;

namespace TokenLogin.DAL
{
    interface IAssetRepository
    {
        List<asset> DisplayAssets();
        asset SearchAssetByID(int ID);
        asset SearchAssetByName(string Name);
        asset Login(string Email, string Password);
        bool InsertAsset(asset OurAsset);
        bool UpdateAsset(asset OurAsset);
        bool DeleteAsset(int ID);
    }
}
