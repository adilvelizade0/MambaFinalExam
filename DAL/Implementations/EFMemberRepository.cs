using Core.EFRepository.EFEntityRepository;
using DAL.Abstracts;
using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implementations
{
    public class EFMemberRepository : EfEntityRepositoryBase<Member, AppDbContext>, IMemberDal
    {
        public EFMemberRepository(AppDbContext context) : base(context)
        {
        }
    }
}
