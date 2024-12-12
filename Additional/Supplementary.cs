using back.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace back.Additional
{
    public class Supplementary
    {
        public string MakeHash(string a)
        {
            byte[] Data = Encoding.UTF8.GetBytes(a);
            byte[] HashedData = SHA512.HashData(Data);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < HashedData.Length; i++)
            {
                builder.Append(HashedData[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public async Task<string> Id_creator()
        {
            var ID = Guid.NewGuid();
            string id = ID.ToString();
            var db = new AppDbContext();
            var existingUser = await db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser != null)
            {
                id = await Id_creator();
            }
            return id;
        }

    }
}




