import EmployeeList from '../view/employee/EmployeeList.vue'
import Overview from '../view/overview/Overview.vue'
import Deposits from '../view/overview/Deposits.vue'
import Purchase from '../view/overview/Purchase.vue'
import Sale from '../view/overview/Sale.vue'
import Management from '../view/overview/Management.vue'
import Warehouse from '../view/overview/Warehouse.vue'
import Tool from '../view/overview/Tool.vue'
import Fixed_assets from '../view/overview/FixedAssets.vue'
import Tax from '../view/overview/Tax.vue'
import Pice from '../view/overview/Pice.vue'
import Synthetic from '../view/overview/Synthetic.vue'
import Budget from '../view/overview/Budget.vue'
import Report from '../view/overview/Report.vue'
import Financial_analysis from '../view/overview/FinancialAnalysis.vue'


import {createRouter,createWebHistory} from "vue-router"
// Định nghĩa router:
const routers = [
    {path:"/",component: Overview },
    {path:"/employee",component: EmployeeList},
    {path:"/deposits",component: Deposits },
    {path:"/purchase",component:  Purchase },
    {path:"/sale",component: Sale },
    {path:"/management",component: Management },
    {path:"/warehouse",component: Warehouse },
    {path:"/tool",component: Tool },
    {path:"/fixed-assets",component: Fixed_assets },
    {path:"/tax",component: Tax },
    {path:"/pice",component: Pice },
    {path:"/synthetic",component: Synthetic },
    {path:"/budget",component: Budget},
    {path:"/report",component: Report },
    {path:"/financial-analysis",component: Financial_analysis },
    
]
// Khỏi tạo router 
 const router = createRouter({
    history: createWebHistory(),
    routes: routers,
    linkActiveClass: 'active-link',
    linkExactActiveClass: 'exact-active-link',
 })
 export default router
 