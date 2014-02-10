using System.ComponentModel.DataAnnotations;
using CalorieTracker.Models.MetaData;

namespace CalorieTracker.Models
{
    [MetadataType(typeof (ActivityMetaData))]
    public partial class Activity
    {
    }
}