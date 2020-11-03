
// Routes to redirect user
const frontpage = () => import('../layouts/frontpage.vue')
const loginAuth = () => import('../layouts/LoginAuth.vue')
const singleMovie = () => import('../components/singleMovie.vue')

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
   ] 

export default routes