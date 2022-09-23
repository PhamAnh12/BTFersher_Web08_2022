<template>
      <div class="content__footer">
          <div class="content__footer_letf">Tổng số <b>999</b> bản ghi</div>
          <div class="content__footer__right">
            <div class="select__page">
              <select name="" id="">
                <option value="">10 bản ghi trên 1 trang</option>
                <option value="">20 bản ghi trên 1 trang</option>
                <option value="">30 bản ghi trên 1 trang</option>
                <option value="">50 bản ghi trên 1 trang</option>
                <option value="">100 bản ghi trên 1 trang</option>
              </select>
            </div>
            <div class="page">
              <div class="page--dislabel page__text">Trước</div>
              <div class="page__number pageing__number--active">1</div>
              <div class="page__number">2</div>
              <div class="page__number">3</div>
              <div class="page__icon">...</div>
              <div class="page__number">52</div>
              <div class="page__text">Sau</div>
            </div>
          </div>
        </div>
</template>
<script>

export default {
   name: "PageComponent" 
}
</script>
