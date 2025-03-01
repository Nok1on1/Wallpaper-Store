using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication1.Services;

public class WallpaperService
{
    private readonly StoreContext _context = new();

    public List<Wallpapers> GetWallpapers(int pageNum = 1, int pageSize = 10, Filters filters = null!)
    {
        var query = _context.Wallpapers.AsQueryable();

        foreach (var item in filters.CheckedWidthVariations)
        {
            query = query.Where(x => x.WWidth == item);
        }

        foreach (var item in filters.CheckedCompanyVariations)
        {
            query = query.Where(x => x.WCompany == item);
        }

        if (filters.DateFrom.Date != DateTimeOffset.UtcNow.Date)
        {
            query = query.Where(x => x.WProdDate.Date >= filters.DateFrom);
        }

        if (filters.DateTo.Day != DateTimeOffset.UtcNow.Day)
        {
            query = query.Where(x => x.WProdDate.Date <= filters.DateTo);
        }

        return query.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
    }


    public void AddWallpaper(Wallpapers wallpaper, Restock restock, string width, Bitmap image)
    {

        var seller = _context.Sellers.Find(restock.SName);
        if (seller is null)
        {
            seller = new Seller { SName = restock.SName };
            _context.Sellers.Add(seller);
        }

        wallpaper.WImage = ImageHelper.BitmapToBytes(image);
        wallpaper.WWidth = width;

        _context.Wallpapers.Add(wallpaper);

        restock.WCompany = wallpaper.WCompany;
        restock.WProdDate = wallpaper.WProdDate;
        restock.WId = wallpaper.WId;
        restock.Quantity = wallpaper.WQuantity;

        _context.Restocks.Add(restock);

        _context.SaveChanges();
    }


    public List<string> LoadWidthVariations()
    => _context.Wallpapers.Select(x => x.WWidth).Distinct().ToList();

    public List<string> LoadCompanyVariations()
    => _context.Wallpapers.Select(x => x.WCompany).Distinct().ToList();
}