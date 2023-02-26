using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccess.Repository
{
    public class MemberResponsitory : IMemberResponsitory
    {
        public List<Member> GetMembers()=> MemberDAO.Instance.GetMembers();
        public void Register(Member member) => MemberDAO.Instance.Register(member);
        public void Update(Member member)=> MemberDAO.Instance.UpdateMember(member);
        public void RemoveAcc(Member member) => MemberDAO.Instance.RemoveAcc(member);
        public Member Login (string acc,string pass)=>MemberDAO.Instance.Login(acc, pass);
    }
}
