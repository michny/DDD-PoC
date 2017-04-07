using System.Collections.Generic;
using Castle.Core;
using DDD.CommercePoC.SharedKernel.Exceptions;

namespace DDD.CommercePoC.SharedKernel.Extensions
{
    /// <summary>
    /// This class is used to enable comparisson of <see cref="LifestyleType"/>s to determine which is longer. 
    /// </summary>
    public class LifeStyleComparer : IComparer<LifestyleType>
    {
        /// <summary>
        /// Compares two <see cref="LifestyleType"/>s to see which one is longer. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>-1 if x is shorter than y. 0 if x and y are equal. 1 if x is longer than y.</returns>
        public int Compare(LifestyleType x, LifestyleType y)
        {
            if (x == LifestyleType.PerWebRequest)
            {
                switch (y)
                {
                    case LifestyleType.PerWebRequest:
                        return 0;
                    case LifestyleType.Scoped: //Scoped is used for the Hybrid PerWebRequestTransient lifestyle. So we generally consider it "PerWebRequest"
                        return 0;
                    case LifestyleType.Singleton:
                        return -1;
                    case LifestyleType.Transient:
                        return 1;
                    default:
                        throw new UnexpectedWindsorLifeStyleException(y);
                }
            }
            if (x == LifestyleType.Scoped)//Scoped is used for the Hybrid PerWebRequestTransient lifestyle. So we generally consider it "PerWebRequest"
            {
                switch (y)
                {
                    case LifestyleType.PerWebRequest:
                        return 0;
                    case LifestyleType.Scoped: //Scoped is used for the Hybrid PerWebRequestTransient lifestyle. So we generally consider it "PerWebRequest"
                        return 0;
                    case LifestyleType.Singleton:
                        return -1;
                    case LifestyleType.Transient:
                        return 1;
                    default:
                        throw new UnexpectedWindsorLifeStyleException(y);
                }
            }
            if (x == LifestyleType.Singleton)
            {
                switch (y)
                {
                    case LifestyleType.PerWebRequest:
                        return 1;
                    case LifestyleType.Scoped: //Scoped is used for the Hybrid PerWebRequestTransient lifestyle. So we generally consider it "PerWebRequest"
                        return 1;
                    case LifestyleType.Singleton:
                        return 0;
                    case LifestyleType.Transient:
                        return 1;
                    default:
                        throw new UnexpectedWindsorLifeStyleException(y);
                }
            }
            if (x == LifestyleType.Transient)
            {
                switch (y)
                {
                    case LifestyleType.PerWebRequest:
                        return -1;
                    case LifestyleType.Singleton:
                        return -1;
                    case LifestyleType.Scoped: //Scoped is used for the Hybrid PerWebRequestTransient lifestyle. So we generally consider it "PerWebRequest"
                        return -1;
                    case LifestyleType.Transient:
                        return 0;
                    default:
                        throw new UnexpectedWindsorLifeStyleException(y);
                }
            }
            throw new UnexpectedWindsorLifeStyleException(x);
        }
    }
}