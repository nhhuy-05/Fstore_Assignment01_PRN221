using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IMemberResponsitory
    {
        List<Member> GetMembers();
        void Register(Member member);
        void Update(Member member);
        void RemoveAcc(Member member);
        Member Login(string acc, string pass);

    }
}
