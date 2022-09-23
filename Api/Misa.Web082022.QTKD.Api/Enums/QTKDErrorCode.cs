namespace Misa.Web082022.QTKD.API.Enums
{   

    /// <summary>
    /// Các mã lỗi
    /// </summary>
    public enum QTKDErrorCode
    {
        /// <summary>
        /// Lỗi do Exception
        /// </summary>
        Exception =  1,

        /// <summary>
        /// Lỗi khi lây, thêm ,sửa,xóa vào data không thành công
        /// </summary>
        ResultDatabaseFailed  = 2,

        /// <summary>
        /// Lỗi do trùng mã nhân viên
        /// </summary>
        DuplicateCode = 3,
       

    }
}
