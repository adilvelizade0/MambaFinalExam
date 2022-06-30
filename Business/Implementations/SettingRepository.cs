using Business.Services;
using DAL.Abstracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class SettingRepository : ISettingService
    {
        private readonly ISettingDal _settingRepository;

        public SettingRepository(ISettingDal settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public Task Create(Setting entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Setting entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Setting> Get(int? id)
        {
            if (id is null)
            {
                throw new ArgumentNullException();
            }

            var data = await _settingRepository.GetAsync(n => n.Id == id);
            if (data is null)
            {
                throw new NullReferenceException();
            }

            return data;

        }

        public async Task<List<Setting>> GetAll()
        {
            var data = await _settingRepository.GetAllAsync();
            return data;
        }

        public Task<Dictionary<string, string>> GetAllSettings()
        {
            throw new NotImplementedException();
        }

        public async Task Update(Setting entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            await _settingRepository.UpdateAsync(entity);
        }
    }
}
