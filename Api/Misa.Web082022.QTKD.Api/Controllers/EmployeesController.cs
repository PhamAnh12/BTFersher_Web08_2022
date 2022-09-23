using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misa.Web082022.QTKD.API.Entities.DTO;
using Misa.Web082022.QTKD.API.Enums;
using Misa.Web082022.QTKD.API.Properties;
using MISA.Web082022.QTKD.Api.Entities;
using MySqlConnector;
using Swashbuckle.AspNetCore.Annotations;


namespace MISA.WebDev2022.Api.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /// <summary>
        /// Chuỗi kết nối đến Database
        /// </summary>        
        private const string mySqlconnectionString = "Server=localhost;Port=3306;Database=misa.web08.qtkd.pctuananh;Uid=root;Pwd=root;";

        #region GetPaging API

        /// <summary>
        /// API Lấy danh sách nhân viên cho phép lọc và phân trang
        /// </summary>
        /// <param name="search">Tìm kiếm theo Số điện thoại, tên, Mã nhân viên</param>
        /// <param name="sort">  Sắp xếp</param>
        /// <param name="limit">Số trang muốn lấy</param>
        /// <param name="offset">Thứ tự trang muốn lấy</param>
        /// <returns>Một đối tượng gồm:
        /// + Danh sách nhân viên thỏa mãn điều kiện lọc và phân trang
        /// + Tổng số nhân viên thỏa mãn điều kiện</returns>
        /// Created by: PCTUANANH(12/07/2022)
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(PagingData<Employee>))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult FilterEmployees([FromQuery] string? search, [FromQuery] string? sort, [FromQuery] int limit = 100, [FromQuery] int offset = 0)
        {
            try
            {
                // Khởi tạo kết nối tới DB MySQL
                string connectionString = mySqlconnectionString;
                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị tên Stored procedure
                string storedProcedureName = "Proc_Employee_GetPaing";

                // Chuẩn bị tham số đầu vào cho stored procedure
                var parameters = new DynamicParameters();
                parameters.Add("v_Offset", offset);
                parameters.Add("v_Limit", limit);
                parameters.Add("v_Sort", sort);
                string whereCondition = "";
                if (search != null)
                {
                    whereCondition = $" EmployeeCode LIKE   \'%{search}%\' OR EmployeeName LIKE  \'%{search}%\'";
                }
                parameters.Add("v_Where", whereCondition);

                // Thực hiện gọi vào DB để chạy stored procedure với tham số đầu vào ở trên
                var multipleResults = mySqlConnection.QueryMultiple(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý kết quả trả về từ DB
                if (multipleResults != null)
                {
                    var employees = multipleResults.Read<Employee>();
                    var totalCount = multipleResults.Read<long>().Single();
                    return StatusCode(StatusCodes.Status200OK, new PagingData<Employee>()
                    {
                        Data = employees.ToList(),
                        TotalCount = totalCount
                    }) ; 
                }
                else
                {
                  return StatusCode(StatusCodes.Status404NotFound, new ErrorResult(
                  QTKDErrorCode.ResultDatabaseFailed,
                 "It was not possible to connect to the redis server(s)",
                 "Không tìm danh sách nhân viên",
                 "https://openapi.misa.com.vn/errorcode/e002",
                 HttpContext.TraceIdentifier
                )
            );
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(                   
                     QTKDErrorCode.Exception,
                     "It was not possible to connect to the redis server(s)",
                     "Có lỗi xảy ra.Vui lòng liên hệ Misa",
                     "https://openapi.misa.com.vn/errorcode/e001",
                     HttpContext.TraceIdentifier
                    )
                ); 
            }
        }

        #endregion

        #region  Get By ID API

        /// <summary>
        /// API Lấy thông tin chi tiết của 1 nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn lấy thông tin chi tiết</param>
        /// <returns>Đối tượng nhân viên muốn lấy thông tin chi tiết</returns>
        /// Created by: PCTUANANH(12/07/2022)
        [HttpGet("{employeeID}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Employee))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetEmployeeByID([FromRoute] Guid employeeID)
        {
            try
            {
                // Khởi tạo kết nối tới DB MySQL
                string connectionString = mySqlconnectionString;
                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị tên Stored procedure
                string storedProcedureName = "Proc_Employee_GetByEmployeeID";

                // Chuẩn bị tham số đầu vào cho stored procedure
                var parameters = new DynamicParameters();
                parameters.Add("v_EmployeeID", employeeID);

                // Thực hiện gọi vào DB để chạy stored procedure với tham số đầu vào ở trên
                var employee = mySqlConnection.QueryFirstOrDefault<Employee>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý kết quả trả về từ DB

                // Thành công
                if (employee != null)
                {
                    return StatusCode(StatusCodes.Status200OK, employee);
                }
                // Thất bại
                else
                {
                  
                    return StatusCode(StatusCodes.Status404NotFound, new ErrorResult(
                   QTKDErrorCode.ResultDatabaseFailed,
                  "It was not possible to connect to the redis server(s)",
                  "Không tìm thấy nhân viên",
                  "https://openapi.misa.com.vn/errorcode/e002",
                  HttpContext.TraceIdentifier
                 )
             );
                }
            }
            // Try catch exception
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, "e001"); return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                     QTKDErrorCode.Exception,
                     "It was not possible to connect to the redis server(s)",
                      "Có lỗi xảy ra.Vui lòng liên hệ Misa",
                     "https://openapi.misa.com.vn/errorcode/e001",
                     HttpContext.TraceIdentifier
                    )
                );
            }
        }

        #endregion

        #region Get New-Code API

        /// <summary>
        /// API Lấy mã nhân viên mới tự động tăng
        /// </summary>
        /// <returns>Mã nhân viên mới tự động tăng</returns>
        /// Created by: PCTUANANH(12/07/2022)
        [HttpGet("new-code")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(Employee))]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult GetNewEmployeeCode()
        {
            try
            {
                // Khởi tạo kết nối tới DB MySQL
                string connectionString = mySqlconnectionString;
                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị tên stored procedure
                string storedProcedureName = "Proc_Employee_GetMaxEmployeeCode";

                // Thực hiện gọi vào DB để chạy stored procedure ở trên
                string maxEmployeeCode = mySqlConnection.QueryFirstOrDefault<string>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);
                string newEmployeeCode = "";
                // Xử lý sinh mã nhân viên mới tự động tăng
                // Cắt chuỗi mã nhân viên lớn nhất trong hệ thống để lấy phần số
                // Mã nhân viên mới = "NV0" + Giá trị cắt chuỗi ở  trên + 1
                if (maxEmployeeCode.Substring(0, 4) == "NV00")
                {
                    newEmployeeCode = "NV00" + (Int64.Parse(maxEmployeeCode.Substring(4)) + 1).ToString();

                }
               else if (maxEmployeeCode.Substring(0,3) == "NV0")
                {
                    newEmployeeCode = "NV0" + (Int64.Parse(maxEmployeeCode.Substring(3)) + 1).ToString();

                }
                else if(maxEmployeeCode.Substring(0, 2) == "NV")
                {
                    newEmployeeCode = "NV" + (Int64.Parse(maxEmployeeCode.Substring(2)) + 1).ToString();

                }


                // Trả về dữ liệu cho client
                return StatusCode(StatusCodes.Status200OK, newEmployeeCode);
            }
               
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                     QTKDErrorCode.Exception,
                     "It was not possible to connect to the redis server(s)",
                      "Có lỗi xảy ra.Vui lòng liên hệ Misa",
                     "https://openapi.misa.com.vn/errorcode/e001",
                     HttpContext.TraceIdentifier
                    )
                );

            }
        }

        #endregion

        #region  POST Eployee API 

        /// <summary>
        /// API thêm mới một nhân viên 
        /// <param name="employee">Đối tượng nhân viên mới</param>
        /// <returns>ID của nhân viên vừa thêm mới</returns>
        /// </summary>
        /// Created by: PCTUANANH(22/09/2022)
        [HttpPost]
        public IActionResult InsertEmployee([FromBody] Employee employee)
        {
            try
            {  // Khởi tạo kết nối tới DB MySQL
                string connectionString = mySqlconnectionString;
                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị tên stored procedure
                string storedProcedureName = "Proc_Employee_InsertEmployee";

                // Chuẩn bị tham số đầu vào cho câu lệnh INSERT INTO
                var employeeID = Guid.NewGuid();
                var parameters = new DynamicParameters();
                parameters.Add("v_EmployeeID", employeeID);
                parameters.Add("v_EmployeeCode", employee.EmployeeCode);
                parameters.Add("v_EmployeeName", employee.EmployeeName);
                parameters.Add("v_DateOfBirth", employee.DateOfBirth);
                parameters.Add("v_Gender", employee.Gender);
                parameters.Add("v_DepartmentID", employee.DepartmentID);
                parameters.Add("v_IdentityNumber", employee.IdentityNumber);
                parameters.Add("v_IdentityIssuedDate", employee.IdentityIssuedDate);
                parameters.Add("v_IdentityIssuedPlace", employee.IdentityIssuedPlace);
                parameters.Add("v_PositionName", employee.PositionName);
                parameters.Add("v_Address", employee.Address);
                parameters.Add("v_MobilePhoneNumber", employee.MobilePhoneNumber);
                parameters.Add("v_LandlinePhoneNumber", employee.LandlinePhoneNumber);
                parameters.Add("v_Email", employee.Email);
                parameters.Add("v_AccountBank", employee.AccountBank);
                parameters.Add("v_NameBank", employee.NameBank);
                parameters.Add("v_BranchBank", employee.BranchBank);
                parameters.Add("v_CreatedDate", DateTime.Now);
                parameters.Add("v_CreatedBy", "Admin");
                parameters.Add("v_ModifiedDate", DateTime.Now);
                parameters.Add("v_ModifiedBy", "Admin");

                // Thực hiện gọi vào DB để chạy câu lệnh INSERT INTO với tham số đầu vào ở trên
                int numberOfAffectedRows = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý kết quả trả về từ DB
                if (numberOfAffectedRows > 0)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status201Created, employeeID);
                }
                else {

                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                    QTKDErrorCode.ResultDatabaseFailed,
                     Resource.DevMsg_InsertFailed,
                     Resource.UserMsg_InsertFailed,
                     Resource.MoreInfo_InsertFailed,
                     HttpContext.TraceIdentifier
                   )
               );
                }

            }
            catch (MySqlException mySqlException)
            {
                // TODO: Sau này có thể bổ sung log lỗi ở đây để khi gặp exception trace lỗi cho dễ
                if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                      QTKDErrorCode.DuplicateCode,
                      "It was not possible to connect to the redis server(s)",
                      "Mã nhân viên không được trùng nhau",
                      "https://openapi.misa.com.vn/errorcode/e003",
                      HttpContext.TraceIdentifier
                     )
                 );
                }
                Console.WriteLine(mySqlException.Message);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                    QTKDErrorCode.Exception,
                    "It was not possible to connect to the redis server(s)",
                     "Có lỗi xảy ra.Vui lòng liên hệ Misa",
                    "https://openapi.misa.com.vn/errorcode/e001",
                    HttpContext.TraceIdentifier
                   )
               );
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                     QTKDErrorCode.Exception,
                     "It was not possible to connect to the redis server(s)",
                      "Có lỗi xảy ra.Vui lòng liên hệ Misa",
                     "https://openapi.misa.com.vn/errorcode/e001",
                     HttpContext.TraceIdentifier
                    )
                );

            }
        }

        #endregion

        #region PUT API 

        /// <summary>
        /// API sửa một nhân viên 
        /// <param name="employeeID">ID của nhân viên muốn sửa</param>
        /// <param name="employee">Đối tượng nhân viên muốn sửa</param>
        /// <returns>ID của nhân viên vừa sửa</returns>
        /// </summary>
        /// Created by: PCTUANANH(18/09/2022)
        [HttpPut("{employeeID}")]
        public IActionResult UpdateEmployee([FromRoute] Guid employeeID, [FromBody] Employee employee)
        {

            try
            {  // Khởi tạo kết nối tới DB MySQL
                string connectionString = mySqlconnectionString;
                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị tên stored procedure
                string storedProcedureName = "Proc_Employee_UpdateEmployee";

                // Chuẩn bị tham số đầu vào cho câu lệnh INSERT INTO
                var parameters = new DynamicParameters();
                parameters.Add("v_EmployeeID", employeeID);
                parameters.Add("v_EmployeeCode", employee.EmployeeCode);
                parameters.Add("v_EmployeeName", employee.EmployeeName);
                parameters.Add("v_DateOfBirth", employee.DateOfBirth);
                parameters.Add("v_Gender", employee.Gender);
                parameters.Add("v_DepartmentID", employee.DepartmentID);
                parameters.Add("v_IdentityNumber", employee.IdentityNumber);
                parameters.Add("v_IdentityIssuedDate", employee.IdentityIssuedDate);
                parameters.Add("v_IdentityIssuedPlace", employee.IdentityIssuedPlace);
                parameters.Add("v_PositionName", employee.PositionName);
                parameters.Add("v_Address", employee.Address);
                parameters.Add("v_MobilePhoneNumber", employee.MobilePhoneNumber);
                parameters.Add("v_LandlinePhoneNumber", employee.LandlinePhoneNumber);
                parameters.Add("v_Email", employee.Email);
                parameters.Add("v_AccountBank", employee.AccountBank);
                parameters.Add("v_NameBank", employee.NameBank);
                parameters.Add("v_BranchBank", employee.BranchBank);
                parameters.Add("v_CreatedDate", employee.CreatedDate);
                parameters.Add("v_CreatedBy", employee.CreatedBy);
                parameters.Add("v_ModifiedDate", DateTime.Now);
                parameters.Add("v_ModifiedBy", "Admin");

                // Thực hiện gọi vào DB để chạy câu lệnh INSERT INTO với tham số đầu vào ở trên
                int numberOfAffectedRows = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý kết quả trả về từ DB
                if (numberOfAffectedRows > 0)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, employeeID);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                    QTKDErrorCode.ResultDatabaseFailed,
                     Resource.DevMsg_UpdateFailed,
                     Resource.UserMsg_UpdateFailed,
                     Resource.MoreInfo_UpdateFailed,
                    HttpContext.TraceIdentifier
                   )
                  );

                }

            }
            catch (MySqlException mySqlException)
            {
                // TODO: Sau này có thể bổ sung log lỗi ở đây để khi gặp exception trace lỗi cho dễ
                if (mySqlException.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                    QTKDErrorCode.DuplicateCode,
                    "It was not possible to connect to the redis server(s)",
                    "Mã nhân viên không được trùng nhau",
                    "https://openapi.misa.com.vn/errorcode/e003",
                    HttpContext.TraceIdentifier
                    )
                   );
                }
                Console.WriteLine(mySqlException.Message);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                     QTKDErrorCode.Exception,
                     "It was not possible to connect to the redis server(s)",
                      "Có lỗi xảy ra.Vui lòng liên hệ Misa",
                     "https://openapi.misa.com.vn/errorcode/e001",
                     HttpContext.TraceIdentifier
                    )
                );
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                     QTKDErrorCode.Exception,
                     "It was not possible to connect to the redis server(s)",
                      "Có lỗi xảy ra.Vui lòng liên hệ Misa",
                     "https://openapi.misa.com.vn/errorcode/e001",
                     HttpContext.TraceIdentifier
                    )
                );

            }

        }

        #endregion

        #region Delete  Eployee API

        /// <summary>
        /// API xóa mới một nhân viên 
        /// <param name="employeeID">ID của nhân viên muốn xóa</param>
        /// <returns>ID của nhân viên vừa sửa</returns>
        /// </summary>
        ///Created by: PCTUANANH(18/09/2022)
        [HttpDelete("{employeeID}")]
        public IActionResult DeleteEmployee([FromRoute] Guid employeeID)
        {

            try
            {
                // Khởi tạo kết nối tới DB MySQL
                string connectionString = mySqlconnectionString;
                var mySqlConnection = new MySqlConnection(connectionString);

                // Chuẩn bị tên Stored procedure
                string storedProcedureName = "Proc_Employee_DeleteByEmployeeID";

                // Chuẩn bị tham số đầu vào cho stored procedure
                var parameters = new DynamicParameters();
                parameters.Add("v_EmployeeID", employeeID);

                // Thực hiện gọi vào DB để chạy câu lệnh DELETE với tham số đầu vào ở trên
                int numberOfAffectedRows = mySqlConnection.Execute(storedProcedureName, parameters,commandType: System.Data.CommandType.StoredProcedure);

                // Xử lý kết quả trả về từ DB
                if (numberOfAffectedRows > 0)
                {
                    // Trả về dữ liệu cho client
                    return StatusCode(StatusCodes.Status200OK, employeeID);
                }
                else
                {
                  return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                   QTKDErrorCode.ResultDatabaseFailed,
                   "It was not possible to connect to the redis server(s)",
                    "Xóa không thành công",
                   "https://openapi.misa.com.vn/errorcode/e002",
                   HttpContext.TraceIdentifier
                  )
                  );
                }
            }
            catch (Exception exception)
            {
                // TODO: Sau này có thể bổ sung log lỗi ở đây để khi gặp exception trace lỗi cho dễ
                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult(
                     QTKDErrorCode.Exception,
                     "It was not possible to connect to the redis server(s)",
                      "Có lỗi xảy ra.Vui lòng liên hệ Misa",
                     "https://openapi.misa.com.vn/errorcode/e001",
                     HttpContext.TraceIdentifier
                    )
                );
            }

        }

        #endregion

    }
}
