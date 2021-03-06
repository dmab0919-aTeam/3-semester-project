
// Routes to redirect user
const frontpage = () => import('../layouts/frontpage.vue')
const loginAuth = () => import('../layouts/LoginAuth.vue')
const singleMovie = () => import('../components/singleMovie.vue')
const singleMovieSeat = () => import('../components/SingleMovieSeat.vue')
const registerpage = () => import('../layouts/registerpage.vue')
const adminPanel = () => import('../layouts/adminPanel')
const movieOrdering = () => import('../components/SingleMovieOrdering.vue')
const payment = () => import('../components/Payment.vue')
const ticket = () => import('../components/Ticket.vue')

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
      path: '/movieseat/:id/:showingid',
      name: 'singleMovieSeat',
      component: singleMovieSeat
  },
    {
        path: '/movieordering/:id/:showingid/:seats/:key',
        name: 'singleMovieOrdering',
        component: movieOrdering
    },
    {
        path: '/payment/:id/:showingid/:seats/:key',
        name: 'payment',
        component: payment
    },
    {
        path: '/ticket/:id/:showingid/:orderId',
        name: 'ticket',
        component: ticket
    },
      {
         path: '/register',
         name: 'register',
         component: registerpage,
          meta: { requiresAuth: false}
      },
      {
         path: '/admin',
         name: 'adminPanel',
         component: adminPanel,
         meta: { requiresAuth: true}
      }
   ] 

export default routes