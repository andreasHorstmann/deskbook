using System.Runtime.Serialization;

namespace Core.Entities
{
    public enum Interval
    {
        [EnumMember(Value = "OneTimeOnly")]
        OneTimeOnly,
        [EnumMember(Value = "Daily")]
        Daily,
        [EnumMember(Value = "Weekly")]
        Weekly,
        [EnumMember(Value = "Monthly")]
        Monthly,
        [EnumMember(Value = "Yearly")]
        Yearly,
        [EnumMember(Value = "Custom")]
        Custom
    }
}
