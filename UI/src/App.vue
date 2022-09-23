<template>
  <NavBarComponent></NavBarComponent>
  <div class="main">
   <HeaderComponent></HeaderComponent>
   <ContentComponents></ContentComponents>
  </div>
</template>

<script>

import NavBarComponent from './components/layout/NavBar.vue';
import HeaderComponent from './components/layout/Header.vue';
import ContentComponents from './components/layout/Content.vue'

export default {
  name: 'App',
  components: {
    NavBarComponent,
    HeaderComponent,
    ContentComponents,
    
  }
}
</script>

<style>
@import url(./assets/css/main.css); 
@import url(./assets/css/layout/employee.css);
</style>
