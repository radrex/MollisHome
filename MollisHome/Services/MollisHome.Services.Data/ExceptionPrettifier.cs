namespace MollisHome.Services.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public static class ExceptionPrettifier
    {
        //---------------- FIELDS -----------------
        private static readonly Dictionary<string, string> constraints;

        //------------- CONSTRUCTORS --------------
        static ExceptionPrettifier()
        {
            constraints = new Dictionary<string, string>() 
            {
                { "AK_Categories_Name", "Cannot insert duplicate key in Categories. The duplicate key is ({0})" },
                { "AK_Colors_Name", "Cannot insert duplicate key in Colors. The duplicate key is ({0})" },
                { "AK_Genders_Name", "Cannot insert duplicate key in Genders. The duplicate key is ({0})" },
                { "AK_Sizes_Name", "Cannot insert duplicate key in Sizes. The duplicate key is ({0})" },
                { "AK_PromoCodes_Code", "Cannot insert duplicate key in Promo Codes. The duplicate key is ({0})" },

                { "AK_Materials_Name_Percentage", "Cannot insert duplicate key in Materials. The duplicate key is ({0}, {1})" },
                { "AK_Products_Name_CategoryId", "Cannot insert duplicate key in Products. The duplicate key is ({0}, {1})" },

                { "CHK_Material_Percentage", "Percentage must be in range [0-100]" },
                { "CHK_ProductStock_DiscountPercentage", "Discount Percentage must be in range [0-100]" },
                { "CHK_PromoCode_DiscountPercentage", "Discount Percentage must be in range [0-100]" },
            };
        }

        //--------------- METHODS -----------------
        public static string PrettifyExceptionMessage(string exceptionMessage)
        {
            string[] exMsgs = exceptionMessage.Split(new string[] { ". ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string keyDuplicityMsg = exMsgs.FirstOrDefault(x => x.Contains("The duplicate key value is"));
            
            List<string> arguments = new List<string>();
            if (keyDuplicityMsg != null)
            {
                arguments = exMsgs.FirstOrDefault(x => x.Contains("The duplicate key value is"))
                                  .Substring(keyDuplicityMsg.IndexOf("(")) // could be replaced with range operator
                                  .Split(new string[] { "(", ")", ".", ", " }, StringSplitOptions.RemoveEmptyEntries)
                                  .ToList();
            }

            return String.Format(constraints.FirstOrDefault(x => exceptionMessage.Contains(x.Key)).Value, arguments.ToArray());
        }
    }
}
