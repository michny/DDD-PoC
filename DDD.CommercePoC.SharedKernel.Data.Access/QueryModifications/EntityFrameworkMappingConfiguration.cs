//using System.Collections.Generic;
//using System.Reflection;
//using DelegateDecompiler;

//namespace DDD.CommercePoC.SharedKernel.Data.Access.QueryModifications
//{
//    public class EntityFrameworkMappingConfiguration : DefaultConfiguration
//    {
//        private readonly HashSet<MemberInfo> members = new HashSet<MemberInfo>();

//        public void RegisterForDecompilation(MemberInfo member)
//        {
//            members.Add(member);
//        }
//        public override bool ShouldDecompile(MemberInfo member)
//        {
//            return members.Contains(member) || base.ShouldDecompile(member);
//        }
//    }
//}