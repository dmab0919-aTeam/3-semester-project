
// Routes to redirect user
const frontpage = () => import('../layouts/frontpage.vue')
const loginAuth = () => import('../layouts/LoginAuth.vue')
const singleMovie = () => import('../components/singleMovie.vue')
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
        path: '/movie/:id',
        name: 'singleMovie',
        component: singleMovie
    },
      {
         path: '/register',
         name: 'register',
         component: registerpage,
          meta: { requiresAuth: false}
      }
   ] 

export default routes