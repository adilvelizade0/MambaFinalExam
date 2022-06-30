using Business.Services;
using DAL.Abstracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class MemberRepository : IMemberService
    {
        private readonly IMemberDal _memberRepository;

        public MemberRepository(IMemberDal memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public async Task Create(Member entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException();
            }

            await _memberRepository.AddAsync(entity);
        }

        public async Task Delete(Member entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            await _memberRepository.DeleteAsync(entity);
        }

        public async Task<Member> Get(int? id)
        {
            if(id == null)
            {
                throw new ArgumentNullException();
            }

            var data = await _memberRepository.GetAsync(n => n.Id == id);

            if(data is null)
            {
                throw new NullReferenceException();
            }

            return data;
        }

        public async Task<List<Member>> GetAll()
        {
            var data = await _memberRepository.GetAllAsync();
            return data;
        }

        public async Task Update(Member entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            await _memberRepository.UpdateAsync(entity);
        }
    }
}
