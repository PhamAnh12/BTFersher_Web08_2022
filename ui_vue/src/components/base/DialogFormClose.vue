<template>
  <!-- dialog input -->
  <div class="dialog">
    <div class="dialog__container content__center">
      <div class="dialog__content">
        <div class="dialog__header"></div>
        <div class="dialog__body align__items__center">
          <div class="icon__ask"></div>

          <div class="dialog__body__text">
            Dữ liệu đã bị thay đổi. Bạn có muốn cất không
          </div>
        </div>
        <div class="dialog__footer align__items__center flex__between">
          <div class="btn__base content__center" @click="hideCloseForm"  @dblclick.stop  @click.stop >Hủy</div>
          <div class="flex__between">
            <div class="btn__base content__center" @click="closeModal" @dblclick.stop  @click.stop>
              Không
            </div>
            <div class="margin_left-8 btn content__center" @click="saveModal">Có</div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "DialogFormClose",
  emits:['closeModal','hideCloseForm','saveModal'],
  methods: {
    ///
    /// Các hàm để xử  lý đóng
    ///
     /*
     * Hàm dùng để đóng modal bằng nút không khi đóng modal bằng x thì có form close hiện nên
     * PCTUANANH(18/09/2022)
     */
    closeModal() {
      try {
        this.$emit("closeModal");
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
        this.$emit("hideCloseForm");
      } catch (error) {
        console.log(error);
      }
    },
    ///
    /// Các hàm  xử lý lưu
    ///
      /*
     * Hàm dùng để cất modal bằng nút có khi đóng modal bằng x thì có form close hiện nên
     * PCTUANANH(18/09/2022)
     */
    saveModal(){
        try {
        this.$emit("saveModal");
      } catch (error) {
        console.log(error);
      }
    }
  },
};
</script>
