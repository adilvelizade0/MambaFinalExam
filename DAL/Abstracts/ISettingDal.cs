using Core.EFRepository;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstracts
{
    public interface ISettingDal: IRepositoryBase<Setting>
    {
        Task<Dictionary<string, string>> GetAllSettingsAsync();
    }
}
