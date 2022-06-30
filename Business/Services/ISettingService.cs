﻿using Business.Base;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ISettingService: IBaseService<Setting>
    {
        Task<Dictionary<string, string>> GetAllSettings();

    }
}
