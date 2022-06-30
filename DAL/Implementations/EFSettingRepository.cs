using Core.EFRepository.EFEntityRepository;
using DAL.Abstracts;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class EFSettingRepository : EfEntityRepositoryBase<Setting,AppDbContext >, ISettingDal
    {
        private readonly AppDbContext _context;
        public EFSettingRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, string>> GetAllSettingsAsync()
        {
            Dictionary<string,string> settings = await _context.Settings.ToDictionaryAsync(n => n.Key, n => n.Value);
            return settings;
        }
    }
}
