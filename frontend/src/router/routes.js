
// Routes to redirect user
const frontpage = () => import('../layouts/frontpage.vue')
const loginAuth = () => import('../layouts/LoginAuth.vue')

const routes = [
      {
         path: '/',
         name: 'frontpage',
         component: frontpage,
      },
      {
         path: '/login',
         name: 'login',
         component: loginAuth,
         meta: { requiresAuth: false}
      }
   ] 

export default routes