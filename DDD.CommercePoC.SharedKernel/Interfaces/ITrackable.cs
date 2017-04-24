using DDD.CommercePoC.SharedKernel.Enums;

namespace DDD.CommercePoC.SharedKernel.Interfaces
{
    public interface ITrackable
    {
        TrackingState TrackingState { get; set; }
    }
}