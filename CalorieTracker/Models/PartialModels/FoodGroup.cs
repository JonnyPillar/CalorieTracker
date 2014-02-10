using System.ComponentModel.DataAnnotations;
using CalorieTracker.Models.MetaData;

namespace CalorieTracker.Models
{
    [MetadataType(typeof (FoodGroupMetaData))]
    public partial class FoodGroup
    {
    }
}