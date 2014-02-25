using System.ComponentModel.DataAnnotations;
using CalorieTracker.Models.Enum;
using CalorieTracker.Models.MetaData;

namespace CalorieTracker.Models
{
    [MetadataType(typeof (NutrientRDAMetaData))]
    public partial class NutrientRDA
    {
        public NutritionType UnitTypeEnum
        {
            get { return (NutritionType) UnitType; }
            set { UnitType = (int) value; }
        }
    }
}