<template>
    
    <div>
         <div class="navbar">
            <div class="navbar__header">
                <div class="item__icon">
                    <div class="icon__18 icon__total"></div>
                </div>

                <div class="navbar__header__content">
                    <a href="/" class="item__link__logo">
                    <img class="item__logo" src="../../assets/img/Logo_Module_TiengViet_White.66947422.svg" alt="" />
                    </a>                  
                </div>
            </div>
            <div class="navbar__main">
                <router-link to="/" class="navbar__item " refs="item__navbar" >
                    <div class="item__icon">
                        <div class="icon__18 icon icon__overview" ></div>
                    </div>
                    <div class="navbar__item-text">Tổng quan</div>
                </router-link>
                <router-link to="/employee" class="navbar__item " refs="item__navbar">
                    <div class="item__icon">
                        <div class="icon__18 icon icon__employee"></div>
                    </div>
                    <div class="navbar__item-text">Nhân viên</div>
                </router-link>

                <router-link to="/deposits" class="navbar__item" refs="item__navbar">
                    <div class="item__icon">
                        <div class="icon__18 icon icon__deposits"></div>
                    </div>
                    <div class="navbar__item-text">Tiền gửi</div>
                </router-link>
                <router-link to="/purchase" class="navbar__item" refs="item__navbar">
                    <div class="item__icon">
                        <div class="icon__18 icon icon_purchase"></div>
                    </div>
                    <div class="navbar__item-text">Mua hàng</div>
                </router-link>
                <router-link to="/sale" class="navbar__item" refs="item__navbar">
                    <div class="item__icon">
                        <div class="icon__18  icon icon__sale"></div>
                    </div>
                    <div class="navbar__item-text">Bán hàng</div>
                </router-link>
                <router-link to="/management" class="navbar__item" refs="item__navbar">
                    <div class="item__icon">
                        <div class="icon__18  icon icon__management"></div>
                    </div>
                    <div class="navbar__item-text">Quản lý hóa đơn</div>
                </router-link>
                <router-link to="/warehouse" class="navbar__item" refs="item__navbar">
                    <div class="item__icon">
                        <div class="icon__18  icon icon__warehouse"></div>
                    </div>
                    <div class="navbar__item-text">Kho</div>
                </router-link>
                <router-link to="/tool" class="navbar__item" refs="item__navbar">
                    <div class="item__icon">
                        <div class="icon__18 icon icon__tool"></div>
                    </div>
                    <div class="navbar__item-text">Công cụ dụng cụ</div>
                </router-link>
                <router-link to="/fixed-assets" class="navbar__item" refs="item__navbar">
                    <div class="item__icon">
                        <div class="icon__18 icon icon__fixed-assets"></div>
                    </div>
                    <div class="navbar__item-text">Tài sản cố định</div>
                </router-link>
                <router-link to="/tax" class="navbar__item" refs="item__navbar">
                    <div class="item__icon">
                        <div class="icon__18 icon icon__tax"></div>
                    </div>
                    <div class="navbar__item-text">Thuế</div>
                </router-link>
                <router-link to="/pice" class="navbar__item" refs="item__navbar">
                    <div class="item__icon">
                        <div class="icon__18 icon icon__pice"></div>
                    </div>
                    <div class="navbar__item-text">Giá thành</div>
                </router-link>
                <router-link to="/synthetic" class="navbar__item" refs="item__navbar">
                    <div class="item__icon">
                        <div class="icon__18  icon icon__synthetic"></div>
                    </div>
                    <div class="navbar__item-text">Tổng hợp</div>
                </router-link>
                <router-link to="/budget" class="navbar__item" refs="item__navbar">
                    <div class="item__icon">
                        <div class="icon__18 icon icon__budget"></div>
                    </div>
                    <div class="navbar__item-text" >Ngân sách</div>
                </router-link>
                <router-link to="/report" class="navbar__item" refs="item__navbar">
                    <div class="item__icon">
                        <div class="icon__18  icon icon__report"></div>
                    </div>
                    <div class="navbar__item-text">Báo cáo</div>
                </router-link>
                <router-link to="/financial-analysis" class="navbar__item" refs="item__navbar">
                    <div class="item__icon">
                        <div class="icon__18 icon icon__analysis"></div>
                    </div>
                    <div class="navbar__item-text">Phân tích tài chính</div>
                </router-link>
            </div>
           
        </div>
    </div>
</template>
<script>
export default {
  name: 'NavBarComponent',
  
 
}
</script>