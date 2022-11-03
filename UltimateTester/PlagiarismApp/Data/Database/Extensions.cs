using System.Text;

namespace PlagiarismApp.Data.Database
{

    public partial class Student
    {
        public string FullName
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Surname);
                sb.Append(' ');
                sb.Append(FirstName);
                if (!string.IsNullOrEmpty(Patronymic))
                {
                    sb.Append(' ');
                    sb.Append(Patronymic);
                }
                return sb.ToString();
            }
        }
    }
}
