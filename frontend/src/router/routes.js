
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
      },
    {
        path: '/movie/:id',
        name: 'singleMovie',
        component: singleMovie
    }
         meta: { requiresAuth: false}
      },
      {
         path: '/register',
         name: 'register',
         component: registerpage,
      }
   ] 

export default routes