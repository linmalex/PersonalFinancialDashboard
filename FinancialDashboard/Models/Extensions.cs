using System.Text;

namespace FinancialDashboard.Models
{
    public static class Extensions
    {
        public static string SplitString(string camelCasedWord)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(char.ToUpper(camelCasedWord[0]));
            for (int i = 1; i < camelCasedWord.Length; i++)
            {
                if (char.IsUpper(camelCasedWord[i]))
                {
                    stringBuilder.Append(" " + camelCasedWord[i]);
                }
                else
                {
                    stringBuilder.Append(camelCasedWord[i]);
                }
            }
            return stringBuilder.ToString();

        }

    }
}
