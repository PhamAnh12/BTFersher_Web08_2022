import enumeration from "./enumeration";
export default {

    newEmployeeCode() {
        try {

            fetch("http://localhost:5108/api/v1/Employees/new-code")
              .then((res) => res.json())
              .then((res) => {
            
                return  res;
              })
              .catch((error) => {
                console.log("Error! Could not reach the API. " + error);
              });
           
          } catch (error) {
            console.log(error);
          } 
      

    },
    /*
     * Hàm dùng để format ngày tháng hiện thị danh sách employee
     * PCTUANANH(12/09/2022)
     */
    formatDate(dateSrc) {
       
        try {
            if(dateSrc){
                let date = new Date(dateSrc),
                year = date.getFullYear().toString(),
                month = (date.getMonth() + 1).toString().padStart(2, '0'),
                day = date.getDate().toString().padStart(2, '0');
               return `${day}/${month}/${year}`;
            }
          
        } catch (error) {
            console.log(error)
        }

    },
    /*
     * Hàm dùng để format ngày tháng hiện thị danh sách employee form nhập
     * PCTUANANH(12/09/2022)
     */
    formatDate2(dateSrc) {
        try {
            if(dateSrc){
                let date = new Date(dateSrc);
                date = date.toISOString().substring(0, 10);
                return date;
            }
          

        } catch (error) {
            console.log(error);

        }

    },
    /*
     * Hàm dùng để  chuyển đổi giới tính từ các số "0,1,2"sang "Nam, Nữ, Khác" 
     * PCTUANANH(16/09/2022)
     */
    formatGender(gender) {
        try {
            let GenderName;
            switch (gender) {
                case 0:
                    GenderName = enumeration.GenderName.Male;
                    break;
                case 1:
                    GenderName = enumeration.GenderName.Female
                    break;
                case 2:
                    GenderName = enumeration.GenderName.Other;
                    break;
                default: 
                   GenderName = '';
            }
            return GenderName;
        } catch (error) {
            console.log(error);
        }
    
    

    },
    /*
     * Hàm dùng để format ngày tháng hiện thị danh sách employee
     * PCTUANANH(12/09/2022)
     */
    maxDate() {
       
        try {
        
                let date = new Date(),
                year = date.getFullYear().toString(),
                month = (date.getMonth() + 1).toString().padStart(2, '0'),
                day = date.getDate().toString().padStart(2, '0');
               return `${year}-${month}-${day}`;
            
          
        } catch (error) {
            console.log(error)
        }

    },
}