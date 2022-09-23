<template>
  <!-- Form nhập -->
  <div class="modal">
    <div class="modal__container">
      <div class="modal__content">
        <div class="modal__header">
          <div class="modal__header__left">
            <h1 class="header__title">Thông tin nhân viên</h1>
            <input class="" type="checkbox" id="" />
            <label for="">Là khách hàng</label>
            <input class="" type="checkbox" id="" />
            <label for="">Là nhà cung cấp</label>
          </div>
          <div class="modal__header__rigth">
            <div class="item__icon modal__header__icon">
              <div class="icon__18 icon__help"></div>
            </div>
            <div
              class="item__icon modal__header__icon margin__letf_8"
              @click="isCloseModal"
            >
              <div class="icon__18 icon__close"></div>
            </div>
          </div>
        </div>
        <div class="modal__body">
          <div class="modal__body__row">
            <div class="body__row__left">
              <div class="container__input input__160">
                <label class="input__label" for=""
                  >Mã <span class="required">*</span>
                </label>
                <input
                  id="empCode"
                  tabindex="1"
                  class="input"
                  type="text"
                  v-model="employee.employeeCode"
                  ref="empCode"
                  required
                  proname="employeeCode"
                />
              </div>
              <div class="container__input input__margin_6 input__320">
                <label class="input__label" for=""
                  >Họ và tên <span class="required">*</span></label
                >
                <input
                  tabindex="2"
                  class="input"
                  type="text"
                  v-model="employee.employeeName"
                  required
                />
              </div>
            </div>
            <div class="body__row__rigth">
              <div class="container__input input__160">
                <label class="input__label" for=""> Ngày sinh </label>
                <input
                  tabindex="3"
                  class="input input_date"
                  type="date"
                  :max="maxDate"
                  v-model="employee.dateOfBirth"
                />
              </div>
              <div class="container__input input__margin_16 input__320">
                <label class="input__label" for=""> Giới tính </label>
                <div class="container__gender">
                  <input
                    type="radio"
                    name="gender"
                    id="male"
                    value="0"
                    tabindex="4"
                    checked
                    v-model="employee.gender"
                  />
                  <label for="male">Nam</label>
                  <input
                    type="radio"
                    name="gender"
                    id="female"
                    value="1"
                    v-model="employee.gender"
                  />
                  <label for="">Nữ</label>
                  <input
                    type="radio"
                    name="gender"
                    id="other"
                    value="2"
                    v-model="employee.gender"
                  />
                  <label for="other">Khác</label>
                </div>
              </div>
            </div>
          </div>
          <div class="modal__body__row">
            <div class="body__row__left">
              <div class="container__input input__480">
                <label class="input__label" for=""
                  >Đơn vị <span class="required">*</span></label
                >
                <!-- <mCombobox
                  :url="`http://localhost:3000/department`"
                  propValue="departmentID"
                  propText="departmentName"
                  v-model="employee.departmentID"
                  required
                ></mCombobox> -->

                <input
                  tabindex="5"
                  class="input"
                  type="text"
                  v-model="employee.departmentName"
                />
              </div>
            </div>
            <div class="body__row__rigth">
              <div class="container__input input__320">
                <label class="input__label" for="">Số CMND</label>
                <input
                  tabindex="7"
                  class="input"
                  type="text"
                  v-model="employee.identityNumber"
                />
              </div>
              <div class="container__input input__margin_6 input__160">
                <label class="input__label" for="">Ngày cấp</label>
                <input
                  tabindex="8"
                  class="input input_date"
                  :max="maxDate"
                  type="date"
                  v-model="employee.identityIssuedDate"
                />
              </div>
            </div>
          </div>
          <div class="modal__body__row">
            <div class="body__row__left">
              <div class="container__input input__480">
                <label class="input__label" for="">Chức danh</label>
                <input
                  tabindex="6"
                  class="input"
                  type="text"
                  v-model="employee.positionName"
                />
              </div>
            </div>
            <div class="body__row__rigth">
              <div class="container__input input__480">
                <label class="input__label" for="">Nơi cấp</label>
                <input
                  tabindex="9"
                  class="input"
                  type="text"
                  v-model="employee.identityIssuedPlace"
                />
              </div>
            </div>
          </div>
          <div class="modal__body__row margin__top_16">
            <div class="container__input">
              <label class="input__label" for="">Địa chỉ</label>
              <input
                tabindex="10"
                class="input"
                type="text"
                v-model="employee.address"
              />
            </div>
          </div>
          <div class="modal__body__row">
            <div class="container__input input__240">
              <label class="input__label" for="">ĐT di động </label>
              <input
                tabindex="11"
                class="input"
                type="text"
                v-model="employee.phoneNumberMobile"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for="">ĐT có định </label>
              <input
                tabindex="12"
                class="input"
                type="text"
                v-model="employee.phoneNumberLandline"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for="">Email </label>
              <input
                tabindex="13"
                class="input"
                type="text"
                v-model="employee.email"
              />
            </div>
          </div>
          <div class="modal__body__row">
            <div class="container__input input__240">
              <label class="input__label" for="">Tài khoản ngân hàng </label>
              <input
                tabindex="14"
                class="input"
                type="text"
                v-model="employee.accountBank"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for="">Tên ngân hàng </label>
              <input
                tabindex="15"
                class="input"
                type="text"
                v-model="employee.nameBank"
              />
            </div>
            <div class="container__input input__margin_6 input__240">
              <label class="input__label" for=""> Chi nhánh </label>
              <input
                tabindex="16"
                class="input"
                type="text"
                v-model="employee.branchBank"
              />
            </div>
          </div>
        </div>
        <div class="modal__footer">
          <div class="btn__base content__center" @click="closeModal">Hủy</div>
          <div class="modal__footer__rigth">
            <div class="btn__base content__center" @click="saveModal">Cất</div>
            <div class="btn margin__letf_8" @click="saveModalAdd">
              Cất và thêm
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <DialogFormClose
    v-if="isCloseForm"
    @closeModal="closeModal"
    @hideCloseForm="hideCloseForm"
    @saveModal="saveModal"
  ></DialogFormClose>
