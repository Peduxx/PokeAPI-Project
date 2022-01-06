using System.Text;

namespace KotasProject.Controllers.Utils
{
    public static class StringConvert
    {
        public static string FromStringToBase64(string String)
        {
            byte[] stringAsBytes = Encoding.ASCII.GetBytes(String);
            string result = System.Convert.ToBase64String(stringAsBytes);

            return result;
        }
    }
}