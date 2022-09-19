using System;

namespace Generator
{
    /// <summary>
    /// That class helps u to generate both Random IDs and Passwords for ur Employees
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// It gives u the last recorded ID;
        /// </summary>
        private static int LastIdSequence { get; set; } = 54596;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="HireDate"></param>
        /// <returns>The random ID which consists of the first letter of both fname and lname + yyMMdd + THE NEXT ID</returns>
        public static string GenerateID(string FirstName, string LastName, DateTime? HireDate)
        {
            // I(fname) I(lname) yy MM dd LastSequence
            if (FirstName is null) throw new InvalidOperationException($"{nameof(FirstName)} Cannot be null.");
            if (LastName is null) throw new InvalidOperationException($"{nameof(FirstName)} Cannot be null.");
            if (HireDate is null) { HireDate = DateTime.Now.Date; }
            else { if (HireDate.Value.Date > DateTime.Now.Date) throw new InvalidOperationException($"{nameof(HireDate)} Cannot be in the future."); }
            
            var yy = HireDate.Value.ToString("yy");
            var MM = HireDate.Value.ToString("MM");
            var dd = HireDate.Value.ToString("dd");

            var ID = $"{FirstName.ToUpper()[0]}{LastName.ToUpper()[0]}{yy}{MM}{dd}{(LastIdSequence++).ToString().PadLeft(2, '0')}";
            
            return ID;
        }
        /// <summary>
        /// Generate a password with length u have given before
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GeneratePassword(int length)
        {
            const string ValidScope = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#%*()$?+-=";
            
            Random rnd = new Random();
            var Password = "";

            while (0 < length--)
            {
                Password += ValidScope[rnd.Next(ValidScope.Length)];
            }
            
            return Password;
        }
        
    }
}
