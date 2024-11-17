using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportApp_Infrastructure
{
    public static class ErrorMessage
    {
        // Acount
        public static string EmailNotExist = "Email không tồn tại";
        public static string WrongPassword = "Mật khẩu bị sai.";
        public static string EmailExist = "Email đã tồn tại";
        // Owner
        public static string OwnerNotExist = "Chủ sân không tồn tại";
        // SportField
        public static string SportFieldExist = "Sân thể thao đã tồn tại";
        public static string SportFieldNameExist = "Tên sân đã tồn tại";
        public static string SportFieldNotExist = "Sân thể thao không tồn tại";
        // Sport
        public static string SportExist = "Môn thể thao đã tồn tại";
        public static string SportNotExist = "Môn thể thao không tồn tại";
        // Category
        public static string CategoryExist = "Loại trang thiết bị này đã tồn tại";
        public static string CategoryNotExist = "Loại trang thiết bị này không tồn tại";
        // SubCategory 
        public static string SubCategoryExist = "SubCategory đã tồn tại";
        public static string SubCategoryNotExist = "SubCategory không tồn tại";
        // SportTeam
        public static string SportTeamExist = "Câu lạc bộ thể thao đã tồn tại";
        public static string SportTeamNotExist = "Câu lạc bộ thể thao không tồn tại";
        // SportProduct
        public static string SportProductExist = "Trang thiết bị đã tồn tại";

    }
}
