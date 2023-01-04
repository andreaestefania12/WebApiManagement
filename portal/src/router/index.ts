import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import GeneralLayout from "@/views/layout/GeneralLayout.vue";
import ClientOption from "@/views/ClientOption.vue"



const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    component: GeneralLayout,
    children: [
      {
        path: "/client",
        component: ClientOption
      },
    ]
  },
  
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})


export default router
