
// Routes to redirect user
const frontpage = () => import('../layouts/frontpage.vue')
const loginAuth = () => import('../layouts/LoginAuth.vue')
const registerpage = () => import('../layouts/registerpage.vue')

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
      },
      {
         path: '/register',
         name: 'register',
         component: registerpage,
      }

   ] 

export default routes