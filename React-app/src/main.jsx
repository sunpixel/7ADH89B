import React from 'react'
import ReactDOM from 'react-dom/client'

import App from './App.jsx'
import Login from './pages/login.jsx'
import NotFound from './pages/NotFound.jsx'
import Profile from './pages/profile.jsx'

import './index.css'


import { createBrowserRouter, RouterProvider } from 'react-router-dom'


const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>,
    errorElement: <NotFound/>
  },
  {
    path: "login",
    element: <Login/>
  },
  {
    path: "profile",
    element: <Profile/>
  },
])

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={router}/>
  </React.StrictMode>,
)