</template>
<script>
import Common from "../../script/common/common";
import Enumeration from "../../script/common/enumeration";
import DialogFormClose from "../../components/base/DialogFormClose.vue";
// import mCombobox from "ms-combobox";
export default {
  name: "EmployeeDetailComponent",
  components: {
    DialogFormClose,
  },
  props: {
    employeeSelect: Object,

    formMode: Number,
    newCode: String,
  },
  // Khai báo các emit từ componet cha
  emits: ["notLoadingData", "loadingData", "hideModal", "showModal"],
  created() {
    this.employee = this.employeeSelect;
   
  },
  mounted() {
    
    /*
     *Dùng để focus vào ô đầu tiên
     */
    this.$refs.empCode.focus();
     /*
     *Dùng để thêm một mã nhân viên tự động tăng
     */
    this.newEmployeeCode();

    /*
     *Dùng để format ngày tháng
     */
    this.formatDateEmployee();
    
  },
  watch: {},
  data() {
    return {
      employee: {},
      isCloseForm: false,
      maxDate: Common.maxDate(),
    };
  },
  methods: {
    ///
    /// Các hàm  dùng để format
    ///
    /*
     * Hàm dùng để format form khi lưu vào
     * PCTUANANH(16/09/2022)
     */
    formatInputForm() {
      try {
        this.traneGenderNumber();
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để format ngày tháng trong employee
     * PCTUANANH(16/09/2022)
     */
    formatDateEmployee() {
      try {
        if (this.formMode == Enumeration.FormMode.Edit) {
          this.employee.dateOfBirth = Common.formatDate2(
            this.employee.dateOfBirth
          );
          this.employee.identityIssuedDate = Common.formatDate2(
            this.employee.identityIssuedDate
          );
        }
      } catch (error) {
        console.log(error);
      }
    },

    /*
     * Hàm dùng để format giới tính từ chuỗi sang số
     * PCTUANANH(16/09/2022)
     */
    traneGenderNumber() {
      try {
        if (!this.employee.gender) {
          this.employee.gender = 0;
        } else {
          this.employee.gender = Number(this.employee.gender);
        }
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để  thêm mới một mã nhân viên tự động tăng
     * PCTUANANH(13/09/2022)
     */
    newEmployeeCode() {
      try {
        if (this.formMode == Enumeration.FormMode.Add) {
          fetch("http://localhost:5108/api/v1/Employees/new-code")
            .then((res) => res.text())
            .then((res) => {
              console.log(res);
              this.employee.employeeCode = res;
            })
            .catch((error) => {
              console.log("Error! Could not reach the API. " + error);
            });
        }
      } catch (error) {
        console.log(error);
      }
    },
    ///
    /// Các hàm để xử  lý đóng
    ///
    /*
     * Hàm dùng để đóng modal bằng nút Hủy
     * PCTUANANH(18/09/2022)
     */
    closeModal() {
      try {
        this.$emit("notLoadingData");
        this.$emit("hideModal");
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để đóng modal bằng nút X
     * PCTUANANH(18/09/2022)
     */
    isCloseModal() {
      try {
        this.isCloseForm = true;
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để ẩn form close bằng nút hủy
     * PCTUANANH(18/09/2022)
     */
    hideCloseForm() {
      try {
        this.isCloseForm = false;
      } catch (error) {
        console.log(error);
      }
    },
    ///
    /// Các hàm dùng để lưu
    ///
    /*
     * Hàm dùng để lưu  modal
     * PCTUANANH(12/09/2022)
     */
    saveModal() {
      try {
        // sửa nhân viên
        if (this.formMode === Enumeration.FormMode.Edit) {
          this.saveEditEmlpoyee();
        }
        // thêm mới nhân viên
        else if (this.formMode === Enumeration.FormMode.Add) {
          this.saveAddEmlpoyee();
        }
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để lưu  modal và thêm mới modal
     * PCTUANANH(12/09/2022)
     */
    saveModalAdd() {
      try {
        this.saveModal();
        this.$emit("showModal");
      } catch (error) {
        console.log(error);
      }
    },
    ///
    /// Các hàm  để  thêm, sửa  gọi đến API
    ///
    /*
     * Hàm dùng để gọi api để sửa nhân viên
     * PCTUANANH(16/09/2022)
     */
    saveEditEmlpoyee() {
      try {
        this.formatInputForm();
        let data = this.employee;
        let url = `http://localhost:5108/api/v1/Employees/${this.employee.employeeID}`;
        fetch(url, {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(data),
        })
          .then((response) => response.json())
          .then(() => {
            this.$emit("loadingData");
            this.$emit("hideModal");
          })
          .catch((error) => {
            console.log(data);
            console.error("Error:", error);
          });
      } catch (error) {
        console.log(error);
      }
    },
    /*
     * Hàm dùng để gọi api để thêm mới nhân viên
     * PCTUANANH(16/09/2022)
     */
    saveAddEmlpoyee() {
      try {
        this.formatInputForm();
        this.employee.departmentID = "59d19422-6657-452e-a7db-e5d54223c257";
        let data = this.employee;
        let url = `http://localhost:5108/api/v1/Employees`;
        fetch(url, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(data),
        })
          .then((response) => response.json())
          .then((response) => {
            console.log(response);
            this.$emit("loadingData");
            this.$emit("hideModal");
          })
          .catch((error) => {
            console.error("Error:", error);
          });
      } catch (error) {
        console.log(error);
      }
    },
  },
};
</script>
